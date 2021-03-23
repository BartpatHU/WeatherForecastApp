using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.ViewModel
{
    public class DisplayWeatherViewModel : ViewModelBase,IDisplayWeatherViewModel
    {

        private double _currTemp = 0;
        public double CurrTemp
        {
            get => _currTemp;
            set
            {
                _currTemp = Convert.ToInt32(value - 273.15);
                RaisePropertyChanged();
            }
        }

        private double _currFeelsLike = 0;
        public double CurrFeelsLike
        {
            get => _currFeelsLike;
            set
            {
                _currFeelsLike = Convert.ToInt32(value - 273.15);
                RaisePropertyChanged();
            }
        }

        private double _currHumidity = 0;
        public double CurrHumidity
        {
            get => _currHumidity;
            set
            {
                _currHumidity = value;
                RaisePropertyChanged();
            }
        }

        private double _currWind = 0;
        public double CurrWind
        {
            get => _currWind;
            set
            {
                _currWind = Convert.ToInt32(value * 3.6);
                RaisePropertyChanged();
            }
        }



        public DisplayWeatherViewModel()
        {
                
        }

        public void SetWeather(Root root)
        {
                CurrTemp = root.Main.Temp;
                CurrFeelsLike = root.Main.Feels_Like;
                CurrHumidity = root.Main.Humidity;
                CurrWind = root.Wind.Speed;
        }

    }
}
