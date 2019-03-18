using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ChuckNorrisApi
{
    class Program
    {
        static void Main(string[] args)
        {

            string userWeather = GetUserWeather();

            double temp = TempConv(userWeather);
            Console.WriteLine(temp);

            Console.ReadLine();
        }

        public static string ZipCode()
        {
            Console.WriteLine("What's your zip code?");
            string zipCode = Console.ReadLine();
            return zipCode;
        }

        static string GetUserWeather()
        {
            string AppSettings = File.ReadAllText("AppSetting.Dev.Json");
            string appId = JObject.Parse(AppSettings)["appId"].ToString();

            string zipCode = ZipCode();
            WebClient webClient = new WebClient();
            string apiResponce = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={appId}");
            string weather = JObject.Parse(apiResponce)["main"]["temp"].ToString();
            return weather;
        }

        public static double TempConv(string temp)
        {
            double tempKel = double.Parse(temp);
            double tempF = 1.8 * (tempKel - 273) + 32;
            return tempF;
        }

    }
}