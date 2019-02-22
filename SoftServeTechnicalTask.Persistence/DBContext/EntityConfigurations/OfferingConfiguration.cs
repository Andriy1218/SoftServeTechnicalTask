using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class OfferingConfiguration : IEntityTypeConfiguration<Offering>
    {
        public void Configure(EntityTypeBuilder<Offering> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Family)
                .WithMany(f => f.Offerings)
                .HasForeignKey(o => o.ParentId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();

            builder.HasIndex(x => new { x.Name, x.ParentId })
                .IsUnique();
        }
    }
}
