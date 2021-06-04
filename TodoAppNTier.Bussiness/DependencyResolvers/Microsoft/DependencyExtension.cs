﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Bussiness.Interfaces;
using TodoAppNTier.Bussiness.Services;
using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.UnitOfWork;

namespace TodoAppNTier.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AppDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkManager>();
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=TodoDb;integrated security=true;");
            });
        }
    }
}
