using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationContext _context;

        public OrganizationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Organization> GetById(int entityId)
        {
            return _context.Organizations.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task<bool> Create(Organization entity)
        {
            var existingOrganization = await _context.Organizations.FirstOrDefaultAsync(x => x.Name == entity.Name);
            if (existingOrganization != null)
                return false;

            await _context.Organizations.AddAsync(entity);
            return true;
        }

        public Task Update(Organization entity)
        {
            _context.Organizations.Update(entity);

            return Task.CompletedTask;
        }

        public async Task<bool> DeleteById(int entityId)
        {
            var existingOrganization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == entityId);
            if (existingOrganization == null)
                return false;

            _context.Organizations.Remove(existingOrganization);
            return true;
        }

        public Task<Organization> GetByName(string name)
        {
            return _context.Organizations.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
