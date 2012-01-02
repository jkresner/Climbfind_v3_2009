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
    public partial class PlacePicker : ClimbFindControl
    {
        public string ValidationGroup { get; set; }
        public string Mode { get; set; }
        public int SelectedPlaceID { get { return int.Parse(PID.Text); } }

        protected void Page_Init(Object o, EventArgs e)
        {
            PVAL.Group = ValidationGroup;
            PIDVAL.Group = ValidationGroup;
        }
    }
}