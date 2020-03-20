using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace CapstoneTest.IntegrationTests
{
    [TestClass]
    public class npGeekTestInitialize
    {

        protected TransactionScope transaction;

        protected string ConnectionString
        {
            get
            {
                return "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";
            }
        }

        protected string parkName = "Kruger National Park";
        protected string parkCode = "KNP";
        protected string state = "Texas";
        protected int acreage = 45678;
        protected int elevationInFeet = 8000;
        protected int milesOfTrail = 150;
        public int numberOfCampsites = 20;
        public string climate = "Rainforest";
        protected int yearFounded = 1986;
        protected long annualVisitorCount = 25250;
        protected string inspirationalQuote = "Break it Down";
        protected string inspirationalQuoteSource = "Tom Anderson";
        protected string parkDescription = "Tech Elevator is a coding Bootcamp School";
        protected int entryFee = 10;
        protected int numberOfAnimalSpecies = 500;
        protected int surveyId = 7;
        protected string emailAddress = "TomDan@tech.net";
        protected string activitylevel = "Slightly Active";
        protected int fiveDayForecastValue = 5;
        protected int lowTemp = 25;
        protected int highTemp = 76;
        protected string forecast = "partly raining";



        [TestInitialize]

        public void Setup()
        {
            transaction = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand($"select count(*) from park where parkCode = '{parkCode}'", conn);

                if (Convert.ToInt32(sqlCommand.ExecuteScalar()) == 0)
                {
                    string commandText = $"insert into park values('{parkCode}', '{parkName}', '{state}', {acreage}, {elevationInFeet}, {milesOfTrail}, {numberOfCampsites}, '{climate}', {yearFounded}, {annualVisitorCount}, '{inspirationalQuote}', '{inspirationalQuoteSource}', '{parkDescription}', {entryFee}, {numberOfAnimalSpecies});";
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.ExecuteNonQuery();
                }

                sqlCommand = new SqlCommand($"select count(*) from weather where parkCode = (select parkCode from park where parkCode = '{parkCode}')", conn);
                if (Convert.ToInt32(sqlCommand.ExecuteScalar()) == 0) 
                {
                    string commandText = $"insert into weather values('{parkCode}', {fiveDayForecastValue}, {lowTemp}, {highTemp}, '{forecast}');";
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.ExecuteNonQuery();
                }

                sqlCommand = new SqlCommand($"select count(*) from survey_result where parkCode = (select parkCode from park where parkCode = '{parkCode}')", conn);
                if (Convert.ToInt32(sqlCommand.ExecuteScalar()) == 0)
                {
                    string commandText = $"insert into survey_result values('{parkCode}', '{emailAddress}', '{state}', '{activitylevel}');";
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.ExecuteNonQuery();
                }




            }
        }
        [TestCleanup]

        public void CleanUp()
        {
            transaction.Dispose();
        }

    }
}
