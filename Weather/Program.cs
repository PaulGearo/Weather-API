using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Weather.Classes;
using Newtonsoft.Json;

namespace Weather
{
    class GetWeather
    {
        public GetWeather()
        {

        }

        static void Main(string[] args)
        {
            var userWeather = HelperMethods.RetrieveUserWeather();
           // double temp = HelperMethods.TempConv(userWeather.ToString());

            Console.WriteLine("Description: " + userWeather.WeatherDescription);
            Console.WriteLine("Wind Speed: " + userWeather.WindSpeed);
            Console.WriteLine("Country: " + userWeather.Country);
            Console.WriteLine("City: " + userWeather.City);
            Console.WriteLine("Sunrise: " + userWeather.Sunrise.ToString());
            Console.WriteLine("Sunset: " + userWeather.Sunset.ToString());
            Console.WriteLine("Current Temp: " + userWeather.Temperatures.ActualTemp.ToString() + "F°");
            Console.WriteLine("Feels like: " + userWeather.Temperatures.FeelsLikeTemp.ToString() + "F°");
            Console.WriteLine("High of: " + userWeather.Temperatures.MaxTemp.ToString() + "F°");
            Console.WriteLine("Low of: " + userWeather.Temperatures.MinTemp.ToString() + "F°");
            Console.WriteLine("Humidity: " + userWeather.Temperatures.Humidity.ToString() + "%");


            bool isYes = HelperMethods.YesOrNO();
    
            while (isYes){

                userWeather = HelperMethods.RetrieveUserWeather();

                Console.WriteLine("Description: " + userWeather.WeatherDescription);
                Console.WriteLine("Wind Speed: " + userWeather.WindSpeed);
                Console.WriteLine("Country: " + userWeather.Country);
                Console.WriteLine("City: " + userWeather.City);
                Console.WriteLine("Sunrise: " + userWeather.Sunrise.ToString());
                Console.WriteLine("Sunset: " + userWeather.Sunset.ToString());
                Console.WriteLine("Current Temp: " + userWeather.Temperatures.ActualTemp.ToString() + "F°");
                Console.WriteLine("Feels like: " + userWeather.Temperatures.FeelsLikeTemp.ToString() + "F°");
                Console.WriteLine("High of: " + userWeather.Temperatures.MaxTemp.ToString() + "F°");
                Console.WriteLine("Low of: " + userWeather.Temperatures.MinTemp.ToString() + "F°");
                Console.WriteLine("Humidity: " + userWeather.Temperatures.Humidity.ToString() + "%");
            }

            return;
        }

        
        //public WeatherData RetrieveUserWeather()
        //{
        //    string AppSettings = File.ReadAllText("AppSetting.Dev.Json");
        //    string appId = JObject.Parse(AppSettings)["appId"].ToString();

        //    string zipCode = HelperMethods.GetZipCode();

        //    HelperMethods.RetrieveUserWeather();



        //    WebClient webClient = new WebClient();
        //    string apiResponce = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={appId}");

        //    var thingy = JsonConvert.DeserializeObject()


        //    var temp = new Temperature
        //    {
        //        //ActualTemp = double.Parse(HelperMethods.TempConv(JObject.Parse(apiResponce)["main"]["temp"].ToString())),
        //        FeelsLikeTemp = double.Parse(JObject.Parse(apiResponce)["main"]["feels_like"].ToString()),
        //        MaxTemp = double.Parse(JObject.Parse(apiResponce)["main"]["temp_max"].ToString()),
        //        MinTemp = double.Parse(JObject.Parse(apiResponce)["main"]["temp_min"].ToString()),
        //        Humidity = double.Parse(JObject.Parse(apiResponce)["main"]["humidity"].ToString())
        //    };

        //    var weatherObject = new WeatherData
        //    {
        //        WeatherDescription = JObject.Parse(apiResponce)["weather"]["description"].ToString(),
        //        WindSpeed = JObject.Parse(apiResponce)["wind"]["speed"].ToString(),
        //        Country = JObject.Parse(apiResponce)["sys"]["country"].ToString(),
        //        City = JObject.Parse(apiResponce)["name"].ToString(),
        //        Sunrise = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunrise"].ToString()),
        //        Sunset = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunset"].ToString()),
        //        Temperatures = temp
        //    };

        //    return weatherObject;
        //}
    }
}