#region

using System.Collections.Generic;

#endregion

namespace Survey.ServiceModels.Results
{
    /// <summary>
    /// This class represents a web server response for Android / iPhone requests for
    /// a summary of a field tech survey
    /// </summary>
    public class TestSurveyResult : BaseResult
    {
        public List<TestSurveyQuestion> Questions { get; set; }
        public TestSurveyAnswers Answers { get; set; }
    }
}