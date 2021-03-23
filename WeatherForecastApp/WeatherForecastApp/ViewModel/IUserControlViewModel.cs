using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.ViewModel
{
    public interface IUserControlViewModel
    {
        event EventHandler<WeatherEventArgs> WeatherChanged;

    }
}
