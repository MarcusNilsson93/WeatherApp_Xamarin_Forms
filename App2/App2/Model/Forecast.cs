using System;

namespace App2.Model
{
    public class Forecast
    {
       public string Name { get; set; }
       public WeatherData Main { get; set; }
       
       public Sys sys { get; set; }

    }

    public class WeatherData
    {
        public double Temp { get; set; }
        public double Feels_Like{ get; set; }
        public double Temp_Min{ get; set; }
        public double Temp_Max { get; set; }
        public int Pressure{ get; set; }
        public int Humidity{ get; set; }

        public override string ToString()
        {
            return $"Temp{Temp} FeelsLike{Feels_Like} " +
                   $"TempMin{Temp_Min} Tempmax{Temp_Max} Pressure{Pressure} Humidity{Humidity}";
        }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public String country { get; set; }
        public int sunRice { get; set; }
        public int sunSet { get; set; }
        
        public override string ToString()
        {
            return $"Type{type} id{id} " +
                   $"countryCode{country} sunRice{sunRice} sunset{sunSet}";
        }
    }
}