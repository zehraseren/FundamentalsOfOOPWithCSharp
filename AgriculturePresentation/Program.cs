using Agriculture.BusinessLayer.Abstract;
using Agriculture.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Agriculture.DataAccessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Agriculture.DataAccessLayer.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AgricultureContext veritaban� ba�lam�n� uygulamaya ekler.
builder.Services.AddDbContext<AgricultureContext>();
// IServiceDal interface i�in EfServiceDal class'�n� ba��ml�l�k olarak ekler.
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
// IServiceService interface i�in ServiceManager class'�n� ba��ml�l�k olarak ekler.
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IImageDal, EfImageDal>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();

builder.Services.AddMvc(config =>
{
    // Sistemin b�t�n�n authenticate (kimlik do�rulama) olmas�n� sa�lar.
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
