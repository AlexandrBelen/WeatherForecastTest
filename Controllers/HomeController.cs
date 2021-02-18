using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastTestTask.Models;
using WeatherForecastTestTask.Repositories;
using WeatherForecastTestTask.WeatherModels;

namespace WeatherForecastTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public HomeController(IWeatherForecastRepository weatherForecast)
        {
            _weatherForecastRepository = weatherForecast;
        }

        // GET: Home/SearchCity
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: Home/SearchCity
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Home", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: ForecastApp/City
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _weatherForecastRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
