using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkModel
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

        public string WeatherChoice { get; set; }

        public IList<WeatherModel> WeatherList { get; set; }

        public ParkModel()
        {
        }

        public ParkModel(string parkCode, string parkName, string state, int acreage, int elevation, int mileOfTrails, int numberOfCampsites, string climate, int yearFounded, int annualVistorCount, string quote, string quoteSource, string parkDescription, decimal entryFee, int numberOfAnimalSpecies)
        {
            ParkCode = parkCode;
            ParkName = parkName;
            State = state;
            Acreage = acreage;
            Elevation = elevation;
            MilesOfTrail = mileOfTrails;
            NumberOfCampsites = numberOfCampsites;
            Climate = climate;
            YearFounded = yearFounded;
            AnnualVistorCount = annualVistorCount;
            Quote = quote;
            QuoteSource = quoteSource;
            ParkDescription = parkDescription;
            EntryFee = entryFee;
            NumberOfAnimalSpecies = numberOfAnimalSpecies;
        }
    }
}
