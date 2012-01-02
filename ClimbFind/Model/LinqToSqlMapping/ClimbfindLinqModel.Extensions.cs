using System;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.LinqToSqlMapping
{
    public partial class Advertisement : IKeyObject<Guid> { }	

    public partial class ClimbfindLinqModelDataContext : IDATransactionContext { }	
    
    public partial class Feedback : IKeyObject<int> { }

    public partial class Club : IKeyObject<int> { }

	public partial class Competition : IKeyObject<int> { }

    public partial class FeatureArticle : IKeyObject<int> { }

    public partial class FeatureArticlePhotoSet : IKeyObject<Guid> { }

    public partial class PartnerWidgetCSS : IKeyObject<string> { }

    public partial class SpecialPagesHTML : IKeyObject<int> { }

    public partial class LogExceptionEvent : IKeyObject<int> { }

    public partial class LogEvent : IKeyObject<int> { }

    public partial class MainNewsFeedItem : IKeyObject<DateTime> { }

    public partial class UserSetting : IKeyObject<Guid> { }

    public partial class UserMessage : IKeyObject<Guid> { }

    public partial class Place : IKeyObject<int> { }

    public partial class MediaShare : IKeyObject<Guid> { }

    public partial class PlaceOutdoorDetail : IKeyObject<int> { }

    public partial class PlaceOutdoorAuthority : IKeyObject<int> { }

    public partial class PlaceOutdoorCrag : IKeyObject<Guid> { }

    public partial class PlaceIndoorDetail : IKeyObject<int> { }

    public partial class AreaTag : IKeyObject<int> { }

    public partial class PartnerCall : IKeyObject<Guid> { }

    public partial class PartnerCallReply : IKeyObject<Guid> { }

    public partial class PartnerCallSubscription : IKeyObject<Guid> { }

    public partial class MessageBoard : IKeyObject<Guid> { }

    public partial class MessageBoardMessage : IKeyObject<Guid> { }

    public partial class ClimberProfile : IKeyObject<Guid> { }

    public partial class ClimberProfileExtended : IKeyObject<Guid> { }

    public partial class ClimberProfilePartnerStatus : IKeyObject<byte> { }

    public partial class AdClick : IKeyObject<int> { }
}
