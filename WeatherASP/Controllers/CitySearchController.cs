using Microsoft.AspNetCore.Mvc;
using WeatherASP.CallAPI;
using WeatherASP.Models;
using static WeatherASP.Models.WeatherViewModels;

namespace WeatherASP.Controllers
{
    public class CitySearchController : Controller
    {

        private readonly IMakeRootObject _makeRootObject;

        public CitySearchController(IMakeRootObject makeRootObject)
        {
            _makeRootObject = makeRootObject;
        }

        public IActionResult CityChecker()
        {
            var enteredCity = new CityChecker();
            return View(enteredCity);
        }

        // POST: ForecastApp/SearchCity
        [HttpPost]
        public IActionResult CityChecker(CityChecker model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("ResultView", "CitySearch", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: ForecastApp/City
        public IActionResult ResultView(string city)
        {
            RootObject weatherResponse = _makeRootObject.GetWeather(city);
            ResultCityModel viewModel = new ResultCityModel();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = (float)weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = (float)weatherResponse.Wind.Speed;
                viewModel.IconID = weatherResponse.Weather[0].Icon;
            }
            return View(viewModel);
        }

       


    }
}
