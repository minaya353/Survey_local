namespace Survey.ServiceModels
{
    /// <summary>
    /// This class is used as part of SMRT web server responses to model a single Survey Answer value
    /// obtained from the SMRT DB.
    /// </summary>
    public class TestSurveyAnswer
    {
        public int SurveyQuestionID { get; set; }
        public int Rating { get; set; }
    }
}