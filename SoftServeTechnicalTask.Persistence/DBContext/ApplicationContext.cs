using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext
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
            modelBuilder.Entity<Organization>().HasKey(x => x.Id);
            modelBuilder.Entity<Organization>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Organization>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Organization>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Organization>().Property(x => x.Owner).IsRequired();
            modelBuilder.Entity<Organization>().Property(x => x.OrganizationType).IsRequired();

            modelBuilder.Entity<Country>().HasKey(x => x.Id);
            modelBuilder.Entity<Country>().HasOne(x => x.Organization)
                .WithMany(o => o.Countries)
                .HasForeignKey(c => c.OrganizationId);
            modelBuilder.Entity<Country>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Country>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Country>().Property(x => x.OrganizationId).IsRequired();

            modelBuilder.Entity<Business>().HasKey(x => x.Id);
            modelBuilder.Entity<Business>().HasOne(x => x.Country)
                .WithMany(c => c.Businesses)
                .HasForeignKey(b => b.CountryId);
            modelBuilder.Entity<Business>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.CountryId).IsRequired();
            
            modelBuilder.Entity<Family>().HasKey(x => x.Id);
            modelBuilder.Entity<Family>().HasOne(x => x.Business)
                .WithMany(b => b.Families)
                .HasForeignKey(f => f.BusinessId);
            modelBuilder.Entity<Family>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Family>().Property(x => x.BusinessId).IsRequired();

            modelBuilder.Entity<Offering>().HasKey(x => x.Id);
            modelBuilder.Entity<Offering>().HasOne(x => x.Family)
                .WithMany(f => f.Offerings)
                .HasForeignKey(o => o.FamilyId);
            modelBuilder.Entity<Offering>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Offering>().Property(x => x.FamilyId).IsRequired();

            modelBuilder.Entity<Department>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().HasOne(x => x.Offering)
                .WithMany(o => o.Departments)
                .HasForeignKey(d => d.OfferingId);
            modelBuilder.Entity<Department>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Department>().Property(x => x.OfferingId).IsRequired();

            modelBuilder.Entity<Country>()
                .HasIndex(p => new { p.Name, p.OrganizationId })
                .IsUnique();

            modelBuilder.Entity<Business>()
                .HasIndex(x => new { x.Name, x.CountryId })
                .IsUnique();

            modelBuilder.Entity<Family>()
                .HasIndex(x => new {x.Name, x.BusinessId})
                .IsUnique();

            modelBuilder.Entity<Offering>()
                .HasIndex(x => new {x.Name, x.FamilyId})
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(x => new {x.Name, x.OfferingId})
                .IsUnique();

        }
    }
}
