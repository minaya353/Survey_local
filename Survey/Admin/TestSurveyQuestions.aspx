<%@ Page Language="C#" MasterPageFile="~/Site.master" Inherits="TestSurveyQuestionsPage" Codebehind="TestSurveyQuestions.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <a id="A1" href="~/Admin/EditTestSurveyQuestion.aspx" runat="server">
        <img id="imgAddNew" src="~/Images/button_add_new.png" alt="Add New" runat="server" />
    </a>
    <br />
    <asp:ValidationSummary ID="validSummary" ValidationGroup="UpdateGroup" runat="server" />
    <asp:GridView ID="gv"
        PageSize="20" AllowPaging="true" AutoGenerateColumns="false"
        OnPageIndexChanging="gv_PageIndexChanging"
        OnRowDeleting="gv_RowDeleting" DataKeyNames="SurveyQuestionID"
        runat="server">
		<PagerSettings Position="Top" Mode="NumericFirstLast" />    
        <EmptyDataTemplate>
			<center><b>Questions were not found.</b></center>
		</EmptyDataTemplate>
        <PagerSettings Position="Top" />
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="Title"
				ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" HeaderText="Title" />

            <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="Text"
				ItemStyle-Width="50%" HeaderStyle-HorizontalAlign="Center" HeaderText="Text" />

            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="IsActive"
				ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderText="Active" />

			<asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" 
			    ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a href='<%#String.Format("{0}?questionid={1}", ResolveUrl("~/Admin/EditTestSurveyQuestion.aspx"), Eval("SurveyQuestionID")) %>'>edit</a>
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="deleteLinkButton" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="delete" OnClientClick="return confirm('Are you sure?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
