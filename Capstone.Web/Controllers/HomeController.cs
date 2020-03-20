using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        public IActionResult Index()
        {
            return View(parkDAO.GetAllParks());
        }

        public IActionResult Detail(string parkCode, string unitButton)
        {
            ChangeTemp(unitButton);
            Park park = parkDAO.FindUserParkChoice(parkCode);
            WeatherParkViewModel weatherPark = new WeatherParkViewModel();
            weatherPark.Park = park;
            weatherPark.Weathers = weatherDAO.GetWeatherAssociatedWithPark(parkCode);
            weatherPark.Scale = HttpContext.Session.GetString("Scale");


            return View(weatherPark);
        }

        public void ChangeTemp(string unitButton)
        {
            if(HttpContext.Session.GetString("Scale") == null)
            {
                HttpContext.Session.SetString("Scale", "F");
            }

            if (unitButton != null)
            {
                HttpContext.Session.SetString("Scale", unitButton);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
