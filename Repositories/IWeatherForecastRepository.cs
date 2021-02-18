using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastTestTask.WeatherModels;

namespace WeatherForecastTestTask.Repositories
{
    public interface IWeatherForecastRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
