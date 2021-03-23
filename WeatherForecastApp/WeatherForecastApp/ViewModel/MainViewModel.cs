using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using WeatherForecastApp.Models;
using WeatherForecastApp.Provider;
using WeatherForecastApp.Provider.Impl;

namespace WeatherForecastApp.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
       


        private IUserControlViewModel _ucViewModel;
        private IDisplayWeatherViewModel _dpViewModel;
        private IWeatherProvider _weatherProvider;

        public IUserControlViewModel UserControl
        {
            get => _ucViewModel;
            set
            {
                _ucViewModel = value;
                RaisePropertyChanged();
            }
        }

        public IDisplayWeatherViewModel DisplayWeather
        {
            get => _dpViewModel;
            set
            {
                _dpViewModel = value;
                RaisePropertyChanged();
            }
        }
       

        public MainViewModel(IWeatherProvider weatherProvider, IUserControlViewModel ucViewModel, IDisplayWeatherViewModel dpViewModel)
        {
            _weatherProvider = weatherProvider;
            _ucViewModel = ucViewModel;
            _dpViewModel = dpViewModel;
            _ucViewModel.WeatherChanged += OnWeatherChanged; 
        }



        private void OnWeatherChanged(object sender, WeatherEventArgs e)
        {
            _dpViewModel.SetWeather(e.root);
        }


    }
}