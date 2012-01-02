using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Model.Objects;
using ClimbFind.Controller;
using ClimbFind.Web.UI;
using ClimbFind.Web.Mvc.Controllers;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class SubscribeToPartnerCallsWhereIClimb : ClimbFindViewUserControl
    {
        public List<Place> PlacesUserClimbs;

        protected void Page_Load(object sender, EventArgs e)
        {
            PlacesUserClimbs = new CFController().GetPlacesUserClimbs(UserID);
        }


        public void SubscribeByEmailToEverywhere_Click(Object o, EventArgs e)
        {
            foreach (Place place in PlacesUserClimbs)
            {
                new CFController().SubscribeToPartnerCallsByEmail(UserID, place.ID);  
            }

            RedirectTo<PartnerCallsController>(c => c.Notifications());
        }


    }
}