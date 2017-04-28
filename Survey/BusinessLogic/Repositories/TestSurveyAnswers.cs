#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Survey.BusinessLogic
{
    /// <summary>
    /// This class handles standard CRUD functionalities of DB object SurveyQuestions
    /// </summary>
    public class TestSurveyAnswers
    {
        public static int TotalSurvey()
        {
            using (DALDataContext db = new DALDataContext())
            {
                return db.TestSurveyAnswers.Count();
            }
        }

        public static int TotalMaleSurvey()
        {
            using (DALDataContext db = new DALDataContext())
            {
                return db.TestSurveyAnswers.Where(x => x.Gender == "Male").Select(x => x.SurveyAnswerID).Count();
            }
        }

        public static int TotalFemaleSurvey()
        {
            using (DALDataContext db = new DALDataContext())
            {
                return db.TestSurveyAnswers.Where(x => x.Gender == "Female").Select(x => x.SurveyAnswerID).Count();
            }
        }

        public static int TotalIrelandSurvey()
        {
            using (DALDataContext db = new DALDataContext())
            {
                return db.TestSurveyAnswers.Where(x => x.Country == "Ireland").Select(x => x.SurveyAnswerID).Count();
            }
        }

        public static int TotalOtherCountrySurvey()
        {
            using (DALDataContext db = new DALDataContext())
            {
                return db.TestSurveyAnswers.Where(x => x.Country == "Other").Select(x => x.SurveyAnswerID).Count();
            }
        }

        public static double AgeAve(double total)
        {
            using (DALDataContext db = new DALDataContext())
            {
                double result = Math.Round(db.TestSurveyAnswers.Sum(x => x.Age) / total, 2);
                return result;
            }
        }

        public static bool Insert(TestSurveyAnswer surveyAnswer)
        {
            using (DALDataContext db = new DALDataContext())
            {
                db.TestSurveyAnswers.InsertOnSubmit(surveyAnswer);
                db.SubmitChanges();
                return true;
            }
        }
    }
}