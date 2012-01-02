using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using DropDownListItem = System.Web.UI.WebControls.ListItem;

namespace IdentityStuff.Controls
{
    public partial class AreaPicker : ClimbFindControl
    {
        public string ValidationGroup { get; set; }
        public int SelectedAreaID { get { return int.Parse(ResultsHD.Value); }  }

        public void SetArea(AreaTag area)
        {
            ResultsHD.Value = area.ID.ToString();
            TxB.Text = area.Name;
        }

        protected void Page_Init(Object o, EventArgs e)
        {

        }
    }
}