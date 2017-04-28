#region

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

#endregion

namespace Survey.Web.UI
{
    /// <summary>
    /// An extension of default ASP 'Page' class. This provides fields representing user information and user roles. 
    /// It also forwards runtime exceptions to the FSM support email address.
    /// </summary>
    public class Page : System.Web.UI.Page
    {
        public virtual string BackUrl { get; set; }
        protected virtual bool IsEditMode { get; set; }
    }
}