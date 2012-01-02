
namespace ClimbFind.Model.Objects
{
    public class PartnerCallReply : ClimbFind.Model.LinqToSqlMapping.PartnerCallReply
    {
        public PartnerCall OriginalCall { get; set; }
        public string ReplyingName { get; set; } 
    }
}
