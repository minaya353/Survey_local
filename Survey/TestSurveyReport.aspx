<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestSurveyReport.aspx.cs" Inherits="TestSurveyReportPage" %>

<%@ Register TagPrefix="uc" TagName="Rating" Src="~/Controls/RatingControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td colspan="2">
                <asp:Label AssociatedControlID="lblSurveyNumbers" Text="Total Surveys:" runat="server" /><br />
                <asp:Label ID="lblSurveyNumbers" Width="500px" runat="server"></asp:Label>
                <div class="break"></div>
            </td>
        </tr>
        <tr>
            <!-- Gender -->
            <td>
                <asp:Label AssociatedControlID="lblMaleAve" Text="Male:" runat="server" /><br />
                <asp:Label ID="lblMaleAve" Width="250px" runat="server"></asp:Label>
                <div class="break"></div>
            </td>
            <td>
                <asp:Label AssociatedControlID="lblFemaleAve" Text="Female:" runat="server" /><br />
                <asp:Label ID="lblFemaleAve" Width="250px" runat="server"></asp:Label>
                <div class="break"></div>
            </td>
        </tr>
        <tr>
            <!-- Age -->
            <td colspan="2">
                <asp:Label AssociatedControlID="lblAgeAve" Text="Age Ave:" runat="server" /><br />
                <asp:Label ID="lblAgeAve" Width="500px" runat="server" />
                <div class="break"></div>
            </td>
        </tr>
        <tr>
            <!-- Country -->
            <td>
                <asp:Label AssociatedControlID="lblIreland" Text="Ireland:" runat="server" /><br />
                <asp:Label ID="lblIreland" Width="250px" runat="server"></asp:Label>
                <div class="break"></div>
            </td>
            <td>
                <asp:Label AssociatedControlID="lblOther" Text="Other:" runat="server" /><br />
                <asp:Label ID="lblOther" Width="250px" runat="server"></asp:Label>
                <div class="break"></div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label AssociatedControlID="rptSurveyQuestions" Text="Questions:" runat="server" /><br />
                <asp:Repeater ID="rptSurveyQuestions" OnItemDataBound="rptSurveyQuestions_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenID" Value='<%#Eval("SurveyQuestionID") %>' runat="server" />
                        <b><%# Eval("Title") %>:</b> <%# Eval("Text") %><br />
                        <uc:Rating ID="rating" ToolTips='<%#Eval("Titles") %>' ReadOnly="true" CommentStars="0" ValidationGroup="UpdateSurveyGroup" runat="server"></uc:Rating>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
                <div class="break"></div>
                <div class="break"></div>
            </td>
        </tr>
    </table>
</asp:Content>
