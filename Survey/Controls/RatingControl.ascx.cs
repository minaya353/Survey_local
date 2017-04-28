#region

using System;
using System.Web.UI;

#endregion

namespace Survey.Controls
{
    /// <summary>
    /// This class is the code behind for the SMRT custom control : "\Controls\RatingControl.ascx"
    /// </summary>
    public partial class RatingControl : Survey.Web.UI.UserControl
    {
        private bool _required = true;

        public string ToolTips
        {
            get { return Session[this.ID + "_ToolTips"] as string; }
            set { Session[this.ID + "_ToolTips"] = value; }
        }

        public bool ShowComment { get; set; }

        public string ValidationGroup { get; set; }        

        private string[] _toolTipItems = null;

        public string[] ToolTipItems
        {
            get
            {
                if (_toolTipItems == null && !String.IsNullOrEmpty(ToolTips))
                    _toolTipItems = ToolTips.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                return _toolTipItems;
            }
        }

        protected int _value;

        public int? Value
        {
            get
            {
                int value;
                if (int.TryParse(hiddenID.Value, out value))
                    return value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0 && value.Value <= ToolTipItems.Length)
                {
                    hiddenID.Value = value.Value.ToString();
                    spanTitle.InnerHtml = ToolTipItems[value.Value - 1];
                    hiddenTip.Value = ToolTipItems[value.Value - 1];
                    _value = value.Value;
                }
            }
        }

        //public string Comment { get; set; }

        public string OnClientClick { get; set; }
        public bool ReadOnly { get; set; }

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("jquery.rating", ResolveUrl("~/Scripts/jquery.rating.pack.js"));
        }
    }
}