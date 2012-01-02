using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class FeedClimberChannelRequest : ClimbFind.Model.LinqToSqlMapping.FeedClimberChannelRequest
    {
        public bool Approved { get { return ApprovedDateTime.HasValue; } }

        public bool CanRequest { get { return ID == 0; } }
    }
}
