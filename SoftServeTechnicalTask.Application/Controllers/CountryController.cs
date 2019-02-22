using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/country")]
    [ApiController]
    public class CountryController : BaseController<Country>
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Get existing country by Id
        /// </summary>
        /// <param name="countryId">Id of country which you want to get</param>
        /// <returns>Return country model with all sub-items (business, families, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Country with such id wasn't found</response>
        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get([FromRoute]int countryId)
        {
            var country = await _countryRepository.GetByIdAsync(countryId);
            return country == null ?
                ReturnNotFound(countryId) :
                ReturnOk(country);
        }

        /// <summary>
        /// Create new country
        /// </summary>
        /// <param name="country">Object of country which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Country with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Country country)
        {
            return await _countryRepository.CreateAsync(country) ?
                ReturnAcceptedCreated(country) :
                ReturnConflict(country);
        }

        /// <summary>
        /// Update existing country
        /// </summary>
        /// <param name="country">Object of country which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Country with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            return await _countryRepository.UpdateAsync(country) ?
                ReturnAcceptedUpdate(country) :
                ReturnNotFound(country.Id);
        }

        /// <summary>
        /// Delete existing country
        /// </summary>
        /// <param name="countryId">Id of country which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Country with such id wasn't found</response>
        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var country = await _countryRepository.GetByIdAsync(countryId);
            return await _countryRepository.DeleteByIdAsync(countryId) ?
            ReturnAcceptedDelete(country) :
            ReturnNotFound(countryId);
        }
    }
}
