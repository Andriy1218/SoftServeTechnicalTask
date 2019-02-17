using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSTest2.Model;


namespace SSTest2.DBContext
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ToDo: Add IsRequired to all models
            modelBuilder.Entity<Organization>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Organization>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Organization>().Property(x => x.User).IsRequired();

            // ToDo: Add unique constraints to all models
            modelBuilder.Entity<Country>()
                .HasIndex(p => new { p.Name, p.OrganizationId })
                .IsUnique();
        }
    }
}
