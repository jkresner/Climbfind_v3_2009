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
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Exceptions;


namespace ClimbFind.Web.Mvc.Views.PartnerCalls
{
    public partial class New : ClimbFindViewPage<ISessionViewData>
    {
        //-- Page properties       
        protected List<int> placesUserClimbsIDs;
        protected List<Place> allPlaces = CFDataCache.AllPlaces;
        public string ContributeHTML { get; set; }

        //-- Page init

        protected void Page_Init(Object sender, EventArgs e)
        {
        }

        protected void Page_Load(Object sender, EventArgs e)
        {           
            if (!Page.IsPostBack)
            {
                if (CurrentClimber.ImageNotUploaded) { NewPartnerCallMV.SetActiveView(VIEWCompleteClimberProfile); }
                else
                {
                    IndoorRB.Checked = true; //-- Stupid ASP won't let you do this in .aspx
                    bindClimbingPlaces(); //-- First bind just to set of ListView EmptyDataTemplate
                    
                } 
            }
            diplayCorrectClimbingTypeImages(); //-- First bind just to set of ListView EmptyDataTemplate
        }

        private void diplayCorrectClimbingTypeImages()
        {
            if (ToAlpineCB.Checked) { AlpineImg.Src = "~/images/UI/cf/AlpineSelected.bmp"; } else { AlpineImg.Src = "~/images/UI/cf/Alpine.bmp"; }
            if (ToBoulderCB.Checked) { BoulderImg.Src = "~/images/UI/cf/BoulderSelected.bmp"; } else { BoulderImg.Src = "~/images/UI/cf/Boulder.bmp"; }
            if (ToLeadCB.Checked) { LeadImg.Src = "~/images/UI/cf/LeadSelected.bmp"; } else { LeadImg.Src = "~/images/UI/cf/Lead.bmp"; }
            if (ToTopRopeCB.Checked) { TopRopeImg.Src = "~/images/UI/cf/TopRopeSelected.bmp"; } else { TopRopeImg.Src = "~/images/UI/cf/TopRope.bmp"; }
            if (ToTradCB.Checked) { TradImg.Src = "~/images/UI/cf/TradSelected.bmp"; } else { TradImg.Src = "~/images/UI/cf/Trad.bmp"; }
        
            IndoorClimbingTypeVAL.Enabled = IndoorRB.Checked;
            OutdoorClimbingTypeVAL.Enabled = !IndoorRB.Checked;
        }

        //-- Render helper methods
        protected bool CheckIfUserAlreadyClimbsAt(int placeID)
        {
            return placesUserClimbsIDs.Contains(placeID);
        }

        //----------- Refreshing the places list ------------//

        private List<IClimbingPlace> getPlacesForArea(int areaID)
        {
            List<IClimbingPlace> areasPlaces = new List<IClimbingPlace>();

            if (IndoorRB.Checked)
            {
                foreach (IClimbingPlace p in cfController.GetIndoorPlacesInArea(areaID).OrderBy(c => c.Name).ToList())
                {
                    areasPlaces.Add(p);
                }
            }
            else
            {
                foreach (IClimbingPlace p in cfController.GetOutdoorPlacesInArea(areaID).OrderBy(c => c.Name).ToList())
                {
                    areasPlaces.Add(p);
                }
            }

            return areasPlaces;
        }

        private void bindClimbingPlaces()
        {
            int areaID;
            if (int.TryParse(AreaID.Text, out areaID))
            {
                //-- Used to preselect places
                placesUserClimbsIDs = cfController.GetPlacesUserClimbs(UserID).Select(c => c.ID).ToList();

                List<IClimbingPlace> areasPlaces = getPlacesForArea(areaID);

                PlacesLV.DataSource = areasPlaces;
                PlacesLV.DataBind();
                AddPlaceDIV.Visible = true;

                NoResultsP.Visible = areasPlaces.Count == 0;
                if (areasPlaces.Count == 0)
                {
                    AreaTag selectedArea = (from c in CFDataCache.AllAreaTags where c.ID == int.Parse(AreaID.Text) select c).SingleOrDefault();
                    string placeTypeString = "indoor";
                    if (OutdoorRB.Checked) { placeTypeString = "outdoor"; }
                    NoResultsLtr.Text = string.Format("No results for {0} places in {1}", placeTypeString, selectedArea.Name);
                }
            }
            else
            {
                NoResultsP.Visible = true;
                NoResultsLtr.Text = "Please select a valid city / state / country from the text box above";
            }
            
        }


