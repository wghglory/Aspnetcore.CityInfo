using Aspnetcore.CityInfo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aspnetcore.CityInfo.Api.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // return Ok(CitiesDataStore.Cities);

            var cityEntities = _cityInfoRepository.GetCities();

//            return Ok(cityEntities.Include(x => x.PointsOfInterest));  // include points of interest
            return Ok(cityEntities);
        }

        [HttpGet("{id}")]
        /*public IActionResult Get(int id)
        {
            var city = CitiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }*/
        public IActionResult Get(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}