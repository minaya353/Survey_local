#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace EP.ServiceModels
{
    /// <summary>
    /// This class is used as part of SMRT web server responses to model Survey Question values
    /// obtained from the SMRT DB.
    /// </summary>
    public class TestSurveyQuestion
    {
        public int SurveyQuestionID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsRequired { get; set; }
        public string[] ToolTips { get; set; }
        public Dictionary<int, string> ToolTipsList { get; set; }

        public TestSurveyQuestion()
        {
        }

        public TestSurveyQuestion(EP.BusinessLogic.TestSurveyQuestion sq)
        {
            SurveyQuestionID = sq.SurveyQuestionID;
            Title = sq.Title;
            Text = sq.Text;
            IsRequired = sq.IsRequired;
            ToolTips = sq.Titles.Split(',');
            ToolTipsList = ToolTips.Select((v, k) => new { Key = k + 1, Value = v })
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}