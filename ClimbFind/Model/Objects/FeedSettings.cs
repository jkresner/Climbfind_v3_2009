using ClimbFind.Model.Enum;
using System.Collections.Generic;

namespace ClimbFind.Model.Objects
{
    public class FeedSettings : ClimbFind.Model.LinqToSqlMapping.FeedSetting
    {
        public bool HasPlace { get { return PlaceID.HasValue; } }
        public bool HasArea { get { return AreaID.HasValue; } }
        public bool HasTag { get { return TagID.HasValue; } }
        public List<FeedClimberChannelRequest> WatchedClimbers { get; set; }
    }
}
