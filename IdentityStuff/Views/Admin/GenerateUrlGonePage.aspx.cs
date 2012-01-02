using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Controller;


namespace IdentityStuff.Views.Admin
{
    public partial class GenerateUrlGonePage : ViewPage
    {
        protected void Page_Init(Object o, EventArgs e)
        {
        }

        protected void Page_Load(Object o, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Html.RenderUserControl("~/Views/Shared/Head.ascx"));
            sb.Append("<body>");
            sb.Append(this.Html.RenderUserControl("~/Views/Shared/Header.ascx"));
            sb.Append(@"<div id=""content-wrap"" style=""background-image:none""><div id=""content"">");
            sb.Append(this.Html.RenderUserControl("~/Views/Shared/UrlGonePageBody.ascx"));
            sb.Append(@"</div></div><hr style=""height:0px"" />");
            sb.Append(this.Html.RenderUserControl("~/Views/Shared/Footer.ascx"));
            sb.Append("</body>");

            StreamWriter tw = new StreamWriter(Server.MapPath("~/"+"410UrlGone.html"));
            tw.WriteLine(sb.ToString());
            tw.Close();

            PageLtr.Text = sb.ToString();
        }    
    }

}

