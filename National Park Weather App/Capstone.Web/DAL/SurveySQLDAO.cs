using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAO:ISurvey
    {
        private string connectionString;

        public SurveySQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<SurveyModel> GetSurveys()
        {
            IList<SurveyModel> surveyList = new List<SurveyModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"select count(p.parkCode) TotalCount, p.parkName ParkName, p.parkCode from survey_result sr join park p on sr.parkCode = p.parkCode group by p.parkName, p.parkCode order By count(p.parkCode) DESC", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveyList.Add(MapRowToSurvey2(reader));
                    }

                    return surveyList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int TakeSurvey(SurveyModel survey)
        {
            string parkCode = survey.ParkCode;
            string emailAddress = survey.EmailAddress;
            string state = survey.State;
            string activityLevel = survey.ActivityLevel;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into survey_result (parkCode, emailAddress, state, activityLevel) Values (@parkCode, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", emailAddress);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@activityLevel", activityLevel);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SurveyModel MapRowToSurvey(SqlDataReader reader)
        {
            return new SurveyModel()
            {
                SurveyId = Convert.ToInt32(reader["surveyId"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                EmailAddress = Convert.ToString(reader["emailAddress"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel = Convert.ToString(reader["activityLevel"]),
            };
        }

        private SurveyModel MapRowToSurvey2(SqlDataReader reader)
        {
            return new SurveyModel()
            {
                TotalCount = Convert.ToInt32(reader["TotalCount"]),
                ParkName = Convert.ToString(reader["ParkName"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
            };
        }
    }
}
