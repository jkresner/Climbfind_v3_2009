using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Admin
{
    public partial class ClubsList : ViewPage
    {
        public List<Club> Clubs { get; set; }

        public void Page_Init(Object s, EventArgs e)
        {
            Clubs = new CFController().GetAllClubs();
        }
    }
}
