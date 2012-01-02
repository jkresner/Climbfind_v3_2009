using System;
using System.IO;
using System.Text;
using ClimbFind.Controller;
using ClimbFind.Helpers;


namespace ClimbFind.Mail
{
    internal static class CFEmailBodyGenerator
    {
        private static string _emailTemplateDirectory;
        static string HtmlHeaderAndFooterTemplate; 
        static string HtmlH1Styles = " style='font-family:Georgia,Times New Roman,Times,serif;margin:0px 5px 20px 5px;font-size:22px'";
        static string HtmlAStyle = " style='color:#CB4721;text-decoration:none'";

        static CFEmailBodyGenerator()
        {
            _emailTemplateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"images\emailtemplates\";
            HtmlHeaderAndFooterTemplate = GetEmailTemplateAsString("normaltemplate.htm");
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateEmailVerificationBody(Guid messageBoardID, string usersEmail)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>Verify your email address</h1>", HtmlH1Styles);
            sb.AppendFormat(@"<p>Follow this link to verify your email address:</p><p><a href=""{0}ClimberProfiles/VerifyEmailAddress/{2}""{1}>{0}ClimberProfiles/VerifyEmailAddress/{2}</a></p>",
                CFSettings.WebAddress, HtmlAStyle, messageBoardID);

            return WrapInHeaderAndFooter(sb, usersEmail);
        }

        public static string GenerateWatchRequestBody(Guid watchingUserID, string watchingFullName,
            string usersEmail, string sexString, int watchClimberEntryID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>Climbers channel request from {1}</h1>", HtmlH1Styles, watchingFullName);
            sb.AppendFormat(@"<p><a href=""{0}climber-profile/{1}"" {2}>{3}</a> has requested to add you to {4} personal climbers channel</p>",
                CFSettings.WebAddress, watchingUserID, HtmlAStyle, watchingFullName, sexString);
            sb.Append(@"<p style=""font-size:11px"">Adding people to your Climbers Channel helps you to keep track of where friends and famous climbers are climbing.</p>");
            sb.AppendFormat(@"<p><a href=""{0}/CFFeed/ClimbersWatchingMe"" {2}>Confirm you are happy to be added</a> to {3}'s channel, or if your not yet sure, view <a href=""{0}climber-profile/{4}""{2}>{5} profile</a>.</p>",
                CFSettings.WebAddress, watchClimberEntryID, HtmlAStyle, watchingFullName, watchingUserID, sexString);

            return WrapInHeaderAndFooter(sb, usersEmail);
        }


        public static string GenerateCommentOnMyFeedPostNotificationBody(string commentorsFullName,
            string usersEmail, int postID, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>{1} commented on your post</h1>", HtmlH1Styles, commentorsFullName);
            sb.AppendFormat(@"<p><i>They said: </i></p><p style=""color:gray;padding:10px"">{0}</p>", message.GetHtmlParagraph());
            sb.AppendFormat(@"<p><a href=""{0}CFFeed/CommentOnPost/{1}"" {2}>See the whole thread</a> to read the conversation and reply.</p>",
                CFSettings.WebAddress, postID, HtmlAStyle);

            return WrapInHeaderAndFooter(sb, usersEmail);
        }

        public static string GenerateCommentOnAFeedPostICommentedOnNotificationBody(string commentorsFullName,
            string postersFullName, string postOwnersName, string usersEmail, int postID, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>{1} also commented on {2} post</h1>", HtmlH1Styles, commentorsFullName, postOwnersName);
            sb.AppendFormat(@"<p><i>They said: </i></p><p style=""color:gray;padding:10px"">{0}</p>", message.GetHtmlParagraph());
            sb.AppendFormat(@"<p><a href=""{0}CFFeed/CommentOnPost/{1}"" {2}>See the whole thread</a> to read the conversation and reply.</p>",
                CFSettings.WebAddress, postID, HtmlAStyle);

            return WrapInHeaderAndFooter(sb, usersEmail);
        }
        


