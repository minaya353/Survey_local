<%@ Page Language="C#" MasterPageFile="~/Site.master" Inherits="TestSurveyPage" Codebehind="TestSurvey.aspx.cs" %>
<%@ Register TagPrefix="uc" TagName="Rating" Src="~/Controls/RatingControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ValidationSummary ValidationGroup="UpdateGroup" runat="server" />
    <br />
    <!-- Name -->
    <asp:Label AssociatedControlID="txtName" Text="Name:" runat="server" /><br />
    <asp:TextBox ID="txtName" Width="500px" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Email -->
    <asp:Label AssociatedControlID="txtEmail" Text="Email:" runat="server" /><br />
    <asp:TextBox ID="txtEmail" Width="500px" runat="server" />
	<asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Gender -->
    <asp:Label AssociatedControlID="rbGender" Text="Gender:" runat="server" /><br />
    <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Male">Male</asp:ListItem>
        <asp:ListItem Value="Female">Female</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ControlToValidate="rbGender" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Age -->
    <asp:Label AssociatedControlID="txtAge" Text="Age:" runat="server" /><br />
    <asp:TextBox ID="txtAge" Width="500px" runat="server" />
	<asp:RequiredFieldValidator ControlToValidate="txtAge" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <!-- Country -->
    <asp:Label AssociatedControlID="rbCountry" Text="Country:" runat="server" /><br />
    <asp:RadioButtonList ID="rbCountry" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Ireland">Ireland</asp:ListItem>
        <asp:ListItem Value="Other">Other Country</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ControlToValidate="rbCountry" ValidationGroup="UpdateGroup" Text="*" runat="server" />
    <div class="break"></div>

    <asp:Label AssociatedControlID="rptSurveyQuestions" Text="Questions:" runat="server" /><br />
    <asp:Repeater ID="rptSurveyQuestions" OnItemDataBound="rptSurveyQuestions_ItemDataBound" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="hiddenID" Value='<%#Eval("SurveyQuestionID") %>' runat="server" />
                <b><%# Eval("Title") %>:</b> <%# Eval("Text") %><br />
                <uc:Rating ID="rating" ToolTips='<%#Eval("Titles") %>' Required='<%#(bool)Eval("IsRequired") %>' OnClientClick="ratingChanged" ShowComment="false" ValidationGroup="UpdateSurveyGroup" CommentStars="2" runat="server"></uc:Rating>
                <asp:HiddenField ID="hiddenRequired" Value='<%#Eval("IsRequired") %>' runat="server" />
                <asp:PlaceHolder ID="phNotApplicable" Visible='<%#!(bool)Eval("IsRequired") %>' runat="server">
                    <asp:CheckBox ID="cbNotApplicable" Checked="false" Text="Not Applicable" runat="server" />
                </asp:PlaceHolder>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
                <br />
            </SeparatorTemplate>
        </asp:Repeater>
    <div class="break"></div>
    <div class="break"></div>


    <!-- Comment -->
    <asp:Label AssociatedControlID="txtComment" Text="Comment:" runat="server" /><br />
    <asp:TextBox ID="txtComment" TextMode="MultiLine" Width="500px" Height="80px" runat="server" />
    <div class="break"></div>


    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" Text="Add" ValidationGroup="UpdateGroup" runat="server" />
    <input type="button" value="Cancel" onclick="window.location.href='<%= this.BackUrl %>';" />
</asp:Content>


