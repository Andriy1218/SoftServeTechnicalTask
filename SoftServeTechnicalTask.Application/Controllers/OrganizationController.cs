using Microsoft.AspNetCore.Mvc;
using Serilog;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.Commands.Organizations;
using System.Threading.Tasks;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/organization")]
    [ApiController]
    public class OrganizationController : BaseController<Organization>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
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
        public async Task<IActionResult> Get([FromRoute]int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            return organization == null ? ReturnNotFound(organizationId) : ReturnOk(organization);
        }

        /// <summary>
        /// Create new organization
        /// </summary>
        /// <param name="command">Object of organization which you want to create</param>
        /// <returns>Return the created organization</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Organization with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddCommand command)
        {
            var organization = new AddCommandMapper().Map(command);
            var result = await _organizationRepository.CreateAsync(organization);
            return result ? ReturnCreatedAtAction(organization) : ReturnConflict(organization);
        }

        /// <summary>
        /// Update existing organization
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to update</param>
        /// <param name="organization">Object of organization which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpPut("{organizationId}")]
        public async Task<IActionResult> Update([FromRoute] int organizationId, [FromBody] Organization organization)
        {
            var existingOrganization = await _organizationRepository.GetByIdAsync(organizationId);
            if (existingOrganization == null)
                ReturnNotFound(organizationId);

            await _organizationRepository.UpdateAsync(organization);
            return ReturnAcceptedUpdate(organization);
        }

        /// <summary>
        /// Delete existing organization
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpDelete("{organizationId}")]
        public async Task<IActionResult> Delete(int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            if (organization == null)
                ReturnNotFound(organizationId);

            await _organizationRepository.DeleteByIdAsync(organizationId);
            return ReturnAcceptedDelete(organization);
        }

        private IActionResult ReturnCreatedAtAction(Organization organization)
        {
            Log.Information($"Organization {organization.Name} was successfully created!");
            return CreatedAtAction(nameof(Get), organization.Id);
        }

        private IActionResult ReturnOk(Organization organization)
        {
            Log.Information($"Organization with id={organization.Id} was successfully sent!");
            return Ok(organization);
        }
    }
}
