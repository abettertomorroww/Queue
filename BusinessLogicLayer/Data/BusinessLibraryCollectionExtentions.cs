using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Data
{
    public static class BusinessLibraryCollectionExtentions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection services)
        {
            services.AddScoped<IQueueBusinessService, QueueBusinessService>();
            services.AddScoped<IUserBusinessService, UserBusinessService>();
            services.AddScoped<IAdminBusinessService, AdminBusinessService>();

            return services;
        }
    }
}
