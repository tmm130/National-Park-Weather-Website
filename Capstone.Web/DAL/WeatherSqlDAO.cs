using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString;

       

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        

        public IList<WeatherModel> GetWeatherAssociatedWithPark(string parkCode)
        {
            IList<WeatherModel> weathers = new List<WeatherModel>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from weather where parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        var weather = new WeatherModel()
                        {
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            LowTemp = Convert.ToInt32(reader["low"]),
                            HighTemp = Convert.ToInt32(reader["high"]),
                            ForeCast = Convert.ToString(reader["forecast"])
                        };
                        weathers.Add(weather);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

            return weathers;
        }

       
    }
}
