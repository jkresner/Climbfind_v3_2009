using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Mail
{
    public static class SMTP
    {
        //--------------------------------------------------------------------------------//
        //-- Constructor -----------------------------------------------------------------//
        //--------------------------------------------------------------------------------//

        static SMTP()
        {
        }

        //--------------------------------------------------------------------------------//
        //--- Base sending methods -------------------------------------------------------//
        //--------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//

        private static void DotNetSend(CFEmail mailToSend)
        {
            if (CFSettings.IsDevelopmentEnvironment)
            {
                string filePath = string.Format(@"C:\cfmail\ssss.html"); //,
                //DateTime.Now.ToString().Replace("/", "").Replace(":", ""), mailToSend.Subject);

                File.WriteAllText(filePath, mailToSend.Body);
            }
            else
            {
                MailMessage mail = new MailMessage(CFSettings.MailMan, mailToSend.To);
                mail.Subject = mailToSend.Subject;
                mail.Body = mailToSend.Body;
                mail.IsBodyHtml = true;

                CFSettings.MailServer.Send(mail);
            }
        }

        //--------------------------------------------------------------------------------//

        public static void SendAppEvent(string subject, string body, string email)
        {
            DotNetSend(new CFEmail
            {
                Subject = subject,
                Body = body,
                To = new MailAddress(email, "CFAdmin"),
                From = CFSettings.MailMan
            });
        }

        //--------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//

        /// <summary>
        /// Checks users emails settings to make sure user has not opted out of receiving emails or 
        /// the email address has not previously bounced
        /// </summary>

        //public static bool allowedToSendToRecipient(string toEmailAddress, EmailType emailType, SqlConnection conn)
        //{
        //    //-- Review if can get email setting by emailSettings ID
        //    UserEmailSettings emailSettings = UserEmailSettingsDA.getEmailSettingsByEmail(toEmailAddress, false, conn);

        //    if (emailSettings == null)
        //    {
        //        new UserEmailSettings(toEmailAddress, conn);
        //        return (true);
        //    }
        //    else { return (allowedToSendToRecipient(emailSettings, emailType)); }
        //}

        //--------------------------------------------------------------------------------//

        //int emailSettingsId
        //PPEmailSettings emailSettings = (new PPEmailSettingsDA()).getEmailSettingsById(emailSettingsId, conn);

        //public static EmailSentStatus calculatePreSendStatusFromSettings(PPEmailSettings emailSettings, EmailType emailType)
        //{
        //    if (emailSettings.SPAMComplaint) { return (EmailSentStatus.UserEmailHasSpamComplaint); }
        //    else if (emailSettings.Bounced) { return (EmailSentStatus.UserEmailHasPreviousBounce); }
        //    else if (emailSettings.BlackListed) { return (EmailSentStatus.InvalidEmail); }
        //    else
        //    {
        //        if (emailType == EmailType.Invitation && !emailSettings.EventInvitation
        //            || emailType == EmailType.Slideshow && !emailSettings.EventSlideshow
        //            || emailType == EmailType.PartySurvey && !emailSettings.EventQuestionnaire)
        //        {
        //            // user setting dissalows us from sending the email
        //            return (EmailSentStatus.UserSettingsDissalowsEmailSending);
        //        }
        //    }

        //    return (EmailSentStatus.CanSendEmail);
        //}

        //--------------------------------------------------------------------------------//
        //- createAndSendMail is for single mail messages that need to 
        //- be sent straight away
        //--------------------------------------------------------------------------------//

        internal static void PostSingleMail(CFEmail mailToSend)
        {
            //using (SqlConnection conn = new SqlConnection(PPApp.MainPPConnStr))
            //{
            //	conn.Open();

            //- 1. Send email off if user has not opted out of recieving mail	
            //	if (allowedToSendToRecipient(mailToSend.ToAddress, mailToSend.Type, conn))
            //	{
            //if (PPApp.AppMode != ApplicationMode.Beta_DisountASP) { hurricaneSend(mailToSend); }
            //else {  }
            DotNetSend(mailToSend);
            //	}
            //}
        }

        //--------------------------------------------------------------------------------//

        internal static void PostBatchMail(List<CFEmail> mailToSend)
        {
            foreach (CFEmail email in mailToSend)
            {
                DotNetSend(email);
            }
        }


    }
}
