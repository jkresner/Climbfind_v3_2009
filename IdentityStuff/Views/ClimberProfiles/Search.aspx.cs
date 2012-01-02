using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using DropDownListItem = System.Web.UI.WebControls.ListItem;


namespace ClimbFind.Web.Mvc.Views.ClimberProfiles
{
    public partial class Search : ClimbFindViewPage<ISessionViewData>
    {
        protected List<ClimberProfile> results;
        protected List<ClimberProfile> displayedResults;

        protected int i = 1;

        protected void bindPartnerStatusDDL()
        {
            //foreach (ClimberProfilePartnerStatus s in CFDataCache.AllPartnerStatus)
            //{
            //    DropDownListItem item = new DropDownListItem(s.Name, s.ID.ToString());
            //    PartnerStatusDDL.Items.Add(item);
            //}
        }
        
        protected void Page_Init(object sender, EventArgs e)
        {
            bindPartnerStatusDDL();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { }

            //bool? isMale = null;
            //if (!NoSexRB.Checked) { isMale = IsMaleRB.Checked; }

            //byte partnerStatusID = byte.Parse(PartnerStatusDDL.SelectedItem.Value);

            //results = cfController.SearchClimberProfiles(ClimbingLevelDDL.SelectedItem.Value, isMale, 
            //    PlaceDDLUC.SelectedPlaceID, partnerStatusID);

            //results = (from c in results orderby c.IsUnfinished select c).ToList(); 

            //displayResults();
        }

        private void displayResults()
        {
            //displayedResults = results.Take(50).ToList();
            //ResultsLV.DataSource = displayedResults;
            //DataBind();

            //if (displayedResults.Count > 0)
            //{
            //    (ResultsLV.Controls[0].FindControl("ResultCountLB") as System.Web.UI.WebControls.Literal).Text =
            //        string.Format("<b>{0}</b> of {1}", displayedResults.Count, results.Count);
            //}
        }

        protected void Search_Click(object sender, EventArgs e)
        {
        }    
    }
}
