using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeatherViewModel
    {
        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        public string State { get; set; }

        public int Acreage { get; set; }

        public int Elevation { get; set; }

        public int MilesOfTrail { get; set; }

        public int NumberOfCampsites { get; set; }

        public string Climate { get; set; }

        public int YearFounded { get; set; }

        public int AnnualVistorCount { get; set; }

        public string Quote { get; set; }

        public string QuoteSource { get; set; }

        public string ParkDescription { get; set; }

        public decimal EntryFee { get; set; }

        public int NumberOfAnimalSpecies { get; set; }

        public string Image { get; set; }

        public int FiveDayForecast { get; set; }

        public int LowF { get; set; }

        public int HighF { get; set; }

        public string Forecast { get; set; }

        public int LowC { get; set; }

        public int HighC { get; set; }

        public IList<WeatherModel> ForecastList { get; set; }
    }
}
