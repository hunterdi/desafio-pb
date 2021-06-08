using Architecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture
{
    public static class DbContextConfigurationExtension
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDataMongoContext>();

            return services;
        }
    }
}
