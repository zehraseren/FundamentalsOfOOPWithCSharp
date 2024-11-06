using Agriculture.BusinessLayer.Abstract;
using Agriculture.BusinessLayer.Concrete;
using Agriculture.DataAccessLayer.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Agriculture.DataAccessLayer.Concrete.EntityFramework;

namespace Agriculture.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            // IServiceDal interface için EfServiceDal class'ını bağımlılık olarak ekler.
            services.AddScoped<IServiceDal, EfServiceDal>();
            // IServiceService interface için ServiceManager class'ını bağımlılık olarak ekler.
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<ITeamDal, EfTeamDal>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IImageDal, EfImageDal>();
            services.AddScoped<IImageService, ImageManager>();
            services.AddScoped<IAddressDal, EfAddressDal>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAdminDal, EfAdminDal>();
            services.AddScoped<IAdminService, AdminManager>();
        }
    }
}
