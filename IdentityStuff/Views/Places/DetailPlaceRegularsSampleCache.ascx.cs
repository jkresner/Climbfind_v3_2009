using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;
using System.Web.Mvc;

namespace IdentityStuff.Views.Places
{
    public partial class DetailPlaceRegularsSampleCache : ViewUserControl<IClimbingPlace>
    {
        private CFController cfController = new CFController();

        public IClimbingPlace place { get { return ViewData.Model; } }
        protected List<ClimberProfile> Regulars { get; set; }
        protected List<ClimberProfile> RegularsToDispaly { get; set; }
        public string LogoImageFileUrl { get; set; }
      
        public int NumberOfRegularsToShow { get; set; }
        protected int NumberOfRegularsBeingDisplayed
        {
            get
            {
                if (RegularsToDispaly.Count < NumberOfRegularsToShow) { return RegularsToDispaly.Count; }
                else { return NumberOfRegularsToShow; }
            }
        }

        protected void Page_Init(Object s, EventArgs e)
        {
            Regulars = cfController.GetClimbersThatClimbAtPlace(place.ID);
            RegularsToDispaly = cfController.GetRandomSampleClimbersWithPics(Regulars, NumberOfRegularsToShow);
        }
    }
}