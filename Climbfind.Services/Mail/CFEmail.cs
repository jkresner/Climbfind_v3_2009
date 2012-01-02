using System.Net.Mail;

namespace ClimbFind.Model.Objects
{
    internal class CFEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailAddress To { get; set; }
        public MailAddress From { get; set; }
    }
}
