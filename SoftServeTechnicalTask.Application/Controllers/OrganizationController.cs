using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/organization")]
    [ApiController]
    [Authorize]
    public class OrganizationController : BaseController<Organization>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        /// <summary>
        /// Get existing organization by Id
        /// </summary>
        /// <param name="organizationId">Id of organization which you want to get</param>
        /// <returns>Return organization model with all sub-items (countries, business, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [AllowAnonymous]
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> Get([FromRoute]int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            return organization == null ? 
                ReturnNotFound(organizationId) : 
                ReturnOk(organization);
        }

        /// <summary>
        /// Create new organization
        /// </summary>
        /// <param name="organization">Object of organization which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Organization with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Organization organization)
        {
            return await _organizationRepository.CreateAsync(organization) ? 
                ReturnAcceptedCreated(organization) : 
                ReturnConflict(organization);
        }

        /// <summary>
        /// Update existing organization
        /// </summary>
        /// <param name="organization">Object of organization which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Organization with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Organization organization)
        {
            return await _organizationRepository.UpdateAsync(organization) ? 
                ReturnAcceptedUpdate(organization) : 
                ReturnNotFound(organization.Id);
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
            return await _organizationRepository.DeleteByIdAsync(organizationId) ?
            ReturnAcceptedDelete(organization) :
            ReturnNotFound(organizationId);
        }
    }
}
