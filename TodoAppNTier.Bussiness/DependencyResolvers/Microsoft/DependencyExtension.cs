using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Bussiness.Interfaces;
using TodoAppNTier.Bussiness.Mappings.AutoMapper;
using TodoAppNTier.Bussiness.Services;
using TodoAppNTier.Bussiness.ValidationRules.FluentValidation;
using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.UnitOfWork;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddControllersWithFluentValidation(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
        }
        public static void AppDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkManager>();
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=TodoDb;integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
        }
    }
}