        protected void ContinueToPostCall_Click(Object o, EventArgs e)
        {
            NewPartnerCallMV.SetActiveView(VIEWNewPartnerCall);
        }
        

        protected void AddPlace_Click(Object o, EventArgs e)
        {
            if (IndoorRB.Checked) { RedirectTo<ModerateController>(c=>c.AddIndoorPlace()); }
            else { RedirectTo<ModerateController>(c => c.AddOutdoorLocation()); }
        }

        

        protected void RefreshPlaces_Click(Object o, EventArgs e)
        {
            TradDIV.Visible = OutdoorRB.Checked;
            AlpineDIV.Visible = OutdoorRB.Checked;


            bindClimbingPlaces();            
        }

        //------------ Page Save Stuff ---------------------------------------------//

        private List<int> GetSelectedPlaces()
        {
            List<int> pids = new List<int>();
            foreach (ListViewDataItem item in PlacesLV.Items)
            {
                HtmlInputCheckBox pidCB = item.FindControl("PID") as HtmlInputCheckBox;
                if (pidCB.Checked) { pids.Add(int.Parse(pidCB.Value)); }
            }
            return pids;
        }

        protected void CreatePartnerCall_Click(object sender, EventArgs e)
        {
            //-- catch UserPartnerCallWithSamePlacesExistsException        
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                List<int> selectedPlaceIDs = GetSelectedPlaces();

                if (selectedPlaceIDs.Count == 0) { PlacesErrorDIV.Visible = true; }
                else
                {
                    try
                    {
                        PlacesErrorDIV.Visible = false;
                        short countryID = (from c in CFDataCache.AllAreaTags where c.ID == int.Parse(AreaID.Text) select c.CountryID).SingleOrDefault();

                        cfController.CreatePartnerCall(
                            new PartnerCall
                            {
                                ClimberProfileID = UserID,
                                PlaceIDs = selectedPlaceIDs,
                                CountryID = countryID,
                                Message = NewCallMessageTxB.Text,
                                IsIndoor = IndoorRB.Checked,
                                ToBoulder = ToBoulderCB.Checked,
                                ToLeadClimb = ToLeadCB.Checked,
                                ToTopRope = ToTopRopeCB.Checked,
                                ToAlpine = ToAlpineCB.Checked,
                                ToTrad = ToTradCB.Checked
                            });

                        //        ContributeHTML = new SpecialPagesHTMLDA().GetByID(5).PageHtml;

                        //-- If the email isn't verified we don't know if they will receive the replies
                        ClimberProfile cp = cfController.GetClimberProfileByEmail(User.Identity.Name);
                        List<PartnerCallSubscription> subscriptions = cfController.GetUsersPartnerCallSubscriptions(cp.ID);
                        if (!cp.EmailVerified)
                        {
                            RedirectTo<ClimberProfilesController>(c => c.VerifyEmailAddress(Guid.Empty));
                        }
                        else if (subscriptions.Count == 0)
                        {
                            NewPartnerCallMV.SetActiveView(VIEWPartnerCallPostedNowSubscribe);
                        }
                        else
                        {
                            NewPartnerCallMV.SetActiveView(VIEWPartnerCallPosted);
                        }
                    }
                    catch (UserPartnerCallWithSamePlacesExistsException ex)
                    {
                        NewPartnerCallMV.SetActiveView(VIEWCantPostSamePlacesTwice);
                    }
                }
            }
        }

    }

    

}
