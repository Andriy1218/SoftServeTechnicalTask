using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    class CountryRepository : GenericChildRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<bool> UpdateAsync(Country entity)
        {
            var existingEntity = await _context.Set<Country>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity == null)
                return false;

            existingEntity.Code = entity.Code;
            _context.Update(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
