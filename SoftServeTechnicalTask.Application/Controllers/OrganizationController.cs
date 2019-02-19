using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            this._organizationRepository = organizationRepository;
        }


        // ToDo: Add xml documentation to all controllers/actions
        /// <summary>
        /// GetByIdAsync existing organization by Id
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to get</param>
        /// <returns>Return organization model with all sub-items (countries, business, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationById(int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
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
            var successfullyCreated = await _organizationRepository.CreateAsync(organization);
            if (!successfullyCreated)
            {
                Log.Warning($"Organization with name={organization.Name} already exists!");
                return Conflict("Organization with name={organization.Name} already exists!");
            }

            Log.Information($"Organization {organization.Name} was successfully created!");
            return Accepted(organization);
        }

        /// <summary>
        /// Update existing organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="organization">Object of organization which you want to update</param>
        /// <returns>Return the updated organization</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpPut("{organizationId}")]
        public async Task<IActionResult> UpdateOrganization([FromRoute] int organizationId, [FromBody] Organization organization)
        {
            var existingOrganization = await _organizationRepository.GetByIdAsync(organizationId);
            if (existingOrganization == null)
            {
                Log.Warning($"Organization with id={organization.Id} wasn't found!");
                return NotFound($"Organization with id={organization.Id} wasn't found!");
            }

            await _organizationRepository.UpdateAsync(organization);

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
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            if (organization == null)
            {
                Log.Warning($"Organization with id={organizationId} wasn't found!");
                return NotFound($"Organization with id={organizationId} wasn't found!");
            }

            await _organizationRepository.DeleteByIdAsync(organizationId);

            Log.Information($"Organization {organization.Name} was successfully deleted!");
            return Accepted($"Organization {organization.Name} was successfully deleted!");
        }
    }
}
