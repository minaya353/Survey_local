#region

using System;
using System.Web.UI;
using Survey.Extensions;

#endregion

namespace Survey.Web.UI
{
    /// <summary>
    /// This extends the ASP class UserControl. It allows the developer to access fields from the Page that this control is placed on. 
    /// </summary>
    public class UserControl : System.Web.UI.UserControl
    {
        public new Page Page
        {
            get { return (Page)base.Page; }
        }

        public virtual void CopyAttributesTo(Control control)
        {
            AttributeCollection attributes = control.GetAttributes();
            if (attributes != null)
            {
                foreach (string key in Attributes.Keys)
                {
                    if (String.IsNullOrEmpty(attributes[key]))
                        attributes.Add(key, Attributes[key]);
                }
            }
        }
    }
}