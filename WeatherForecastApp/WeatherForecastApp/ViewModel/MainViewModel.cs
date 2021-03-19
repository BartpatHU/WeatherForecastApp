using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using WeatherForecastApp.Models;
using WeatherForecastApp.Provider;
using WeatherForecastApp.Provider.Impl;

namespace WeatherForecastApp.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        private string _asd;
        public string Asd
        {
            get => _asd;
            set
            {
                _asd = value;
                RaisePropertyChanged();
            }
    
        }
        public RelayCommand MyCommand
        {
            get;
            private set;
        }


        private IWeatherProvider _weatherProvider;


        public MainViewModel(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
            
            Asd = "asd";


            _weatherProvider.GetWeather("Szeged");
        }
    }
}