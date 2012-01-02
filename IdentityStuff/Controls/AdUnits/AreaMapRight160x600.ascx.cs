using System;

using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
namespace ClimbFind.Web.Mvc.Controls.AdUnits
{
    public partial class AreaMapRight160x600 : System.Web.Mvc.ViewUserControl
    {
        public AreaTag Area { get; set; }
        public bool AreaisLondon { get { return Area.ID == 1; } }

        protected void Page_Load(object o, EventArgs e)
        {
            if (Area == null) { throw new Exception("Cannot run ad without area specified"); }
        }
    }
}
