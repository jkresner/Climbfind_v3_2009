using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using IdentityStuff.Models.ViewData;
using ClimbFind.Model.DataAccess;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class WriteMessage : ClimbFindViewPage<ClimberProfilesWriteMessageViewData>
    {
        public ClimberProfile climberProfile { get { return 
            CFDataCache.GetClimberFromCache(ViewData.Model.ClimberProfileToSendMessageID); } }

        protected void Page_Init(Object o, EventArgs e)
        {
            if (Request.QueryString["RID"] != null)
            {
                try
                {
                    Guid replyID = new Guid(Request.QueryString["RID"].ToString());
                    UserMessage originalMessage = cfController.GetUserMessage(replyID);
                    SubjectTxB.Text = "Re: " + originalMessage.Subject;
                }
                catch { }
            }
        }

        protected void SendMessage_Click(Object o, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                cfController.SendMessage(climberProfile, SubjectTxB.Text, MessageTxB.Text);

                WriteMessageMV.SetActiveView(VIEWMessageSent);
            }
        }
    }
}
