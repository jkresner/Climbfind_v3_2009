using System;
using System.Linq;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using DropDownListItem = System.Web.UI.WebControls.ListItem;
using System.Collections.Generic;
using ClimbFind.Content;
using ClimbFind.Model.Enum;
using ClimbFind.Controller;

namespace ClimbFind.Web.UI.Controls.DropDownLists
{
    public class AreaTagDDL : AbstractDDL
    {
        public int SelectedAreaTagID { get { return int.Parse(SelectedItem.Value); } }
        public string SelectedAreaName { get { return SelectedItem.Text; } }

        public bool UserIsModerator
        {
            get { if (!UserLoggedIn) { return false; }
                else { return new CFController().GetClimberProfile(UserID).IsModerator; }
            }
        }
    
        protected override void OnInit(EventArgs e)
        {       
            List<AreaTag> sortedTags;

            //-- Show countries also for Kev
            if (UserIsModerator) { sortedTags = (from c in CFDataCache.AllAreaTags orderby c.CountryID select c).ToList(); } 
            else { sortedTags = (from c in CFDataCache.AllAreaTags where !c.IsCountry orderby c.CountryID select c).ToList(); }
            
            foreach (AreaTag tag in sortedTags)
            {
                DropDownListItem item = new DropDownListItem(string.Format("{0}: {1}", 
                    FlagList.GetCountryName((Nation)tag.CountryID), tag.FriendlyUrlName), tag.ID.ToString());
                Items.Add(item);
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
