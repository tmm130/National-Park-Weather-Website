using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace CapstoneTest.IntegrationTests
{
    [TestClass]
    public class ParkTest : npGeekTestInitialize
    {
        [TestMethod]

        public void GetParks_AllParksShouldReturn()
        {
            ParkSqlDAO parkSqlDAO = new ParkSqlDAO(ConnectionString);

            IList<Park> parks = parkSqlDAO.GetAllParks();

            Assert.IsTrue(parks.Count > 0);
        }
    }
}
