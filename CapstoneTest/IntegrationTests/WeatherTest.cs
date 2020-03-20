using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTest.IntegrationTests
{
    [TestClass]
    public class WeatherTest : npGeekTestInitialize
    {
        [TestMethod]
        public void GetWeather_ShouldReturnAllWeathersAssociatedwithPark()
        {
            WeatherSqlDAO weatherSqlDAO = new WeatherSqlDAO(ConnectionString);

            IList<WeatherModel> weathers = weatherSqlDAO.GetWeatherAssociatedWithPark(parkCode);

            Assert.IsTrue(weathers.Count > 0);
        }
    }
}
