#region

using System;
using System.Web.UI.WebControls;
using Survey.BusinessLogic;

#endregion

/// <summary>
/// This class is the code behind for "~/Admin/SurveyQuestions"
/// Permitted user role: SystemAdmin
/// </summary>
public partial class TestSurveyQuestionsPage : Survey.Web.UI.Page
{
    protected override void OnInit(EventArgs args)
    {
        base.OnInit(args);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = (int)gv.DataKeys[e.RowIndex].Value;
        TestSurveyQuestions.Delete(id);
        BindData();
    }

    private void BindData()
    {
        gv.DataSource = TestSurveyQuestions.GetSurveyQuestions();
        gv.DataBind();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
}