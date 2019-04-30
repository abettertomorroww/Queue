using DataLogicLayer.Services;
using DataLogicLayer.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLogicLayer.Data
{
    public static class DataLibraryCollectionExtentions
    {
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQueueDataService, QueueDataService>();
            services.AddScoped<IUserDataService, UserDataService>();

            return services;
        }
    }
}
