using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditOutdoorAuthoritySites : ClimbFindViewPage<OutdoorPlace>
    {
        public OutdoorPlace place { get { return ViewData.Model; } }
        public List<OutdoorPlaceAuthority> AuthoritySites { get; set; }

        private void BindAuthoritySites()
        {
            AuthoritySites = cfController.GetOutdoorPlacesAuthoriySites(place.ID);
            AuthoritySitesLV.DataSource = AuthoritySites;
            DataBind();
            NameTxB.Text = "";
            UrlTxB.Text = "";
        }

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindAuthoritySites();
            }
        }

        protected void UpdatePlace_Click(Object sender, EventArgs e)
        {
        }

        protected void AddOutdoorAuthoritySite_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                cfController.AddOutdoorPlaceAuthoriySites(
                    new OutdoorPlaceAuthority()
                    {
                        Name = NameTxB.Text,
                        PlaceID = place.ID,
                        Url = UrlTxB.Text
                    });  
            }
            BindAuthoritySites();
        }

        protected void RemoveOutdoorAuthoritySite_Click(Object sender, CommandEventArgs e)
        {
            int siteID = int.Parse(e.CommandArgument.ToString());
            cfController.RemoveOutdoorPlaceAuthoriySites(siteID);
            BindAuthoritySites();
        }
    }
}
