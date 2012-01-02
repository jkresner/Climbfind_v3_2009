using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class UserSettings : ClimbFind.Model.LinqToSqlMapping.UserSetting
    {
        public new PlaceType PartnerSearchPlaceType { get { return (PlaceType)base.PartnerSearchPlaceType; } set { base.PartnerSearchPlaceType = (short)value; } }
    }
}
