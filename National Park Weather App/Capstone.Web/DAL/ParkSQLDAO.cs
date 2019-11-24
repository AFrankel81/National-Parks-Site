using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAO : IPark
    {
        private string connectionString;

        public ParkSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parkList = new List<ParkModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM park;", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parkList.Add(MapRowToPark(reader));
                    }

                    return parkList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParkModel GetPark(string parkCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM park WHERE parkCode = @parkCode;", connection);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    return MapRowToPark(reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<WeatherModel> GetWeather(string parkCode, string tempUnit)
        {
            IList<WeatherModel> weatherList = new List<WeatherModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM weather WHERE parkCode = @parkCode;", connection);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        weatherList.Add(MapRowToWeather(reader, tempUnit));
                    }

                    return weatherList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ParkModel MapRowToPark(SqlDataReader reader)
        {
            return new ParkModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVistorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                Quote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToDecimal(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
            };
        }

        private WeatherModel MapRowToWeather(SqlDataReader reader, string tempUnit)
        {
            WeatherModel weather = new WeatherModel();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.FiveDayForecast = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.LowF = Convert.ToInt32(reader["low"]);
            weather.HighF = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);

            if (tempUnit == "c")
            {
                weather.LowC = (int)((Convert.ToInt32(reader["low"]) - 32) / 1.8);
                weather.HighC = (int)((Convert.ToInt32(reader["high"]) - 32) / 1.8);
            }

            return weather;
        }
    }
}