        /// <summary>
        /// 
        /// </summary>
        public static string GeneratePartnerCallNotificationBody(string placeName, string allPlaces, 
            string partnerCallFullName, string toEmail, string message, Guid partnerCallID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>{1} wants to climb @ {2}</h1>", HtmlH1Styles, partnerCallFullName, placeName);
            sb.AppendFormat(@"<p>{0} just posted a partner call for partners at {1}.</p><p>They wrote: ""{2}""</p>",
                partnerCallFullName, allPlaces, message);
            sb.AppendFormat(@"<p>To see the rest of the details and reply, <a href=""{0}PartnerCalls/Reply/{2}""{1}>review {3}'s call</a> on climbfind.</p>",
                CFSettings.WebAddress, HtmlAStyle, partnerCallID, partnerCallFullName);

            return WrapInHeaderAndFooter(sb, toEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateFeedPartnerPostNotificationBody(string placeName, DateTime dateTime, 
            string postersFullName, string toEmail, string message, int feedPostID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"<p>{0} just posted on the climbing feed for {1} on {2}.</p><p>They wrote: ""{3}""</p>",
                postersFullName, placeName, dateTime.ToCFDateString(), message);
            sb.AppendFormat(@"<p>Reply by <a href=""{0}CFFeed/CommentOnPost/{2}""{1}>commenting on the thread</a>.</p>",
                CFSettings.WebAddress, HtmlAStyle, feedPostID);

            sb.AppendFormat(@"<p>To control partner notification emails go to your <a href=""{0}PartnerCalls/Notifications""{1}>notifications settings</a>.</p>",
                CFSettings.WebAddress, HtmlAStyle, feedPostID);

            return WrapInHeaderAndFooter(sb, toEmail);
        }

        
        /// <summary>
        /// 
        /// </summary>
        public static string GenerateFeedIntroductionPostNotificationBody(string placeName,  
            string postersFullName, Guid postersUserID, string toEmail, string message, int feedPostID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"<p><a href=""{0}climber-profile/{2}""{1}><b>{3}</b></a> just joined Climbfind and wants to meet people who climber at {4}.</p><p>They wrote: ""{5}""</p>",
                CFSettings.WebAddress, HtmlAStyle, postersUserID, postersFullName, placeName, message);
            sb.AppendFormat(@"<p>Say hello and introduce yourself by <a href=""{0}CFFeed/CommentOnPost/{2}""{1}>commenting on the thread</a>.</p>",
                CFSettings.WebAddress, HtmlAStyle, feedPostID);

            sb.AppendFormat(@"<p>To control what emails you get from Climbfind go to your <a href=""{0}PartnerCalls/Notifications""{1}>notifications settings</a>.</p>",
                CFSettings.WebAddress, HtmlAStyle, feedPostID);

            return WrapInHeaderAndFooter(sb, toEmail);
        }
        


        /// <summary>
        /// 
        /// </summary>
        public static string GenerateReplyToPartnerCallBody(Guid replyersUserID, string replyersName,
            string replyersEmail, string postersName, string postersEmail, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>You have received a reply to your partner call</h1>", HtmlH1Styles);
            sb.AppendFormat(@"<p><a href=""{0}climber-profile/{1}""{2}>{3}</a> wrote:</p><p style=""padding-left:10px;font-size:10px;width:600px"">{4}</p>",
                CFSettings.WebAddress, replyersUserID, HtmlAStyle, replyersName, message);
            sb.AppendFormat(@"<p>Please check out your <a href=""{0}ClimberProfiles/Me""{1}>profile page</a> to view the full details</p>",
                CFSettings.WebAddress, HtmlAStyle);

            return WrapInHeaderAndFooter(sb, postersEmail);
        }




        /// <summary>
        /// 
        /// </summary>
        public static string GetUserMessageBody(Guid fromUserID, string fromFullName, string toEmail,
            string subject, string message, Guid msgID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"<p>Subject: <b>{0}</b></p>", subject);

            sb.AppendFormat(@"<p>{0}</p>", message.GetHtmlParagraph());

            sb.AppendFormat(@"<p><b>What to do now:</b></p>", subject);

            sb.AppendFormat("<p>- <a href='{0}write-message/{1}?RID={4}'{2}>Reply</a><br />- Check out <a href='{0}climber-profile/{1}'{2}>{3}'s profile</a>.</p>",
                CFSettings.WebAddress, fromUserID, HtmlAStyle, fromFullName, msgID);

            return WrapInHeaderAndFooter(sb, toEmail);
        }


        /// <summary>
        /// 
        /// </summary>
        public static string GetUserMessageboardNotificationBody(Guid fromUserID, string fromFullName, string toEmail, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>{1} posted a message on your message board:</h1>", HtmlH1Styles, fromFullName);

            sb.AppendFormat(@"<p>{0}</p>", message.Replace(Environment.NewLine, "<br />"));

            sb.AppendFormat("<p>Feel free to post you own message on <a href='{0}climber-profile/{1}'{2}>{3}'s message board</a></p>",
                CFSettings.WebAddress, fromUserID, HtmlAStyle, fromFullName);

            return WrapInHeaderAndFooter(sb, toEmail);
        }


        /// <summary>
        /// 
        /// </summary>
        public static string GetMessageBoardNotificationBody(string fromFullName, string toEmail)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<h1{0}>{1} wrote on your message board</h1>", HtmlH1Styles, fromFullName);

            sb.AppendFormat("<p>Please <a href='{0}/Me'{1}>view your profile</a> to see what they wrote.</p>",
                CFSettings.WebAddress, HtmlAStyle);

            return WrapInHeaderAndFooter(sb, toEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string WrapInHeaderAndFooter(StringBuilder content, string receivingEmail)
        {
            return string.Format(HtmlHeaderAndFooterTemplate, content.ToString());
        }

        /// <summary>
        /// Private helper method
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetEmailTemplateAsString(string fileName)
        {
            return File.ReadAllText(_emailTemplateDirectory + fileName);
        }
    }
}
