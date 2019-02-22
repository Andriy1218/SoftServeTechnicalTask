using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Organization)
                .WithMany(o => o.Countries)
                .HasForeignKey(c => c.ParentId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();

            builder.HasIndex(p => new { p.Name, p.ParentId })
                .IsUnique();
        }
    }
}
