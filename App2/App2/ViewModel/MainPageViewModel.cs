using System.Diagnostics;
using App2.Interfaces;
using App2.Model;
using App2.Services;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(OpenWeatherMapApi openWeatherMapApi)
        {
            openWeatherMapApi.Text = _city;

            ButtonAction = new Command(execute: async () =>
            {
                DeviceDescription = DependencyService.Get<IMyInterface>().GetPlatformName();
                await new SpeekNow().Speek(_city);
                Forecast = await openWeatherMapApi.GetWeather(_city);

            }, canExecute: () => true);
        }

        private string _deviceDescription;

        public string DeviceDescription
        {
            get => _deviceDescription;
            set
            { 
                _deviceDescription = value;
                OnPropertyChanged();
                RefreshCanExecute();
            }
        }

        private string _city = "";
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                Debug.WriteLine(_city);
                OnPropertyChanged();
                RefreshCanExecute();
            }
        }

        private Forecast _forecast { get;  set; }
        public Forecast Forecast
        {
            get => _forecast;
            set
            {
                _forecast = value;
                OnPropertyChanged();
                RefreshCanExecute();
            }
        }
        public Command ButtonAction { get; set; }

        private void RefreshCanExecute()
        {
            ButtonAction.ChangeCanExecute();
            //Add more ICommands here
        }
    }
}