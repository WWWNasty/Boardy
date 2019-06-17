using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories;
using DataAccessLayer.Models.MapperProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Implementation.Extensions
{
    public  static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDalDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddEntityFrameworkSqlServer()
                .AddDbContext<BoardyDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("Boardy")));
            
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<IAdvertRepository, AdvertRepository>();
            serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
            serviceCollection.AddScoped<ILikeRepository, LikeRepository>();
            serviceCollection.AddScoped<IAdvertCommentRepository, AdvertCommentRepository>();
            serviceCollection.AddScoped<IImageRepository, ImageRepository>();
            serviceCollection.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            serviceCollection.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            //TODO указать все репозитории

            return serviceCollection;
            
        }
    }
}
