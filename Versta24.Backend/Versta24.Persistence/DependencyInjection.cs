﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Versta24.Application.interfaces;
namespace Versta24.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IOrdersDbContext>(provider => provider.GetService<OrdersDbContext>());
            return services;
        }

    }
}
