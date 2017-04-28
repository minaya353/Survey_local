<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatingControl.ascx.cs" Inherits="Survey.Controls.RatingControl" %>
<% if (ToolTipItems != null)
   { %>
    <% for (int i = 0; i < ToolTipItems.Length; i++)
       { %>
        <input name="<%= this.ClientID %>" <%= (this._value == i + 1 ? "checked=\"checked\"" : "") %> class="<%= this.ClientID %>-hover-star" type="radio" value="<%= (i + 1) %>" title="<%= ToolTipItems[i] %>"/>
    <% } %>
<% } %>
<input id="hiddenID" type="hidden" runat="server" />
<input id="hiddenTip" type="hidden" runat="server" />
<span id="spanTitle" style="margin: 0 0 0 20px;" runat="server"></span>
<script type="text/javascript">
    $(function () {
        $('.<%= this.ClientID %>-hover-star').rating({
            required: <%= Required.ToString().ToLower() %>,
            readOnly: <%= ReadOnly.ToString().ToLower() %>,
            callback: function (value, link) {
                $('#<%= hiddenID.ClientID %>').val(value || '');
                $('#<%= hiddenTip.ClientID %>').val(link.title || '');
                <%= String.IsNullOrEmpty(OnClientClick) ? String.Empty : String.Format("{0}.call({{ id: '{1}', value: value }});", OnClientClick, this.ClientID) %>
            },
            focus: function (value, link) {
                var tip = $('#<%= spanTitle.ClientID %>');
                tip.html(link.title || 'value: ' + value);
            },
            blur: function (value, link) {
                $('#<%= spanTitle.ClientID %>').html($('#<%= hiddenTip.ClientID %>').val());
            }
        });
    });
</script>