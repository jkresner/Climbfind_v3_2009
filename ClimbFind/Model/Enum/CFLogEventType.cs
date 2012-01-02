
namespace ClimbFind.Model.Enum
{
    public enum CFLogEventType
    {
        All = 0,
        Exception = 1,
        Registration = 5,
        DeleteAccount = 7,
        SignIn = 10,
        PartnerCallCreate = 20,
        PartnerCallReply = 22,
        PartnerCallEmailSubscribe = 24,
        PartnerCallRSSSubscribe = 25,
        PartnerCallUnsubscribe = 27,
        PartnerCallDelete = 29,
        GroupCreate = 30,
        GroupJoin = 32,
        GroupLeave = 33,
        GroupInvitationCreate = 35,
        GroupInvitationAccept = 36,
        GroupInvitationDecline = 37,
        GroupRollCallCreate = 40,
        GroupRollCallReply = 42,
        ClubCreate = 51,
        ClubJoin = 52,
        ClubLeave = 53, 
        AdClickGeneric = 100,
        AdClickBooktopia = 110,
        ModerateAddAreaTag = 151,
        ModerateEditAreaTag = 152,
        ModerateAddPlace = 153,
        ModerateDeletePlace = 154,
        ModerateAddCrag = 156,
        ModerateDeleteCrag = 157,
        ModerateEdit = 160,
        GroupPageView = 230,
        PageView = 255
    }
        
}
