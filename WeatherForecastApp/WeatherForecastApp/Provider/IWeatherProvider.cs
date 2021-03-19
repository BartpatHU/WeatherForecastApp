using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Provider
{
    public interface IWeatherProvider
    {

        Task<Root> GetWeather(string city);
       
    }
}
