using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Agriculture.BusinessLayer.Container;
using Agriculture.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AgricultureContext veritabaný baðlamýný uygulamaya ekler.
builder.Services.AddDbContext<AgricultureContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();

builder.Services.ContainerDependencies();

builder.Services.AddMvc(config =>
{
    // Sistemin bütünün authenticate (kimlik doðrulama) olmasýný saðlar.
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
