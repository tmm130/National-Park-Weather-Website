using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CapstoneTest
{
    [TestClass]
    public class ParkSeleniumTest
    {
        private static IWebDriver webDriver;

        [TestInitialize]
        public void TestInit()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Navigate().GoToUrl(TestHelper.URL);
        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }

        [TestMethod]

        public void elements_can_be_found_by_id()
        {
            IWebElement parklist = webDriver.FindElement(By.Id("x1"));
            IWebElement image = webDriver.FindElement(By.ClassName("image"));
            IWebElement park = webDriver.FindElement(By.ClassName("image"));
            IWebElement description = webDriver.FindElement(By.ClassName("description"));
            Assert.IsNotNull(parklist);
            Assert.IsNotNull(image);
            Assert.IsNotNull(park);
            Assert.IsNotNull(description);
        }
        [TestMethod]

        public void single_elements_can_be_found_by_tag_name()
        {
            IWebElement header = webDriver.FindElement(By.TagName("header"));
            IWebElement footer = webDriver.FindElement(By.TagName("footer"));
            Assert.IsNotNull(header);
            Assert.IsNotNull(footer);
        }

        [TestMethod]

        public void pages_can_be_navigated_by_clicking_on_surveyLink()
        {
            IWebElement surveyLink = webDriver.FindElement(By.LinkText("Survey"));
            surveyLink.Click();

            Assert.IsNotNull(surveyLink);
            IWebElement h2 = webDriver.FindElement(By.TagName("h2"));
            Assert.AreEqual("Detail", h2.Text);

        }
        [TestMethod]
        public void forms_can_be_edited_and_submitted()
        {
            IWebElement surveyLink = webDriver.FindElement(By.LinkText("Survey"));
            surveyLink.Click();

            IWebElement homeLink = webDriver.FindElement(By.LinkText("Home"));
            homeLink.Click();

            SelectElement nationalPark = new SelectElement(webDriver.FindElement(By.Name("Favorite National Park")));
            nationalPark.SelectByText("Yosemite National Park");

            IWebElement emailField = webDriver.FindElement(By.Name("Email Address"));
            emailField.SendKeys("DanTom@Capstone.net");

            SelectElement stateOfResidence = new SelectElement(webDriver.FindElement(By.Name("State of Residence")));
            stateOfResidence.SelectByText("PA");

            List<string> activityFieldDropDown = new List<string>() { "Inactive", "Sedentary", "Active", "Extremely Active" };
            IList<IWebElement> activityDropDownList = webDriver.FindElements(By.CssSelector("Activity Level"));
            

            IWebElement activityField = webDriver.FindElement(By.ClassName("Activity Level"));
            activityField.Click();

            IWebElement submitButton = webDriver.FindElement(By.ClassName("formSubmittButton"));
            submitButton.Click();

            IWebElement returnHomeLink = webDriver.FindElement(By.Name("Home"));
            returnHomeLink.Click();

            webDriver.Navigate().GoToUrl("http://google.com");

            webDriver.Navigate().GoToUrl(TestHelper.URL);


        }

    }
}
