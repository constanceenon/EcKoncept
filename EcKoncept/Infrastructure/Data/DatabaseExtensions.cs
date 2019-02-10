using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Infrastructure.Data
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        { 
            var conn = "connString";
            var connString = configuration.GetConnectionString(conn);
            services.AddDbContext<ApplicationContext>(cfg => cfg.UseSqlServer(connString));
            services.AddScoped<DbContext, ApplicationContext>();
        }
    }
}
