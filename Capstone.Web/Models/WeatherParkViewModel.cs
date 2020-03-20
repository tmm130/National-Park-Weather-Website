using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherParkViewModel
    {
        public Park Park { get; set; }
        public IList<WeatherModel> Weathers { get; set; }

        public string Scale { get; set; }

        public string GetWeatherHelper(string forecast, int highTemp, int lowTemp)
        {
            int DifferenceInTemp = highTemp - lowTemp;
            string MessageToCustomers = "";

            if (forecast == "snow")
            {
                return MessageToCustomers = "Pack snowshoes.";
            }
            else if (forecast == "rain")
            {
                return MessageToCustomers = "Make sure to bring your rain boots and rain gear.";
            }
            else if (forecast == "thunderstorms")
            {
                return MessageToCustomers = "Stay indoors, seek shelter and avoid hiking on exposed ridges.";
            }
            else if (forecast == "sunny")
            {
                return MessageToCustomers = "Scorching day. Great day for a tour. Pack sunblock.";
            }
            else if (highTemp >= 75)
            {
                return MessageToCustomers = "Great day for a walk around the park. Bring an extra gallon of water.";
            }
            else if (DifferenceInTemp > 20)
            {
                return MessageToCustomers = "Little nippy today. Wear breathable layers.";
            }
            else if (lowTemp <= 20)
            {
                return MessageToCustomers = "Exposure is dangerous. Too cold for a sightseeing. Head to the Bahamas.";
            }
            return MessageToCustomers;
        }

        public string FindCorrectPictureForWeather(string forecast)
        {
            string imageLink = forecast.Replace(" ", "") + ".png";
            return imageLink;
        }

        public string FindDayOfWeekForWeather(DateTime currentDay, int forecastDayNumber)
        {
            int dayToShow = (int)currentDay.DayOfWeek + forecastDayNumber - 1;
            if (dayToShow > 6)
            {
                dayToShow -= 7;
            }
            string wordDayOfTheWeek = Enum.GetName(typeof(DayOfWeek), dayToShow);
            return wordDayOfTheWeek;
        }
    }
}
