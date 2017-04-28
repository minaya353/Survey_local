<%@ Page Language="C#" MasterPageFile="~/Site.master" Inherits="EditTestSurveyQuestionPage" Codebehind="EditTestSurveyQuestion.aspx.cs" %>


<asp:Content ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ValidationSummary ValidationGroup="UpdateGroup" runat="server" />

    <!-- Title -->
    <asp:Label AssociatedControlID="txtTitle" Text="Title:" runat="server" /><br />
    <asp:TextBox ID="txtTitle" Width="500px" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="txtTitle" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Text -->
    <asp:Label AssociatedControlID="txtText" Text="Text:" runat="server" /><br />
    <asp:TextBox ID="txtText" TextMode="MultiLine" Width="500px" Height="80px" runat="server" />
	<asp:RequiredFieldValidator runat="server"
		ControlToValidate="txtText" ValidationGroup="UpdateGroup"
		ErrorMessage="The Text field is required." Text="*" Display="Dynamic" 
		Font-Size="12px" />
    <div class="break"></div>

    <!-- Titles -->
    <asp:Label AssociatedControlID="txtTitles" Text="Tips:" runat="server" /><br />
    <asp:TextBox ID="txtTitles" Width="500px" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="txtTitles" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Active -->
    <asp:CheckBox ID="cbActive" Text="Active" Checked="true" runat="server" />
    <div class="break"></div>

    <!-- Required -->
    <asp:CheckBox ID="cbRequired" Text="Required" Checked="true" runat="server" />
    <div class="break"></div>

    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" Text="Add" ValidationGroup="UpdateGroup" runat="server" />
    <input type="button" value="Cancel" onclick="window.location.href='<%= this.BackUrl %>';" />
</asp:Content>

