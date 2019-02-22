using System;
using System.Collections.Generic;
using System.Text;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class OfferingRepository : GenericChildRepository<Offering>, IOfferingRepository
    {
        public OfferingRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
