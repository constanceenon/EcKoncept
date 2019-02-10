using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Models
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

    }
}
