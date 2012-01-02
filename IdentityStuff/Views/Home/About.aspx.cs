using System;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Web.UI.Controls.DropDownLists;
using System.Web.Mvc;

namespace IdentityStuff.Views.Home
{
    public partial class About : ViewPage
    {
        public bool UserLoggedIn { get { return this.User.Identity.IsAuthenticated; } }
        
        protected void Page_Init(Object s, EventArgs e)
        {
        }
    }

}