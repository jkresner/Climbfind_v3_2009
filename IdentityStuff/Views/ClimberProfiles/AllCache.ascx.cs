using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Controller;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class AllCache : System.Web.Mvc.ViewUserControl
    {
        protected List<ClimberProfile> AllProfiles;
        protected int ColumnWidth = 9;

        protected void Page_Load(Object o, EventArgs e)
        {
            AllProfiles = (from c in new CFController().GetAllProfiles() where !c.IsUnfinished select c).ToList();
        }
    }
}
