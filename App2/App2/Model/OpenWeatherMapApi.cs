using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App2.Model
{
    public class OpenWeatherMapApi
    {
        private string key = "&appid=38ac9de24ce628f7b5830c15b7bfadd2";
        private string apibase = "https://api.openweathermap.org/data/2.5/weather?q=";
        private string units = "&units=metric";

        private HttpClient _client;

        public OpenWeatherMapApi(HttpClient client)
        {
            _client = client;
        }

        public string Text { get; set; }
        

        public Uri GetCityUri(string city)
        {
            return new Uri($"{apibase}{city}{units}{key}"); 
        }

        public async Task<Forecast> GetWeather(Uri fullUri)
        {
            //Debug.WriteLine(Text);
                //Connect to api
                //We can use await on any method returning Task or Task<>
                var response = await _client.GetAsync(fullUri);
                //Debug.WriteLine("This is response object{0}",response);

                if (!response.IsSuccessStatusCode)
                {
                    //visa en prompt i vyn
                    Debug.WriteLine(response.StatusCode);
                    return new Forecast(){Name = "Invalid city name"};
                }
                //Convert response into C# object
                var content = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine($"content {content}");
                var weatherInfo = JsonConvert.DeserializeObject<Forecast>(content);
                //Debug.WriteLine($"weatherinfo {weatherInfo}");
                //Debug.WriteLine(weatherInfo.sys);
                //Debug.WriteLine(weatherInfo.Main);
                //Return that object
                return weatherInfo;
                

        }
    }
}