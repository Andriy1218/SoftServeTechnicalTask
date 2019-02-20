using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.BuildingBlocks;
using System;

namespace SoftServeTechnicalTask.Application.Commands.Organizations
{
    public class AddCommandMapper : IMapper<AddCommand, Organization>
    {
        public Organization Map(AddCommand source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new Organization(source.Name, source.Code,
                source.OrganizationType, source.Owner);
        }
    }
}
