using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Aspnetcore.CityInfo.Api.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        public CitiesController()
        {
            // if data comes from db, config ICityRepository, inject ICityRepository here 
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CitiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var city = CitiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}