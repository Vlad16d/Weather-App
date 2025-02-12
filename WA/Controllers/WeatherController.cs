using Microsoft.AspNetCore.Mvc;
using WA.Models;

namespace WeatherSolution.Controllers
{
    public class WeatherController : Controller
    {
        //initialize hard-coded data as instructed in the requirement
        private List<CityWeather> cities = new List<CityWeather>() {
            new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

            new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

            new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 },
        
            new CityWeather() { CityUniqueCode = "TKY", CityName = "Tokyo", DateAndTime = Convert.ToDateTime("2030-01-01 17:00"), TemperatureFahrenheit = 90 },

            new CityWeather() { CityUniqueCode = "WAR", CityName = "Warsaw", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 75 },

            new CityWeather() { CityUniqueCode = "MSK", CityName = "Minsk", DateAndTime = Convert.ToDateTime("2030-01-01 10:00"), TemperatureFahrenheit = 65 }
        };


        [Route("/")]
        public IActionResult Index()
        {
            //send cities collection to "Views/Weather/Index" view
            return View(cities);
        }


        [Route("weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/Index" view
                return View();
            }

            //get matching city object based on the city code
            CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

            //send matching city object to "Views/Weather/Index" view
            return View(city);
        }
    }
}
