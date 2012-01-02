using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using DropDownListItem = System.Web.UI.WebControls.ListItem;


namespace IdentityStuff.Views.Moderate
{
    public partial class EditAreaTags : ClimbFindViewPage<Place>
    {
        public Place place { get { return ViewData.Model; } }
        public List<AreaTag> AreaTags { get; set; }
        public List<AreaTag> AllAreas { get; set; }

        protected void Page_Init(Object sender, EventArgs e)
        {
            AllAreas = (from c in cfController.GetAllAreaTags() orderby c.Name select c).ToList();
            AreaTags = cfController.GetAreaTagsForAPlace(place.ID);
        }

        public void Page_Load(Object sender, EventArgs e)
        {          
            if (!Page.IsPostBack)
            {
                NameLb.Text = place.Name;
                BindAreasPlaces();
            }
        }

        protected void DeletePlaceArea_Click(Object sender, CommandEventArgs e)
        {
            int areaTagID = int.Parse(e.CommandArgument.ToString());
            new PlaceDA().DeletePlaceArea(place.ID, areaTagID);
            
            BindAreasPlaces();
        }

        public void AddPlaceArea_Click(Object sender, EventArgs e)
        {
            int areaTagID = int.Parse(AreaDDLUC.SelectedItem.Value);
            new PlaceDA().InsertPlaceArea(place.ID, areaTagID);

            BindAreasPlaces();
        }

        protected void BindAreasPlaces()
        {
            foreach (AreaTag tag in AllAreas)
            {
                if ( (from c in AreaTags where c.ID == tag.ID select c).Count() == 0) 
                { 
                    AreaDDLUC.Items.Add( new DropDownListItem( tag.Name, tag.ID.ToString()) ); }
            }

            AreaTagsLV.DataSource = AreaTags;
            DataBind();
        }

    }
}
