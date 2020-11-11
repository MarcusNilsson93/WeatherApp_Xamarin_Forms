using System;
using System.Diagnostics;
using App2.Model;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private OpenWeatherMapApi _openWeatherMapApi;

        public MainPageViewModel(OpenWeatherMapApi openWeatherMapApi)
        {
            _openWeatherMapApi = openWeatherMapApi;
            openWeatherMapApi.Text = _city;

            ButtonAction = new Command(execute: async () =>
            {
                Debug.WriteLine("Här är innan anrop");
                Debug.WriteLine(_openWeatherMapApi.GetCityUri(_city));
                Forecast = await _openWeatherMapApi.GetWeather(_openWeatherMapApi.GetCityUri(_city));
                
                //Text = fact.Name;
                //Debug.WriteLine($"data {_forecast.Main.Temp}");

            }, canExecute: () => true);
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