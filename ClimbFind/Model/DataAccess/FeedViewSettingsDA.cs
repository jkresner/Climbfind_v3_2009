using System;
using ClimbFind.Model.Objects;
using LinqToSql_FeedSettings = ClimbFind.Model.LinqToSqlMapping.FeedSetting;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.DataAccess
{
    public class FeedSettingsDA : AbstractBaseDA<FeedSettings, LinqToSql_FeedSettings, Guid>
    {
        public new FeedSettings Update(FeedSettings t)
        {
            LinqToSql_FeedSettings lt = MapValues(GetLinqTypeByID(t.ID), t);
            lt.TagID = t.TagID;
            return Update(lt);
        }

        public new FeedSettings UpdateIfNecessary(Guid id, FeedChannel channel, int? areaID, int? placeID)
        {
            LinqToSql_FeedSettings lt = GetLinqTypeByID(id);
            
            if (lt.CurrentChannelType != (byte)channel ||
                lt.AreaID != areaID ||
                lt.PlaceID != placeID)
            {
                   lt.PlaceID = placeID;
                lt.AreaID = areaID;
                lt.CurrentChannelType = (byte)channel;
                return Update(lt);
            }

            return MapType(lt);
        }
    }
}
