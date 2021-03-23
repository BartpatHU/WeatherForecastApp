using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecastApp.Models;
using WeatherForecastApp.Provider;

namespace WeatherForecastApp.ViewModel
{
    public class UserControlViewModel : ViewModelBase, IUserControlViewModel, INotifyPropertyChanged
    {


        public Root CurrCityWeather { get; set; }


       

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged();
            }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                RaisePropertyChanged();
            }
        }
        private string _successMessage = "";
        public string SuccessMessage
        {
            get => _successMessage;
            set
            {
                _successMessage = value;
                RaisePropertyChanged();
            }
        }

        public event EventHandler<WeatherEventArgs> WeatherChanged;

        public ICommand MyCommand
        {
            get => new RelayCommand(ExecuteMyCommand);
        }

        private IWeatherProvider _weatherProvider;
        public UserControlViewModel(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;

        }

        private async void ExecuteMyCommand()
        {

            CurrCityWeather = await _weatherProvider.GetWeather(City);



            if (CurrCityWeather != null)
            {
                ErrorMessage = "";
                SuccessMessage = "The weather of " + City + ":";
                if (WeatherChanged != null){
                    WeatherChanged.Invoke(this, new WeatherEventArgs { root = CurrCityWeather});
                }
            }
            else
            {
                ErrorMessage = "Please type in an existing city!";
                SuccessMessage = "";
            }
        }


    }
}
