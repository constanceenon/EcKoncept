using EcKoncept.Interfaces.Repositories;
using EcKoncept.Managers;
using EcKoncept.Repository;
using EcKoncept.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Infrastructure
{
    public static class AppServiceExtension
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Managers
            services.AddScoped<IContactManager, ContactManager>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            
        }
    }
}
