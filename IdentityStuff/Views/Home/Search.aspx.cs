using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using DropDownListItem = System.Web.UI.WebControls.ListItem;


namespace ClimbFind.Web.Mvc.Views.Home
{
    public partial class Search : ClimbFindViewPage<string>
    {
        protected List<ClimberProfile> peopleResults, peopleDisplayedResults;
        protected List<Place> placeResults, placeDisplayResults;
        protected List<AreaTag> areaResults;

        protected string PostSearchString { get { return ViewData.Model; } }
        protected int i = 1, j = 1, l = 1;

        public string searchString
        {
            get
            {
                if (!IsPostBack) { return PostSearchString; }
                else { return NameTxB.Text; }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { NameTxB.Text = PostSearchString; }

            if (!String.IsNullOrEmpty(searchString))
            {
                peopleResults = cfController.SearchClimberProfiles(searchString);
                peopleResults = (from c in peopleResults orderby c.IsUnfinished select c).ToList();

                placeResults = cfController.SearchPlaces(searchString);
                areaResults = cfController.SearchAreas(searchString);

                displayResults();
            }
            else
            {
                PeopleResultCountLB.Text = "<b>no</b>";
                PlaceResultCountLB.Text = "<b>no</b>";
                AreaResultCountLB.Text = "<b>no</b>";
            }
        }

        private void displayResults()
        {
            peopleDisplayedResults = peopleResults.Take(50).ToList();
            placeDisplayResults = placeResults.Take(20).ToList();

            PeopleResultsLV.DataSource = peopleDisplayedResults;
            PlaceResultsLV.DataSource = placeDisplayResults;
            AreaResultsLV.DataSource = areaResults;


            DataBind(); // important to bind here so the code below works

            if (peopleDisplayedResults.Count > 0)
            {
                PeopleResultCountLB.Text =
                    string.Format("<b>{0}</b> of {1}", peopleDisplayedResults.Count, peopleResults.Count);
            } else { PeopleResultCountLB.Text = "<b>no</b>"; }

            if (placeDisplayResults.Count > 0)
            {
                PlaceResultCountLB.Text =
                    string.Format("<b>{0}</b> of {1}", placeDisplayResults.Count, placeResults.Count);
            }
            else { PlaceResultCountLB.Text = "<b>no</b>"; }

            if (areaResults.Count > 0)
            {
                AreaResultCountLB.Text =
                    string.Format("<b>{0}</b> of {1}", areaResults.Count, areaResults.Count);
            }
            else { AreaResultCountLB.Text = "<b>no</b>"; }
        
        }

        protected void Search_Click(object sender, EventArgs e)
        {
        }    
    }
}
