using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Enum;

namespace IdentityStuff.Views.Moderate
{
    public partial class AreaTagForCountryTxB : System.Web.Mvc.ViewUserControl
    {
        public Nation Country { get { return (Nation)short.Parse(CID.Value); } set { CID.Value = ((short)value).ToString(); } }
        public int SelectedAreaTagID { get { return AreaID.IntegerValueOrZero; } }
        public string Group { get; set; }

        protected void Page_Load(Object o, EventArgs e)
        {
            if (Country == default(Nation)) { throw new Exception("Country not set"); }
            if (String.IsNullOrEmpty(Group)) { throw new Exception("Area select must have validation group"); }
            else { AreaVAL.Group = Group; }
        }


        public void Clear()
        {
            AreaID.Text = "";

        }
    }
}
