using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditIndoorPlace : ClimbFindViewPage<IndoorPlace>
    {
        public IndoorPlace place { get { return ViewData.Model; } }
        public List<AreaTag> AreaTags { get; set; }

        protected void Page_Init(Object sender, EventArgs e)
        {
            AreaTags = cfController.GetAreaTagsForAPlace(place.ID);
            AreaTxB.Country = (ClimbFind.Model.Enum.Nation)place.CountryID;
        }

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NameLb.Text = place.Name;
                DescriptionTxB.Text = place.Description;
                LatitudeTxB.DoubleValue = (double)place.Latitude;
                LongitudeTxB.DoubleValue = (double) place.Longitude;                
                AddressTxB.Text = place.Address;
                ContactTxB.Text = place.Contact;
                WebsiteTxB.Text = place.Website;
                TopRopeCB.Checked = place.HasTopRope;
                LeadClimbCB.Checked = place.HasLead;
                BoulderCB.Checked = place.HasBoulder;
            }

            BindAreaTags();
        }

        protected void UpdatePlace_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                //-- Validate country is not unknown or UK

                place.Address = AddressTxB.Text;
                place.Description = DescriptionTxB.Text;        
                place.Latitude = (decimal)LatitudeTxB.DoubleValue;
                place.Longitude = (decimal)LongitudeTxB.DoubleValue;
                place.Contact = ContactTxB.Text;
                place.Website = WebsiteTxB.Text;
                place.HasTopRope = TopRopeCB.Checked;
                place.HasLead = LeadClimbCB.Checked;
                place.HasBoulder = BoulderCB.Checked;

                cfController.UpdateIndoorPlace(place);

                RedirectTo<PlacesController>(c => c.DetailIndoor(place.FriendlyUrlLocation, place.FriendlyUrlName));
            }
        }


        protected void AddAreaTag_Click(Object sender, EventArgs e)
        {           
            cfController.AddPlaceAreaTag(place.ID, AreaTxB.SelectedAreaTagID);
            AreaTxB.Clear();
            BindAreaTags();
        }

        protected void RemoveAreaTag_Click(Object sender, EventArgs e)
        {
            int areaTagID = int.Parse(((sender as LinkButton).Parent.FindControl("AreaTagIDLtr") as Literal).Text);

            cfController.DeletePlaceAreaTag(place.ID, areaTagID);
            BindAreaTags();
        }

        private void BindAreaTags()
        {
            AreaTags = cfController.GetAreaTagsForAPlace(place.ID);
            AreaTagsLV.DataSource = AreaTags;
            AreaTagsLV.DataBind();
        }
    }
}
