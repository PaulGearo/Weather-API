using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Weather
{
    class GetWeather
    {
        public GetWeather()
        {

        }

        static void Main(string[] args)
        {
            string userWeather = RetrieveUserWeather();
            double temp = HelperMethods.TempConv(userWeather);
            Console.WriteLine(temp + "°F");

            bool isYes = HelperMethods.YesOrNO();
    
            while (isYes)
            {
                userWeather = RetrieveUserWeather();
                temp = HelperMethods.TempConv(userWeather);
                Console.WriteLine(temp + "°F");
            }

            return;
        }

        
        static string RetrieveUserWeather()
        {
            string AppSettings = File.ReadAllText("AppSetting.Dev.Json");
            string appId = JObject.Parse(AppSettings)["appId"].ToString();

            string zipCode = HelperMethods.GetZipCode();

            //
            WebClient webClient = new WebClient();
            string apiResponce = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={appId}");
            var weather = JObject.Parse(apiResponce)["main"]["temp"].ToString();

            return weather;
        }
    }
}