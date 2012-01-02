using System;
using System.Web.Mvc;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.Home
{
    public partial class Promote : ViewPage
    {
        public string BodyHTML { get; set; }

        public void Page_Init(Object o, EventArgs e)
        {
            BodyHTML = new SpecialPagesHTMLDA().GetByID(6).PageHtml;
        }
    }
}
