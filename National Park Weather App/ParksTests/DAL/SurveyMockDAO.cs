using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParksTests.DAL
{
    class SurveyMockDAO : ISurvey
    {
        private List<SurveyModel> surveyList = new List<SurveyModel>()
        {
            new SurveyModel(1,"NP1","test@gmail.com","OH","High"),
            new SurveyModel(2, "NP2", "test2@gmail.com", "CA", "Moderate")
        };

        public int MaxId
        {
            get
            {
                return surveyList.Max(s => s.SurveyId);
            }
        }

        public IList<SurveyModel> GetSurveys()
        {
            return new List<SurveyModel>(surveyList);
        }

        public int TakeSurvey(SurveyModel survey)
        {
            survey.SurveyId = MaxId + 1;
            surveyList.Add(survey);
            return survey.SurveyId;

        }
    }
}
