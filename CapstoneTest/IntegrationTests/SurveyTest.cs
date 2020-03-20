using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTest.IntegrationTests
{
    [TestClass]
    public class SurveyTest : npGeekTestInitialize
    {
        [TestMethod]
        public void SurveysCounted_ShouldReturnAllSurveysCounted()
        {
            SurveyResultSqlDAO surveyResultSqlDAO = new SurveyResultSqlDAO(ConnectionString);

            IList<SurveyResult> surveyResults = surveyResultSqlDAO.CountSurveysSorted();

            Assert.IsTrue(surveyResults.Count > 0);
        }

        [TestMethod]
        public void SaveNewSurveyShouldResultInTrueIfItWorks()
        {
            SurveyResultSqlDAO surveyResultSqlDAO = new SurveyResultSqlDAO(ConnectionString);
            Survey survey = new Survey();
            survey.ParkCode = parkCode;
            survey.Email = emailAddress;
            survey.State = state;
            survey.ActivityLevel = activitylevel;

            bool result = surveyResultSqlDAO.SaveNewSurvey(survey);

            Assert.AreEqual(true, result);

            Survey badSurvey = new Survey();
            survey.ActivityLevel = activitylevel;
            survey.State = null;

            bool badResult = surveyResultSqlDAO.SaveNewSurvey(survey);

            Assert.AreEqual(false, badResult);
        }
    }
}
