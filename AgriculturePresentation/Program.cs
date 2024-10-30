using Agriculture.BusinessLayer.Abstract;
using Agriculture.BusinessLayer.Concrete;
using Agriculture.DataAccessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete;
using Agriculture.DataAccessLayer.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// AgricultureContext veritabaný baðlamýný uygulamaya ekler.
builder.Services.AddDbContext<AgricultureContext>();
// IServiceDal interface için EfServiceDal class'ýný baðýmlýlýk olarak ekler.
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
// IServiceService interface için ServiceManager class'ýný baðýmlýlýk olarak ekler.
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
