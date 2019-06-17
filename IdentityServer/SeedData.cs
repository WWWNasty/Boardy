// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            //services.AddDbContext<BoardyDbContext>(options =>
            //   options.UseSqlServer(connectionString));

            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<BoardyDbContext>()
            //    .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    //var context = scope.ServiceProvider.GetService<BoardyDbContext>();
                    //context.Database.Migrate();
                }
            }
        }
    }
}
