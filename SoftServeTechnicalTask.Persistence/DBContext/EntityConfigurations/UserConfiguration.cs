using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Persistence.DBContext.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Login);
            builder.Property(x => x.Login).IsRequired();
        }   
    }
}
