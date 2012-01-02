using System;
using System.Web.UI.HtmlControls;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditOutdoorCrag : ClimbFindViewPage<OutdoorCrag>
    {
        public OutdoorPlace place { get; set; }

        public OutdoorCrag Crag { get { return ViewData.Model; } }

        protected void Page_Load(Object sender, EventArgs e)
        {
            place = cfController.GetOutdoorPlace(Crag.PlaceID);
            
            if (!Page.IsPostBack)
            {
                NameLb.Text = Crag.Name;
                DescriptionTxB.Text = Crag.Description;
                AccesssTxB.Text = Crag.Access;
                ApproachTxB.Text = Crag.Approach;
                HistoryTxB.Text = Crag.History;
                //OutdoorClimbingTypeDDLUC.Bind((CragType)Crag.Type);
                SetBoolSelection(Crag.Mosquitoes, YesMosquitoRB, NoMosquitoRB);
                SetBoolSelection(Crag.ClimbingSummerAM, SummerAMYes, SummerAMNo);
                SetBoolSelection(Crag.ClimbingSummerPM, SummerPMYes, SummerPMNo);
                SetBoolSelection(Crag.ClimbingWinterAM, WinterAMYes, WinterAMNo);
                SetBoolSelection(Crag.ClimbingWinterPM, WinterPMYes, WinterPMNo);
                HasAlpineCB.Checked = Crag.HasAlpine;
                HasBoulderCB.Checked = Crag.HasBoulder;
                HasBuilderingCB.Checked = Crag.HasBuildering;
                HasDeepWaterSoloingCB.Checked = Crag.HasDWS;
                HasIceCB.Checked = Crag.HasIce;
                HasLeadCB.Checked = Crag.HasLead;
                HasMultipitchCB.Checked = Crag.HasMultipitch;
                HasSoloCB.Checked = Crag.HasSolo;
                HasSportCB.Checked = Crag.HasSport;
                HasTopRopeCB.Checked = Crag.HasTopRope;
                HasTradCB.Checked = Crag.HasTrad;
            }
        }

        protected void UpdateCrag_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                Crag.Description = DescriptionTxB.Text;
                Crag.Access = AccesssTxB.Text;
                Crag.Approach = ApproachTxB.Text;
                Crag.History = HistoryTxB.Text;
                //Crag.Type = (int)OutdoorClimbingTypeDDLUC.SelectedType;
                Crag.Mosquitoes = GetBoolSelection(YesMosquitoRB, NoMosquitoRB);
                Crag.ClimbingSummerAM = GetBoolSelection(SummerAMYes, SummerAMNo);
                Crag.ClimbingSummerPM = GetBoolSelection(SummerPMYes, SummerPMNo);
                Crag.ClimbingWinterAM = GetBoolSelection(WinterAMYes, WinterAMNo);
                Crag.ClimbingWinterPM = GetBoolSelection(WinterPMYes, WinterPMNo);
                Crag.HasAlpine = HasAlpineCB.Checked;
                Crag.HasBoulder = HasBoulderCB.Checked;
                Crag.HasBuildering = HasBuilderingCB.Checked;
                Crag.HasDWS = HasDeepWaterSoloingCB.Checked;
                Crag.HasIce = HasIceCB.Checked;
                Crag.HasLead = HasLeadCB.Checked;
                Crag.HasMultipitch = HasMultipitchCB.Checked;
                Crag.HasSolo = HasSoloCB.Checked;
                Crag.HasSport = HasSportCB.Checked;
                Crag.HasTopRope = HasTopRopeCB.Checked;
                Crag.HasTrad = HasTradCB.Checked;

                cfController.UpdateOutdoorCrag(Crag);

                RedirectTo<PlacesController>(c=>c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, Crag.FriendlyUrlName));
            }
        }

        private void SetBoolSelection(bool? boolen, HtmlInputRadioButton trueRB, HtmlInputRadioButton falseRB)
        {
            if (boolen.HasValue)
            {
                if (boolen.Value) { trueRB.Checked = true; }
                else { falseRB.Checked = true; }
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
