using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Context;

namespace TodoAppNTier.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AppDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=TodoDb;integrated security=true;");
            });
        }
    }
}
