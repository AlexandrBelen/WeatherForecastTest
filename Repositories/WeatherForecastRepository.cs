using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastTestTask.Config;
using WeatherForecastTestTask.WeatherModels;

namespace WeatherForecastTestTask.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string key = Constants._weatherApiKey;
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={key}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content.ToObject<WeatherResponse>();
            }
            return null;
        }
    }
}
