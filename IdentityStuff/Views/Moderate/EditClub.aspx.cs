using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditClub : ClimbFindViewPage<Club>
    {
        public Club club { get { return ViewData.Model; } }
        public List<AreaTag> AreaTags { get; set; }

        protected void Page_Init(Object sender, EventArgs e)
        {
            AreaTags = cfController.GetAreaTagsForAClub(club.ID);
        }
        

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NameLb.Text = club.Name;
                DescriptionTxB.Text = club.Description;
            }
            BindAreaTags();
        }   
 
        protected void UpdateClub_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                club.Description = DescriptionTxB.Text;
                cfController.UpdateClub(club);
                RedirectTo<ClubsController>(c => c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName));
            }
        }

        protected void AddAreaTag_Click(Object sender, EventArgs e)
        {
            cfController.AddClubAreaTag(club.ID, AreaTagDDLUC.SelectedAreaTagID);
            BindAreaTags();
        }

        protected void RemoveAreaTag_Click(Object sender, EventArgs e)
        {
            int areaTagID = int.Parse(((sender as LinkButton).Parent.FindControl("AreaTagIDLtr") as Literal).Text);

            cfController.DeleteClubAreaTag(club.ID, areaTagID);
            BindAreaTags();
        }

        private void BindAreaTags()
        {
            AreaTags = cfController.GetAreaTagsForAClub(club.ID);
            AreaTagsLV.DataSource = AreaTags;
            AreaTagsLV.DataBind();
        }

    }
}
