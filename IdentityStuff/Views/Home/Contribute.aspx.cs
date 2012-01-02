using System;
using ClimbFind.Model.DataAccess;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Objects;


namespace IdentityStuff.Views.Home
{
    public partial class Contribute : ClimbFindViewPage<ISessionViewData>
    {
        public string BodyHTML { get; set; }

        public void Page_Init(Object o, EventArgs e)
        {
            BodyHTML = new SpecialPagesHTMLDA().GetByID(5).PageHtml;
        }   
    }
}
