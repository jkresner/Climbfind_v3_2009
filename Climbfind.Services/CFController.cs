using System;
using System.Security.Principal;
using System.Web;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using System.Collections.Generic;

namespace ClimbFind.Controller
{
    public partial class CFController
    {             
        /// <summary>
        /// Shared Base Properties
        /// </summary>
        public IIdentity User { get { return HttpContext.Current.User.Identity; } }
        public ClimberProfile CurrentClimber { get { return new ClimberProfileDA().GetClimberProfile(User.Name); } }


        /// <summary>
        /// Messageboard stuff
        /// </summary>
        public MessageBoard GetMessageBoard(Guid messageBoardID)
        {
            return new MessageBoardDA().GetByID(messageBoardID);
        }

        public List<FeedPostComment> GetCommentsForMedia(Guid messageBoardID)
        {
            List<FeedPostComment> comments = new List<FeedPostComment>();
            MessageBoard mb = new MessageBoardDA().GetByID(messageBoardID);
            foreach (MessageBoardMessage m in mb.Messages)
            {
                comments.Add(
                    new FeedPostComment { PostedDateTime = m.PostedDateTime, Message = m.Message, UserID = m.UserID });
            } 

            return comments;
        }


        public MessageBoard PostMessageBoardMessage(Guid messageBoardID, Guid userID, string message)
        {
            new MessageBoardMessageDA().Insert(new MessageBoardMessage
            {
                ID = Guid.NewGuid(),
                PostedDateTime = DateTime.Now,
                Message = message,
                MessageBoardID = messageBoardID,
                UserID = userID
            });

            return new MessageBoardDA().GetByID(messageBoardID);
        }



        public MessageBoard DeleteMessageBoardMessage(Guid messageBoardID, Guid messageID)
        {
            new MessageBoardMessageDA().Delete(messageID);

            return new MessageBoardDA().GetByID(messageBoardID);
        }



        private Guid InsertNewMessageBoard()
        {
            return (new MessageBoardDA().Insert(new MessageBoard { ID = Guid.NewGuid(), IsVisible = true })).ID;
        }



        private void UpdateMessageBoardVisibility(Guid messageBoardID, bool isVisible)
        {
            MessageBoardDA mDA = new MessageBoardDA();
            MessageBoard messageBoard = mDA.GetByID(messageBoardID);

            if (messageBoard.IsVisible != isVisible)
            {
                messageBoard.IsVisible = isVisible;
                mDA.Update(messageBoard);
            }
        }
    }
}
