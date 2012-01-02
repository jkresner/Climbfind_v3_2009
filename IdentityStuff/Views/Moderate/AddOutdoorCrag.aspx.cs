using System;
using System.Web.UI.HtmlControls;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;

namespace IdentityStuff.Views.Moderate
{
    public partial class AddOutdoorCrag : ClimbFindViewPage<OutdoorPlace>
    {
        public OutdoorPlace Place { get { return ViewData.Model; } }

        protected void CreateCrag_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                //-- Validate country is not unknown or UK

                string friendlyUrlName = NameTxB.Text.Replace(" ", "-").ToLower();
                
                OutdoorCrag crag = new OutdoorCrag
                {
                    CreatedByUserID = UserID, 
                    Description = DescriptionTxB.Text,
                    Access = AccesssTxB.Text,
                    Approach = ApproachTxB.Text,
                    History = HistoryTxB.Text,
                    FriendlyUrlName = friendlyUrlName,
                    Name = NameTxB.Text,
                    PlaceID = Place.ID,
                    Type = (int)CragType.Wall,
                    Mosquitoes = GetBoolSelection(YesMosquitoRB, NoMosquitoRB),
                    HasAlpine = HasAlpineCB.Checked,
                    HasBoulder = HasBoulderCB.Checked,
                    HasBuildering = HasBuilderingCB.Checked,
                    HasDWS = HasDeepWaterSoloingCB.Checked,
                    HasIce = HasIceCB.Checked,
                    HasLead = HasLeadCB.Checked,
                    HasMultipitch = HasMultipitchCB.Checked,
                    HasSolo = HasSoloCB.Checked,
                    HasSport = HasSportCB.Checked,
                    HasTopRope = HasTopRopeCB.Checked,
                    HasTrad = HasTradCB.Checked,
                        
                    //ClimbingSummerAM = GetBoolSelection(SummerAMYes, SummerAMNo),
                    //ClimbingSummerPM = GetBoolSelection(SummerPMYes, SummerPMNo),
                    //ClimbingWinterAM = GetBoolSelection(WinterAMYes, WinterAMNo),
                    //ClimbingWinterPM = GetBoolSelection(WinterPMYes, WinterPMNo)
                };

                cfController.AddOutdoorCrag(crag, Place);

                RedirectTo<PlacesController>(c=>c.DetailCrag(Place.FriendlyUrlLocation, Place.FriendlyUrlName, crag.FriendlyUrlName));
            }
        }

        private bool? GetBoolSelection(HtmlInputRadioButton trueRB, HtmlInputRadioButton falseRB)
        {
            if (trueRB.Checked) { return true; }
            else if (falseRB.Checked) { return false; }
            else { return null; }
        }
    }
}
