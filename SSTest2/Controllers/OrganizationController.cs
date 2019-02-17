using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSTest2.DBContext;
using SSTest2.Model;

namespace SSTest2.Controllers
{
    [Route("/api/organizations")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly ApplicationContext context;

        public OrganizationController(ApplicationContext context)
        {
            this.context = context;
        }

        // ToDo: Add xml documentation to all controllers/actions
        /// <summary>
        /// Get organization by id
        /// </summary>
        /// <param name="organizationId">id of organization which you want to get</param>
        /// <returns>organization model with all sub-items (countries, etc)</returns>
        /// <response code="200">All is good</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationById(int organizationId)
        {
            var organization = await context.Organizations.Include(p => p.Countries).FirstOrDefaultAsync(x => x.Id == organizationId);
            if (organization == null)
                return NotFound();

            return Ok(organization);
        }

        /// <summary>
        /// Create new organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization organization)
        {
            context.Organizations.Add(organization);
            await context.SaveChangesAsync();

            return Accepted(organization);
        }

        [HttpPut("{organizationId}")]
        public async Task<IActionResult> UpdateOrganization(Organization organization)
        {
            context.Organizations.Update(organization);
            await context.SaveChangesAsync();

            return Accepted(organization);
        }

        [HttpDelete("{organizationId}")]
        public async Task<IActionResult> DeleteOrganizationById(int organizationId)
        {
            var organization = await context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);
            if (organization == null)
                return NotFound();

            context.Organizations.Remove(organization);
            await context.SaveChangesAsync();

            return Accepted();
        }
    }
}
