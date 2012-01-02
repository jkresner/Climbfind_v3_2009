///-------------------------------------------------------------------------------------///
///- PPEmailer is dual purpose: --------------------------------------------------------///
///- 1. To encase content with appropriate HTML for each type of Email.  ---------------///
///- 2. To send the Email via the Preparty Mail Servers. -------------------------------///
///- invitation and the PPHTMLInvitation supplies all the style and images for the ----///
///- invitation. The same PPInvite could also be used with a PPMobileInvitation --------///
///-------------------------------------------------------------------------------------///
using System;
using System.Net.Mail;
using System.Web.Security;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using System.Web;

namespace ClimbFind.Mail
{
	public static class MailMan
	{
		//--------------------------------------------------------------------------------//
		//-- Constructor -----------------------------------------------------------------//
		//--------------------------------------------------------------------------------//
	
        static MailMan()
		{
		}

        //--------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//


        public static void SendReplyToPartnerCall(PartnerCall partnerCall, PartnerCallReply reply,
            ClimberProfile replyer, string replyersEmail, string postersEmail)
        {            
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateReplyToPartnerCallBody(reply.ReplyingUserID,
                    replyer.FullName, replyersEmail, partnerCall.CreatorFullName, postersEmail, reply.Message),
                From = new MailAddress(replyersEmail, reply.ReplyingName),
                Subject = "Climbfind: Reply to your partner call from " + reply.ReplyingName,
                To = new MailAddress(postersEmail, partnerCall.CreatorFullName)
            });


        }

        public static void SendPartnerCallNotificationEmail(ClimberProfile userReceivingNotification, 
            PartnerCall partnerCall, string placeName, string allPlaces, string postersEmail)
        {            
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GeneratePartnerCallNotificationBody(placeName, allPlaces, 
                    partnerCall.CreatorFullName, userReceivingNotification.Email, partnerCall.Message, partnerCall.ID),
                From = CFSettings.MailMan,
                Subject = string.Format("{0}'s partner call for {1}", partnerCall.CreatorFullName, placeName),
                To = new MailAddress(userReceivingNotification.Email, userReceivingNotification.FullName)
            });
        }


        public static void SendPartnerFeedPostNotificationEmail(ClimberProfile userReceivingNotification,
            ClimberProfile userPosting, FeedClimbingPost post, string placeName)
        {           
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateFeedPartnerPostNotificationBody(placeName, post.ClimbingDateTime,
                    userPosting.FullName, userReceivingNotification.Email, post.Message, post.ID),
                From = CFSettings.MailMan,
                Subject = string.Format("{0}'s post for {1} @ {2}", userPosting.FullName, post.ClimbingDateTime.ToCFDateString(), placeName),
                To = new MailAddress(userReceivingNotification.Email, userReceivingNotification.FullName)
            });
        }


        public static void SendFeedPostIntroductionNotificationEmail(ClimberProfile userReceivingNotification,
            ClimberProfile userPosting, FeedClimbingPost post, string placeName)
        {
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateFeedIntroductionPostNotificationBody(placeName, 
                    userPosting.FullName, userPosting.ID, userReceivingNotification.Email, post.Message, post.ID),
                From = CFSettings.MailMan,
                Subject = string.Format("New climber @ {0}", placeName),
                To = new MailAddress(userReceivingNotification.Email, userReceivingNotification.FullName)
            });
        }

        public static void SendWatchRequestEmail(int watchClimberEntryID, ClimberProfile userSendingRequest,
                    ClimberProfile userBeingWatched)
        {
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateWatchRequestBody(userSendingRequest.ID, userSendingRequest.FullName,
                    userBeingWatched.Email, userSendingRequest.HisHerString, watchClimberEntryID),
                From = CFSettings.MailMan,
                Subject = string.Format("{0} wants to know where you climb", userSendingRequest.FullName),
                To = new MailAddress(userBeingWatched.Email, userBeingWatched.FullName)
            });
        }

        public static void SendCommentOnMyFeedPostNotification(int postID, ClimberProfile userCommenting,
                    ClimberProfile userWhoMadePost, string comment)
        {
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateCommentOnMyFeedPostNotificationBody(userCommenting.FullName, userWhoMadePost.Email,
                 postID, comment),
                From = CFSettings.MailMan,
                Subject = string.Format("{0} commented on your post", userCommenting.FullName),
                To = new MailAddress(userWhoMadePost.Email, userWhoMadePost.FullName)
            });
        }

        public static void SendCommentOnAFeedPostICommentedOnNotification(int postID, ClimberProfile userCommenting,
                    ClimberProfile userWhoMadePost, ClimberProfile userOriginallyCommented, string comment)
        {
            string postersOwnerName = userWhoMadePost.FullName + "'s";
            if (userWhoMadePost.ID == userCommenting.ID) { postersOwnerName = "their"; }
            
            SMTP.PostSingleMail(new CFEmail
            {
                Body = CFEmailBodyGenerator.GenerateCommentOnAFeedPostICommentedOnNotificationBody(userCommenting.FullName, 
                    userWhoMadePost.FullName, postersOwnerName, userWhoMadePost.Email, postID, comment),
                From = CFSettings.MailMan,
                Subject = string.Format("{0} also commented on {1} post", userCommenting.FullName, postersOwnerName),
                To = new MailAddress(userOriginallyCommented.Email, userOriginallyCommented.FullName)
            });
        }
        
        

        public static void SendUserMessageEmail(ClimberProfile from, ClimberProfile to, string subject, string message,
            Guid msgID)
        {
            string toEmail = to.Email;

            SMTP.PostSingleMail(
                new CFEmail
                {
                    Subject = string.Format("{0} sent you a message on Climbfind", from.FullName),
                    From = CFSettings.MailMan,
                    To = new MailAddress(toEmail, to.FullName),
                    Body = CFEmailBodyGenerator.GetUserMessageBody(from.ID, from.FullName, to.Email, subject, message, msgID)
                });
        }


        public static void SendVerifyEmailAddressEmail(ClimberProfile to)
        {
            SMTP.PostSingleMail(
                new CFEmail
                {
                    Subject = "Verify your email on Climbfind",
                    From = CFSettings.MailMan,
                    To = new MailAddress(to.Email, to.FullName),
                    Body = CFEmailBodyGenerator.GenerateEmailVerificationBody(to.MessageBoardID, to.Email)
                });
        }

        public static void SendMessageboardNotificationEmail(ClimberProfile from, ClimberProfile to, string message)
        {
            string toEmail = to.Email;

            SMTP.PostSingleMail(
                new CFEmail
                {
                    Subject = string.Format("{0} posted a message on your message board", from.FullName),
                    From = CFSettings.MailMan,
                    To = new MailAddress(toEmail, to.FullName),
                    Body = CFEmailBodyGenerator.GetUserMessageboardNotificationBody(from.ID, from.FullName, to.Email, message)
                });
        }
        
        
        public static void SendMessageBoardNotification(ClimberProfile userWrittenOnBoard, ClimberProfile messageBoardOwner)
        {
            string toEmail = messageBoardOwner.Email;

            SMTP.PostSingleMail(
                new CFEmail
                {
                    Subject = string.Format("{0} posted a message on your message board", userWrittenOnBoard.FullName),
                    From = CFSettings.MailMan,
                    To = new MailAddress(toEmail, messageBoardOwner.FullName),
                    Body = CFEmailBodyGenerator.GetMessageBoardNotificationBody(userWrittenOnBoard.FullName, messageBoardOwner.Email)
                });
        }

        public static void SendAppExceptionEmail(Exception ex, string usersEmail)
        {
            string subject = string.Format("[CFException] {0} {1}", ex.GetType(), DateTime.Now);
            string body = string.Format("User: {0} [{4}]<br /><br />{1}<br /><br />{2} <br /><br />{3}", usersEmail, HttpContext.Current.Request.Url, ex.Message, ex.StackTrace, HttpContext.Current.Request.UserHostAddress);
            SMTP.SendAppEvent(subject, body, "jkresner@yahoo.com.au");           
        }

        public static void SendAppEventEmail(CFLogEventType eventName, string eventDescription, string usersEmail, Guid userID, string receiverEmail)
        {
            string subject = string.Format("[CFEvent] {0} {1}", eventName, DateTime.Now);
            string body = string.Format("User: <a href='http://cf3.climbfind.com/climber-profile/{2}'>{0}</a><br /><br />{1}", usersEmail, eventDescription, userID);
            SMTP.SendAppEvent(subject, body, receiverEmail);
        }

        public static void SendFeedbackAlertEmail(string feedbackEmail, string feedbackName, string feedbackComment)
        {
            string subject = string.Format("Feedback from {0}", feedbackEmail);
            string body = string.Format("{0} said: <br /><br />{1}", feedbackName, feedbackComment);
            SMTP.SendAppEvent(subject, body, "jkresner@yahoo.com.au");
        }

	}




}
