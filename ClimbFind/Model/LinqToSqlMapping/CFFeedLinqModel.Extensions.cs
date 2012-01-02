using System;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.LinqToSqlMapping
{   
    public partial class FeedClimbingPost : IKeyObject<int> { }
    public partial class FeedPostComment : IKeyObject<int> { }
    public partial class FeedClimberChannelRequest : IKeyObject<int> { }
    public partial class FeedTag : IKeyObject<byte> { }
    public partial class FeedSetting : IKeyObject<Guid> { }
    public partial class HomepagePartnerCallSetting : IKeyObject<Guid> { }
}
