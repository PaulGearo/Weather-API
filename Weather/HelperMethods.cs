using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Weather.Classes;

namespace Weather
{
    public class HelperMethods
    {
        public static string GetZipCode()
        {
            Console.WriteLine("What's your zip code?");
            string zipCode = Console.ReadLine();
            return zipCode;
        }

        public static double TempConv(string temp)
        {
            double tempKel = double.Parse(temp);
            double tempF = 1.8 * (tempKel - 273) + 32;
            return tempF;
        }

        public static DateTime UnixTimeToDateTime(string utime)
        {
            var unixtime = long.Parse(utime);
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        public static bool YesOrNO()
        {
            Console.WriteLine("Would you like to enter another?\n" + "Please enter yes or no");
            string userResponse = Console.ReadLine();
            userResponse = userResponse.ToUpper();

            while (userResponse != "YES" && userResponse != "NO")
            {
                Console.WriteLine("Please answer: Yes or No\n");
                userResponse = Console.ReadLine();
                userResponse = userResponse.ToUpper();
            }

            if (userResponse == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static WeatherData RetrieveUserWeather()
        {
            string AppSettings = File.ReadAllText("AppSetting.Dev.Json");
            string appId = JObject.Parse(AppSettings)["appId"].ToString();

            string zipCode = HelperMethods.GetZipCode();

            WebClient webClient = new WebClient();
            string apiResponce = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={appId}");

            var temp = new Temperature
            {
                ActualTemp = TempConv(JObject.Parse(apiResponce)["main"]["temp"].ToString()),
                FeelsLikeTemp = TempConv(JObject.Parse(apiResponce)["main"]["feels_like"].ToString()),
                MaxTemp = TempConv(JObject.Parse(apiResponce)["main"]["temp_max"].ToString()),
                MinTemp = TempConv(JObject.Parse(apiResponce)["main"]["temp_min"].ToString()),
                Humidity = TempConv(JObject.Parse(apiResponce)["main"]["humidity"].ToString())
            };

            //var testWeatherDescription = JObject.Parse(apiResponce)["weather"]["description"].ToString();
            var testWindSpeed = JObject.Parse(apiResponce)["wind"]["speed"].ToString();
            var testCountry = JObject.Parse(apiResponce)["sys"]["country"].ToString();
            var testCity = JObject.Parse(apiResponce)["name"].ToString();
            var testSunrise = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunrise"].ToString());
            var testSunset = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunset"].ToString());



            var weatherObject = new WeatherData
            {
               // WeatherDescription = JObject.Parse(apiResponce)["weather"]["description"].ToString(),
                WindSpeed = JObject.Parse(apiResponce)["wind"]["speed"].ToString(),
                Country = JObject.Parse(apiResponce)["sys"]["country"].ToString(),
                City = JObject.Parse(apiResponce)["name"].ToString(),
                Sunrise = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunrise"].ToString()),
                Sunset = HelperMethods.UnixTimeToDateTime(JObject.Parse(apiResponce)["sys"]["sunset"].ToString()),
                Temperatures = temp
            };

            return weatherObject;
        }
    }
}
