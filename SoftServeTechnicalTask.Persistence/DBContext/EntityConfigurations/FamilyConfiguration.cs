using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Business)
                .WithMany(b => b.Families)
                .HasForeignKey(f => f.ParentId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();

            builder.HasIndex(x => new { x.Name, x.ParentId })
                .IsUnique();
        }
    }
}
