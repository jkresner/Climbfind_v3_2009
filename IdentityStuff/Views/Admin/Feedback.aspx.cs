using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClimbFind.Controller;

namespace IdentityStuff.Views.Admin
{
    public partial class Feedback : ViewPage
    {
        public List<ClimbFind.Model.Objects.Feedback> SiteFeedback { get; set; }
        public int i = 1;

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SiteFeedback = CFLogger.GetAllFeedback();
                SiteFeedback.Reverse();
                FeedbackLV.DataSource = SiteFeedback;
                DataBind();
            }
        }


        protected void UpdateFeedback_Click(Object sender, CommandEventArgs e)
        {
            int feedbackID = int.Parse(e.CommandArgument.ToString());
            TextBox reviewCommentTxB = (sender as LinkButton).Parent.FindControl("ResponseFromAdminTxB") as TextBox;
            CheckBox publishedBC = (sender as LinkButton).Parent.FindControl("PublishedCB") as CheckBox;

            CFLogger.SaveFeedbackReview(feedbackID, publishedBC.Checked, reviewCommentTxB.Text);
        }
    
    
    
    
    }




}
