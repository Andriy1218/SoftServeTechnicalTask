using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SoftServeTechnicalTask.DBContext;
using SoftServeTechnicalTask.Model;

namespace SoftServeTechnicalTask.Controllers
{
    [Route("/api/organization")]
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
        /// Get existing organization by Id
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to get</param>
        /// <returns>Return organization model with all sub-items (countries, business, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationById(int organizationId)
        {
            var organization = await context.Organizations.Include(p => p.Countries).FirstOrDefaultAsync(x => x.Id == organizationId);
            if (organization == null)
            {
                Log.Warning($"Organization with id={organizationId} wasn't found!");
                return NotFound($"Organization with id={organizationId} wasn't found!");
            }

            Log.Information($"Organization with id={organizationId} was successfully sent!");
            return Ok(organization);
        }

        /// <summary>
        /// Create new organization
        /// </summary>
        /// <param name="organization">Object of organization which you want to create</param>
        /// <returns>Return the created organization</returns>
        /// <response code="202">Successfully created</response>
        /// <response code="409">Organization with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization organization)
        {
            var existingOrganization = await context.Organizations
                .FirstOrDefaultAsync(x => x.Name == organization.Name);

            if (existingOrganization != null)
            {
                Log.Warning($"Organization with name={organization.Name} already exists!");
                return Conflict("Organization with name={organization.Name} already exists!");
            }

            context.Organizations.Add(organization);
            await context.SaveChangesAsync();

            Log.Information($"Organization {organization.Name} was successfully created!");
            return Accepted(organization);
        }

        /// <summary>
        /// Update existing organization
        /// </summary>
        /// <param name="organization">Object of organization which you want to update</param>
        /// <returns>Return the updated organization</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpPut("{organization}")]
        public async Task<IActionResult> UpdateOrganization(Organization organization)
        {
            var existingOrganization = await context.Organizations.FirstOrDefaultAsync(x => x.Id == organization.Id);
            if (existingOrganization == null)
            {
                Log.Warning($"Organization with id={organization.Id} wasn't found!");
                return NotFound($"Organization with id={organization.Id} wasn't found!");
            }

            context.Organizations.Update(organization);
            await context.SaveChangesAsync();

            Log.Information($"Organization {organization.Name} was successfully updated!");
            return Accepted(organization);
        }

        /// <summary>
        /// Delete existing organization
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpDelete("{organizationId}")]
        public async Task<IActionResult> DeleteOrganizationById(int organizationId)
        {
            var organization = await context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);
            if (organization == null)
            {
                Log.Warning($"Organization with id={organizationId} wasn't found!");
                return NotFound($"Organization with id={organizationId} wasn't found!");
            }

            context.Organizations.Remove(organization);
            await context.SaveChangesAsync();

            Log.Information($"Organization {organization.Name} was successfully deleted!");
            return Accepted($"Organization {organization.Name} was successfully deleted!");
        }
    }
}
