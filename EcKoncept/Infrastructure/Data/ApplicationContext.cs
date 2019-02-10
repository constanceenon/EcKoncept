using EcKoncept.Models;
using EcKoncept.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Contact> ContactUs { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }
}
