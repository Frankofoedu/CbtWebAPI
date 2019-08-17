using rating.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CBTWebAPI.Models
{
    public class Result
    {
        public string Id { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Centre { get; set; }

        [Display(Name ="Total Score")]
        public int CorrectANswers { get; set; }

        public static IEnumerable<Result> GetAllResults(CBTWebAPIContext db)
        {
            var answers = db.UserAnswers.ToList();

           return answers.Select(m => new Result { Email = m.User.Email, FullName = m.User.FullName, PhoneNumber = m.User.PhoneNumber, Centre = m.User.Centre, CorrectANswers = m.QuestionAndAnswers.Where(x => x.Answer == x.CorrectAnswer).Count() });
        }
    }
}