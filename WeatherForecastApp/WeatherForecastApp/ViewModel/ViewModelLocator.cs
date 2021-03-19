using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WeatherForecastApp.Converter;
using WeatherForecastApp.Converter.Impl;
using WeatherForecastApp.Provider;
using WeatherForecastApp.Provider.Impl;

namespace WeatherForecastApp.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IWeatherProvider, WeatherProvider>();
            SimpleIoc.Default.Register<IJsonConverter, JsonConverter>();

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {

        }
    }
}