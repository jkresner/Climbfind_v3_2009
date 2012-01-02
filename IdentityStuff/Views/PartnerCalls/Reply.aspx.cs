using System;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.Enum;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.PartnerCalls
{
    public partial class Reply : ClimbFindViewPage<PartnerCallReplyViewData>
    {
        public ClimberProfile PartnerCallPoster { get { return ViewData.Model.PartnerCallPoster; } }
        public PartnerCall Current { get { return ViewData.Model.Current; } }
        public List<Place> MeetUpPlace { get; set; }
        public string PlacesLinksHtmlString { get; set; }

        protected void Page_Init(Object src, EventArgs e)
        {
            if (Current.Deleted)
            {
                ReplyToPartnerCallMV.SetActiveView(VIEWDeleted);
            }
        }

        protected void ReplyToPartnerCall_Click(Object src, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                new CFController().ReplyToPartnerCall(Current.ID, UserID, MessageTxB.Text);

                ReplyToPartnerCallMV.SetActiveView(VIEWSentReply);
            }
        }
       
        
        protected string GetHeading()
        {
            return string.Format("{0}'s partner call <a href='/climber-profile/{1}'>See {2}'s profile</a>", 
                    Html.Encode(Current.CreatorFullName), Current.ClimberProfileID, Current.CreatorFullName);
        }
    
    }
}



