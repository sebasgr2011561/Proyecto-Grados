﻿using Application.Interfaces;
using Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class InjectionExtensions
    {
        [Obsolete]
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILoginApplication, LoginApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICoursesApplication, CoursesApplication>();
            services.AddScoped<IAssignmentsApplication, AssignmentsAppication>();
            services.AddScoped<IRolesApplication, RolesApplication>();
            services.AddScoped<IRouteApplication, RouteApplication>();
            services.AddScoped<IQualificationsApplication, QualificationsApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IModuleApplication, ModuleApplication>();


            services.AddTransient<IFileStorageLocalApplication, FileStorageLocalApplication>();

            return services;
        }
    }
}
