using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Survey.BusinessLogic;
using Survey.Controls;

public partial class TestSurveyReportPage : Survey.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        double totalSurvey = TestSurveyAnswers.TotalSurvey();
        lblSurveyNumbers.Text = totalSurvey.ToString();
        lblMaleAve.Text = Math.Round(TestSurveyAnswers.TotalMaleSurvey() / totalSurvey, 2).ToString("p");
        lblFemaleAve.Text = Math.Round(TestSurveyAnswers.TotalFemaleSurvey() / totalSurvey, 2).ToString("p");
        lblIreland.Text = Math.Round(TestSurveyAnswers.TotalIrelandSurvey() / totalSurvey, 2).ToString("p");
        lblOther.Text = Math.Round(TestSurveyAnswers.TotalOtherCountrySurvey() / totalSurvey, 2).ToString("p");
        lblAgeAve.Text = TestSurveyAnswers.AgeAve(totalSurvey).ToString();

        BindSurveyQuestions();
    }

    private void BindSurveyQuestions()
    {
        if (!IsPostBack)
        {
            rptSurveyQuestions.DataSource = TestSurveyQuestions.GetSurveyQuestions(true);
            rptSurveyQuestions.DataBind();
        }
    }

    protected void rptSurveyQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int? surveyQuestionID = DataBinder.Eval(e.Item.DataItem, "SurveyQuestionID") as int?;
        if (surveyQuestionID.HasValue)
        {
            RatingControl rating = e.Item.FindControl("rating") as RatingControl;
            rating.Value = (int)TestSurveyScores.AveScore(surveyQuestionID.Value);
        }
    }
}
