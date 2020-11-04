using System;
using System.Collections.Generic;
using System.Text;
using Weather.Classes;

namespace Weather
{
    public class WeatherData
    {
        public string WeatherDescription { get; set; }

        public string WindSpeed { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }

        public Temperature Temperatures { get; set; }


    }
}
