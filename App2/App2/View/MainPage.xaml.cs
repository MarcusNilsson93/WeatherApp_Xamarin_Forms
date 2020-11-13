
using System.Net.Http;
using App2.Model;
using App2.ViewModel;
using Xamarin.Forms;

namespace App2.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(new OpenWeatherMapApi(new HttpClient()));
        }
    }
}