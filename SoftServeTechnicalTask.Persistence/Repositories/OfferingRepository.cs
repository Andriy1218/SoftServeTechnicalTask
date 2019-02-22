using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public override Task<Offering> GetByIdAsync(int id)
        {
            var existingEntity = _context.Set<Offering>()
                .Include(x => x.Departments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return existingEntity;
        }
    }
}
