using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SoftServeTechnicalTask.DBContext;
using SoftServeTechnicalTask.Model;

namespace SoftServeTechnicalTask.Controllers
{
    [Route("/api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationContext context;

        public CountriesController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Test(int countryId)
        {
            Organization organization = new Organization("TestOrganization5", "Org5", OrganizationType.GeneralPartnership, "Owner4");
            context.Organizations.Add(organization);
            context.SaveChanges();
            Country country = new Country("Denmark", "DK", 2);
            context.Countries.Add(country);
            context.SaveChanges();
            return Ok(organization);
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            //ToDo: Add useful logging to all controllers/actions
            Log.Information($"Someone requested country with id={countryId}");
            var country = await context.Countries.FirstOrDefaultAsync(x => x.Id == countryId);
            if (country == null)
            {
                Log.Warning($"Country with id={countryId} wasn't found!");
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            var existingCountry = await context.Countries.FirstOrDefaultAsync(x =>
                x.OrganizationId == country.OrganizationId &&
                x.Name.Equals(country.Name, StringComparison.InvariantCultureIgnoreCase));
            
            if (existingCountry != null)
                return Conflict();

            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return Accepted(country);
        }
    }
}
