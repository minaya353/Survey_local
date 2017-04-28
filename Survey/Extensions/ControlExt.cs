#region

using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

#endregion

namespace Survey.Extensions
{
    /// <summary>
    /// Extension methods for custom controls.
    /// </summary>
    public static class ControlExt
    {
        public static Control GetControl(this Control control, string id)
        {
            if (control == null)
                return null;

            if (id.Equals(control.ID, StringComparison.OrdinalIgnoreCase))
                return control;

            foreach (Control c in control.Controls)
            {
                if ((control = c.GetControl(id)) != null)
                    return control;
            }
            return null;
        }

        public static string ToHtml(this Control c)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter htmlwr = new HtmlTextWriter(sw))
                {
                    c.RenderControl(htmlwr);
                    return sb.ToString();
                }
            }
        }

        public static string GetAttributeValue(this Control control, string key)
        {
            if (control == null)
                return null;

            AttributeCollection attributes = control.GetAttributes();
            if (attributes != null)
                return attributes[key];

            return null;
        }

        public static AttributeCollection GetAttributes(this Control control)
        {
            if (control == null)
                return null;

            if (control is WebControl)
            {
                WebControl c = control as WebControl;
                return c.Attributes;
            }

            if (control is HtmlControl)
            {
                HtmlControl c = control as HtmlControl;
                return c.Attributes;
            }

            if (control is UserControl)
            {
                UserControl c = control as UserControl;
                return c.Attributes;
            }
            return null;
        }
    }
}