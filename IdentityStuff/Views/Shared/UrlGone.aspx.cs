using System.Web.Mvc;
using System;

namespace IdentityStuff.Views.Shared
{
    public partial class UrlGone : ViewPage<string>
    {
        protected void Page_Init(object o, EventArgs e)
        {
            Response.Status = "410 Gone";
        }


    }
}
