#region

using System;
using Survey.BusinessLogic;

#endregion

/// <summary>
/// This class is the code behind for "~/Admin/EditSurveyQuestion"
/// Permitted user roles: SystemAdmin
/// </summary>
public partial class EditTestSurveyQuestionPage : Survey.Web.UI.Page
{
    private int _surveyQuestionID;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (int.TryParse(Request.Params["questionid"], out _surveyQuestionID))
            IsEditMode = true;

        if (IsEditMode)
        {
            btnAdd.Text = "Update";
        }

        this.BackUrl = ResolveUrl("~/Admin/TestSurveyQuestions.aspx");

        if (!IsPostBack)
        {
            if (IsEditMode)
            {
                TestSurveyQuestion sq = TestSurveyQuestions.GetSurveyQuestion(_surveyQuestionID);
                txtText.Text = sq.Text;
                txtTitle.Text = sq.Title;
                txtTitles.Text = sq.Titles;
                cbActive.Checked = sq.IsActive;
                cbRequired.Checked = sq.IsRequired;
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        TestSurveyQuestion sq = new TestSurveyQuestion();
        sq.Title = txtTitle.Text;
        sq.Text = txtText.Text;
        sq.Titles = txtTitles.Text;
        sq.IsActive = cbActive.Checked;
        sq.IsRequired = cbRequired.Checked;
        if (IsEditMode)
        {
            sq.SurveyQuestionID = _surveyQuestionID;
            TestSurveyQuestions.Update(sq);
        }
        else
        {
            TestSurveyQuestions.Insert(sq);
        }
        Response.Redirect("~/Admin/TestSurveyQuestions.aspx");
    }
}