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
    public class TestSurveyScores
    {
        public static bool Insert(TestSurveyScore score)
        {
            using (DALDataContext db = new DALDataContext())
            {
                db.TestSurveyScores.InsertOnSubmit(score);
                db.SubmitChanges();
                return true;
            }
        }

        public static void Insert(List<TestSurveyScore> scores)
        {
            using (DALDataContext db = new DALDataContext())
            {
                foreach (TestSurveyScore r in scores)
                {
                    db.TestSurveyScores.InsertOnSubmit(r);
                }
                db.SubmitChanges();
            }
        }

        public static double AveScore(int questionID)
        {
            using (DALDataContext db = new DALDataContext())
            {
                double total = db.TestSurveyScores.Where(x => x.SurveyQuestionID == questionID).Select(x => x.ID).Count();
                double totalScore = db.TestSurveyScores.Where(x => x.SurveyQuestionID == questionID).Select(x => x.Rating).Sum();
                return Math.Round(totalScore / total, 0);                
            }
        }
    }
}