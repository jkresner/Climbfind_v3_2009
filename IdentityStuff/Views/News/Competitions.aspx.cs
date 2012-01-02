using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.News
{
    public partial class Competitions : ViewPage
    {
        public List<Competition> Comps { get; set; }

        public void Page_Init(Object o, EventArgs e)
        {
            Comps = new CompetitionDA().GetAll();
            Comps.Reverse();
        }
    }
}
