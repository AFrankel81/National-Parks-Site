using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "Please Select a National Park")]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "Please Select a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Prompt = "Enter Email Here")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please Select Your Level of Activity")]
        public string ActivityLevel { get; set; }

        public SelectList ParkList { get; set; }

        public int TotalCount { get; set; }

        public string ParkName { get; set; }

        public SurveyModel()
        {
        }

        public SurveyModel(int surveyId, string parkCode, string emailAddress, string state, string activityLevel)
        {
            SurveyId = surveyId;
            ParkCode = parkCode;
            EmailAddress = emailAddress;
            State = state;
            ActivityLevel = activityLevel;
        }
    }
}
