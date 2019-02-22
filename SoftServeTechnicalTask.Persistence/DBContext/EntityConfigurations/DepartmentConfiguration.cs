using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Offering)
                .WithMany(o => o.Departments)
                .HasForeignKey(d => d.ParentId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();

            builder.HasIndex(x => new { x.Name, x.ParentId })
                .IsUnique();
        }
    }
}
