using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using DataAccessLayer.Implementation.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Implementation.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBlDependencies(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDalDependencies(configuration);

            collection.AddScoped<IAdvertService, AdvertService>();

            //TODO добавить еще сервисов
            collection.AddScoped<IAdvertCommentService, AdvertCommentService>();
            collection.AddScoped<ISubCategoryService, SubCategoryService>();
            collection.AddScoped<ILikeService, LikeService>();
            collection.AddScoped<IPromptService, PromptService>();
            return collection;
        }
    }
}
