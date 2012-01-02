using System;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using IdentityStuff.UI;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.UI
{
    public class BaseViewUserControl : ViewUserControl
    {
        public bool UserLoggedIn { get { return Page.User.Identity.IsAuthenticated; } }
        public MembershipUser CFUser { get { return Membership.GetUser(); } }
        public Guid UserID { get { return CFProfile.UserID; } }
        public Page _page { get { return this.Page; } }
        public Control PageHeader { get { return _page.Page.Header; } }

        protected void RedirectTo(string uri)
        {
            Response.Redirect(uri, false);
        }


        public void AddJavaScriptReference(string fileAbsoluteSrc)
        {
            //-- check control hasn't already been added to the page
            foreach (HtmlControl control in PageHeader.Controls)
            {
                if (control.TagName == "script" && control.Attributes["src"] == _page.ResolveClientUrl(fileAbsoluteSrc)) { return; }
            }

            HtmlGenericControl ctr = new HtmlGenericControl("script");
            ctr.Attributes.Add("type", "text/javascript");
            ctr.Attributes.Add("src", _page.ResolveClientUrl(fileAbsoluteSrc));

            PageHeader.Controls.Add(ctr);
        }




        public void AddCSSFileReference(string fileAbsoluteSrc)
        {
            //-- check control hasn't already been added to the page
            foreach (HtmlControl control in PageHeader.Controls)
            {
                if (control.TagName == "link" && control.Attributes["href"] == _page.ResolveClientUrl(fileAbsoluteSrc)) { return; }
            }

            HtmlGenericControl ctr = new HtmlGenericControl("link");
            ctr.Attributes.Add("type", "text/css");
            ctr.Attributes.Add("rel", "stylesheet");
            ctr.Attributes.Add("href", this.Page.ResolveClientUrl(fileAbsoluteSrc));

            PageHeader.Controls.Add(ctr);
        }

    }
}
