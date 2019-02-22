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
    [Route("/api/offering")]
    [ApiController]
    public class OfferingController : BaseController<Offering>
    {
        private readonly IOfferingRepository _offeringRepository;

        public OfferingController(IOfferingRepository offeringRepository)
        {
            _offeringRepository = offeringRepository;
        }

        /// <summary>
        /// Get existing offering by Id
        /// </summary>
        /// <param name="offeringId">Id of offering which you want to get</param>
        /// <returns>Return offering model with all sub-items (offering, families, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Offering with such id wasn't found</response>
        [HttpGet("{offeringId}")]
        public async Task<IActionResult> Get([FromRoute]int offeringId)
        {
            var offering = await _offeringRepository.GetByIdAsync(offeringId);
            return offering == null ?
                ReturnNotFound(offeringId) :
                ReturnOk(offering);
        }

        /// <summary>
        /// Create new offering
        /// </summary>
        /// <param name="offering">Object of offering which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Offering with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Offering offering)
        {
            return await _offeringRepository.CreateAsync(offering) ?
                ReturnAcceptedCreated(offering) :
                ReturnConflict(offering);
        }

        /// <summary>
        /// Update existing offering
        /// </summary>
        /// <param name="offering">Object of offering which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Offering with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Offering offering)
        {
            return await _offeringRepository.UpdateAsync(offering) ?
                ReturnAcceptedUpdate(offering) :
                ReturnNotFound(offering.Id);
        }

        /// <summary>
        /// Delete existing offering
        /// </summary>
        /// <param name="offeringId">Id of offering which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Offering with such id wasn't found</response>
        [HttpDelete("{offeringId}")]
        public async Task<IActionResult> Delete(int offeringId)
        {
            var offering = await _offeringRepository.GetByIdAsync(offeringId);
            return await _offeringRepository.DeleteByIdAsync(offeringId) ?
            ReturnAcceptedDelete(offering) :
            ReturnNotFound(offeringId);
        }
    }
}
