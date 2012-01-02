using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Helpers;
using IdentityStuff.Controls;

namespace IdentityStuff.Views.Places
{
    public partial class OutdoorMapCache : System.Web.Mvc.ViewUserControl
    {
        public List<Place> OutdoorPlaces { get; set; }

        protected void Page_Init(object o, EventArgs e)
        {
            OutdoorPlaces = (from c in CFDataCache.AllPlaces where !c.IsIndoor select c).ToList();
        }
    }
}
