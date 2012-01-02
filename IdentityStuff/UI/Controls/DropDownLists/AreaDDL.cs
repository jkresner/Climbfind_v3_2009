using System;
using System.Collections.Generic;
using DropDownListItem = System.Web.UI.WebControls.ListItem;

namespace ClimbFind.Web.UI.Controls.DropDownLists
{
    public class AreaDDL : AbstractDDL
    {
        //public int SelectedPlaceID { get { return int.Parse(SelectedItem.Value); } }
        public string SelectedAreaName { get { return SelectedItem.Text; } }

        protected override void OnInit(EventArgs e)
        {
            List<string> areas = new List<string>();
            areas.Add("England, London & South East");
            areas.Add("England, South West");
            areas.Add("England, Midlands");
            areas.Add("England, Peak District");
            areas.Add("England, North West");
            areas.Add("England, Yorkshire");
            areas.Add("England, Lake District");
            areas.Add("England, North East");
            areas.Add("Wales");
            areas.Add("Scotland");
            areas.Add("Australia");
            areas.Add("USA");
            areas.Add("Ireland");
            areas.Add("Thailand");
            areas.Add("Canada");
            areas.Add("Other");
            
            foreach (string p in areas)
            {
                DropDownListItem item = new DropDownListItem(p, p);
                Items.Add(item);
            }
        }

        private bool ShouldUpdateSearchSettingsPlaceID()
        {
            return UsersSearchSettings.PartnerSearchArea != SelectedAreaName;
        }

        protected void Page_Load(Object src, EventArgs e)
        {
            if (!Page.IsPostBack && UserLoggedIn)
            {
                SelectItem(UsersSearchSettings.PartnerSearchArea); 
            }
        }

        public void SelectItem(string areaName)
        {
            int index = 0;
            foreach (DropDownListItem item in Items)
            {
                if (item.Value == areaName) { SelectedIndex = index; return; }
                index++;
            }
        }

    }
}
