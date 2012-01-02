﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Helpers;

namespace IdentityStuff.Views.Places
{
    public partial class WorldMapCache : System.Web.Mvc.ViewUserControl
    {
        public List<Place> Places { get; set; }

        protected void Page_Init(object o, EventArgs e)
        {
            Places = CFDataCache.AllPlaces;
        }
    }
}
