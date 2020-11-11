using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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