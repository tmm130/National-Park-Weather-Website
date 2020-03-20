using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultSqlDAO : ISurveyResultDAO
    {
        private string connectionString;

        public SurveyResultSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<SurveyResult> CountSurveysSorted()
        {
            List<SurveyResult> surveys = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT survey_result.parkCode, parkName, COUNT(*) AS count FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY survey_result.parkCode, parkName ORDER BY count DESC, parkName", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveys.Add(ConvertReaderToSurveyResult(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return surveys;
        }

        public bool SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into survey_result values (@parkCode, @email, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            Survey survey = new Survey();

            survey.Id = Convert.ToInt32(reader["surveyId"]);
            survey.ParkCode = Convert.ToString(reader["parkCode"]);
            survey.Email = Convert.ToString(reader["emailAddress"]);
            survey.State = Convert.ToString(reader["state"]);
            survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);

            return survey;
        }

        private SurveyResult ConvertReaderToSurveyResult(SqlDataReader reader)
        {
            SurveyResult result = new SurveyResult();

            result.ParkCode = Convert.ToString(reader["parkCode"]);
            result.Name = Convert.ToString(reader["parkName"]);
            result.Count = Convert.ToInt32(reader["count"]);

            return result;
        }
    }
}
