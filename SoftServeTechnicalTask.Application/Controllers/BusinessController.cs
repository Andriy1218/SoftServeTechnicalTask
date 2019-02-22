using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/business")]
    [ApiController]
    public class BusinessController : BaseController<Business>
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        /// <summary>
        /// Get existing business by Id
        /// </summary>
        /// <param name="businessId">Id of business which you want to get</param>
        /// <returns>Return business model with all sub-items (families, offerings, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Business with such id wasn't found</response>
        [HttpGet("{businessId}")]
        public async Task<IActionResult> Get([FromRoute]int businessId)
        {
            var business = await _businessRepository.GetByIdAsync(businessId);
            return business == null ?
                ReturnNotFound(businessId) :
                ReturnOk(business);
        }

        /// <summary>
        /// Create new business
        /// </summary>
        /// <param name="business">Object of business which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Business with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Business business)
        {
            return await _businessRepository.CreateAsync(business) ?
                ReturnAcceptedCreated(business) :
                ReturnConflict(business);
        }

        /// <summary>
        /// Update existing business
        /// </summary>
        /// <param name="business">Object of business which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Business with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Business business)
        {
            return await _businessRepository.UpdateAsync(business) ?
                ReturnAcceptedUpdate(business) :
                ReturnNotFound(business.Id);
        }

        /// <summary>
        /// Delete existing business
        /// </summary>
        /// <param name="businessId">Id of business which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Business with such id wasn't found</response>
        [HttpDelete("{businessId}")]
        public async Task<IActionResult> Delete(int businessId)
        {
            var business = await _businessRepository.GetByIdAsync(businessId);
            return await _businessRepository.DeleteByIdAsync(businessId) ?
            ReturnAcceptedDelete(business) :
            ReturnNotFound(businessId);
        }

    }
}
