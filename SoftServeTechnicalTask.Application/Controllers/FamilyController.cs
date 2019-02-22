using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/family")]
    [ApiController]
    public class FamilyController : BaseController<Family>
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        /// <summary>
        /// Get existing family by Id
        /// </summary>
        /// <param name="familyId">Id of family which you want to get</param>
        /// <returns>Return family model with all sub-items (offerings, departments)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Family with such id wasn't found</response>
        [HttpGet("{familyId}")]
        public async Task<IActionResult> Get([FromRoute]int familyId)
        {
            var family = await _familyRepository.GetByIdAsync(familyId);
            return family == null ?
                ReturnNotFound(familyId) :
                ReturnOk(family);
        }

        /// <summary>
        /// Create new family
        /// </summary>
        /// <param name="family">Object of family which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Family with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Family family)
        {
            return await _familyRepository.CreateAsync(family) ?
                ReturnAcceptedCreated(family) :
                ReturnConflict(family);
        }

        /// <summary>
        /// Update existing family
        /// </summary>
        /// <param name="family">Object of family which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Family with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            return await _familyRepository.UpdateAsync(family) ?
                ReturnAcceptedUpdate(family) :
                ReturnNotFound(family.Id);
        }

        /// <summary>
        /// Delete existing family
        /// </summary>
        /// <param name="familyId">Id of family which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Family with such id wasn't found</response>
        [HttpDelete("{familyId}")]
        public async Task<IActionResult> Delete(int familyId)
        {
            var family = await _familyRepository.GetByIdAsync(familyId);
            return await _familyRepository.DeleteByIdAsync(familyId) ?
            ReturnAcceptedDelete(family) :
            ReturnNotFound(familyId);
        }
    }
}
