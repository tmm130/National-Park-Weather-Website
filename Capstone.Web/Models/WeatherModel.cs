using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        [Display(Name = "High Temperatue")]
        public int HighTemp { get; set; }
        public int HighTempCelsius
        {
            get
            {
                return ConvertToCelcius(HighTemp);
            }
        }

        public int LowTempCelsius
        {
            get
            {
                return ConvertToCelcius(LowTemp);
            }
        }

        [Display(Name = "Low Temperature")]
        public int LowTemp { get; set; }

        [Display(Name = "Day of the week:")]
        public int FiveDayForecastValue { get; set; }

        [Display(Name = "Forecast")]
        public string ForeCast { get; set; }

        public string ParkCode { get; set; }
        public IList<WeatherModel> Weathers { get; set; }

        private int ConvertToCelcius(int temp)
        {
            return (int)Math.Round((temp - 32) * 5.0 / 9);
        }
    }
}
