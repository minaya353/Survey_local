#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Survey.BusinessLogic
{
    /// <summary>
    /// This class handles standard CRUD functionalities of DB object SurveyQuestions
    /// </summary>
    public class TestSurveyQuestions
    {
        public static List<TestSurveyQuestion> GetSurveyQuestions(bool onlyActive = false)
        {
            using (DALDataContext db = new DALDataContext())
            {
                return (from sq in db.TestSurveyQuestions
                        where !onlyActive || (onlyActive && sq.IsActive == true)
                        select sq).ToList();
            }
        }

        public static TestSurveyQuestion GetSurveyQuestion(int sqID)
        {
            using (DALDataContext db = new DALDataContext())
            {
                return (from sq in db.TestSurveyQuestions
                        where sq.SurveyQuestionID == sqID
                        select sq).SingleOrDefault();
            }
        }

        public static bool Update(TestSurveyQuestion surveyQuestion)
        {
            using (DALDataContext db = new DALDataContext())
            {
                TestSurveyQuestion dbSq =
                    db.TestSurveyQuestions.SingleOrDefault(sq => sq.SurveyQuestionID == surveyQuestion.SurveyQuestionID);
                if (dbSq == null)
                    return false;

                dbSq.Title = surveyQuestion.Title;
                dbSq.Text = surveyQuestion.Text;
                dbSq.IsActive = surveyQuestion.IsActive;
                dbSq.IsRequired = surveyQuestion.IsRequired;
                dbSq.Titles = surveyQuestion.Titles;
                db.SubmitChanges();
                return true;
            }
        }

        public static bool Insert(TestSurveyQuestion surveyQuestion)
        {
            using (DALDataContext db = new DALDataContext())
            {
                db.TestSurveyQuestions.InsertOnSubmit(surveyQuestion);
                db.SubmitChanges();
                return true;
            }
        }

        public static bool Delete(int surveyQuestionID)
        {
            using (DALDataContext db = new DALDataContext())
            {
                TestSurveyQuestion dbSq = db.TestSurveyQuestions.SingleOrDefault(sq => sq.SurveyQuestionID == surveyQuestionID);
                if (dbSq == null)
                    return false;

                db.TestSurveyQuestions.DeleteOnSubmit(dbSq);
                db.SubmitChanges();
                return true;
            }
        }
    }
}