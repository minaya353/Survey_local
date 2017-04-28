#region

using System.Collections.Generic;

#endregion

namespace Survey.ServiceModels
{
    /// <summary>
    /// This class is used as part of SMRT web server responses to model Survey Answer values
    /// obtained from the SMRT DB.
    /// </summary>
    public class TestSurveyAnswers
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string SourceUrl { get; set; }
        public List<TestSurveyAnswer> Answers { get; set; }
        public string Comment { get; set; }
    }
}