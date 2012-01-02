using System;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Web.UI;
using CFMessageBoard = ClimbFind.Model.Objects.MessageBoard;

namespace ClimbFind.Web.Mvc.Controls
{
    public partial class MessageBoard : ClimbFindViewUserControl
    {
        public bool PostingDisabled { get; set; }
        public Guid MessageBoardID { get { return new Guid(MessageBoardIDHD.Value); } }
        public Guid OwnersUserID { get { return new Guid(OwnersUserIDHD.Value); } }
        public string Heading { get { return _heading ;} set { _heading = value; } }
        private string _heading = "Message board";
        protected int MessageCount;

        /// <summary>
        /// 
        /// </summary>
        public void RenderMessageBoard(CFMessageBoard messageBoard, Guid ownersUserID)
        {
            OwnersUserIDHD.Value = ownersUserID.ToString();
            RenderMessageBoard(messageBoard);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RenderMessageBoard(CFMessageBoard messageBoard)
        {           
            MessageBoardDIV.Visible = true;
            MessageCount = messageBoard.Messages.Count;

            PostMessageTAB.Visible = !PostingDisabled;
            MessageBoardIDHD.Value = messageBoard.ID.ToString();

            if (messageBoard.IsVisible)
            {
                MessagesLV.DataSource = messageBoard.Messages;
                DataBind();
            }
            else
            {
                this.Visible = false;
            }

            if (!UserLoggedIn) { SignInDIV.Visible = true; PostMessageTAB.Visible = false; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected void CreateMessage_Click(object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                CFController cf = new CFController();
                
                //WebFormsTextBox messageTxB = MessagesLV.Controls[0].FindControl("MessageBoardMessageTxB") as WebFormsTextBox;

                CFMessageBoard updatedMessageBoard = cf.PostMessageBoardMessage(MessageBoardID,
                    UserID, MessageBoardMessageTxB.Text);

                if (!String.IsNullOrEmpty(OwnersUserIDHD.Value))
                {
                    cf.SendMessageBoardNotification(OwnersUserID, MessageBoardMessageTxB.Text);
                }

                MessageBoardMessageTxB.Text = "";

                RenderMessageBoard(updatedMessageBoard);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void DeleteMessage_Click(object sender, CommandEventArgs e)
        {
            Guid messageID = new Guid(e.CommandArgument.ToString());

            CFMessageBoard updatedMessageBoard = new CFController().DeleteMessageBoardMessage(MessageBoardID, messageID);

            RenderMessageBoard(updatedMessageBoard);
        }

        protected bool ShowDeleteMessageLinkButton(Guid postersUserID)
        {
            if (!UserLoggedIn) { return false; }
            else if (postersUserID == UserID) { return true; }
            else if (!String.IsNullOrEmpty(OwnersUserIDHD.Value)) { return OwnersUserID == UserID; }
            return false;
        }
    }
}
