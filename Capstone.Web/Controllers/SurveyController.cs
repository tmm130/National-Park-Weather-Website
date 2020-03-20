using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyResultDAO dao;
        public SurveyController(ISurveyResultDAO surveyResultDAO)
        {
            this.dao = surveyResultDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }

            try
            {
                bool didItWork = dao.SaveNewSurvey(survey);
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            return View(dao.CountSurveysSorted());
        }
    }
}