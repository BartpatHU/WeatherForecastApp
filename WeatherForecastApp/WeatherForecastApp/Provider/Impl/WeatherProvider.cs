using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using WeatherForecastApp.Converter.Impl;
using WeatherForecastApp.Models;
using WeatherForecastApp.Converter;

namespace WeatherForecastApp.Provider.Impl
{
    public class WeatherProvider : IWeatherProvider
    {
        private IJsonConverter _jsonConverter;
        public WeatherProvider(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }
        //public Task<string> GetWeather()
        public async Task<Root> GetWeather(string city)
        {
            return await GetRequest("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=744dcb864b7a357be83e7c6d3adf91f1");
        }

        async Task<Root> GetRequest(string url)
        {

            HttpClient client = new HttpClient();


            try
            {
                string content = await client.GetStringAsync(url);


                return _jsonConverter.Convert(content);


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }


        }

    }
}
