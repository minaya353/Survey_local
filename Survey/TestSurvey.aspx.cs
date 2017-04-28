using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Survey.BusinessLogic;
using Survey.Controls;

public partial class TestSurveyPage : Survey.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
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
            CheckBox cbNotApplicable = e.Item.FindControl("cbNotApplicable") as CheckBox;
                                
            if (cbNotApplicable != null)
                cbNotApplicable.InputAttributes["onclick"] =
                    String.Format("$('input name=[{0}]').removeAttr('checked');", rating.ClientID);                
        }
    }

    private List<TestSurveyScore> GetRatings(int answerID)
    {
        List<TestSurveyScore> scores = new List<TestSurveyScore>();

            foreach (RepeaterItem item in rptSurveyQuestions.Items)
            {
                TestSurveyScore score = new TestSurveyScore();
                score.SurveyAnswerID = answerID;

                HiddenField hiddenRequired = item.FindControl("hiddenRequired") as HiddenField;
                if ("False".Equals(hiddenRequired.Value, StringComparison.OrdinalIgnoreCase))
                {
                    CheckBox cbNotApplicable = item.FindControl("cbNotApplicable") as CheckBox;
                    if (cbNotApplicable != null & cbNotApplicable.Checked)
                        continue;
                }

                HiddenField hiddenID = item.FindControl("hiddenID") as HiddenField;
                score.SurveyQuestionID = int.Parse(hiddenID.Value);

                RatingControl rating = item.FindControl("rating") as RatingControl;
                score.Rating = rating.Value ?? 0;
                scores.Add(score);
            }
            
        return scores;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        TestSurveyAnswer newAnswer = new TestSurveyAnswer();
        newAnswer.Name = txtName.Text.Trim();
        newAnswer.Email = txtEmail.Text.Trim();
        newAnswer.Age = Convert.ToInt32(txtAge.Text.Trim());
        newAnswer.Gender = rbGender.SelectedItem.Value;
        newAnswer.Country = rbCountry.SelectedItem.Value;
        newAnswer.Comment = txtComment.Text.Trim();
        TestSurveyAnswers.Insert(newAnswer);

        List<TestSurveyScore>  scores = GetRatings(newAnswer.SurveyAnswerID);
        TestSurveyScores.Insert(scores);

        Response.Redirect("~/ThanksPage.aspx");            
    }        
}
