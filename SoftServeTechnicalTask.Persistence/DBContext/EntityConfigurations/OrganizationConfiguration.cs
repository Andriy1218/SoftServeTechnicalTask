using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Owner).IsRequired();
            builder.Property(x => x.OrganizationType).IsRequired();
        }   
    }
}
