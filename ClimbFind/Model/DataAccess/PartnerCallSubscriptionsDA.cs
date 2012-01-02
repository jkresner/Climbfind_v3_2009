using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_PartnerCallSubscription = ClimbFind.Model.LinqToSqlMapping.PartnerCallSubscription;


namespace ClimbFind.Model.DataAccess
{
    public class PartnerCallSubscriptionDA : AbstractBaseDA<PartnerCallSubscription, LinqToSql_PartnerCallSubscription, Guid> 
    {
        public PartnerCallSubscription Get(Guid userID, int placeID)
        {
            LinqToSql_PartnerCallSubscription subscription = (from c in ctx.PartnerCallSubscriptions where c.UserID == userID && c.PlaceID == placeID select c).SingleOrDefault();
            if (subscription == default(LinqToSql_PartnerCallSubscription))
            {
                subscription = new LinqToSql_PartnerCallSubscription() { ID = Guid.NewGuid(), PlaceID = placeID, UserID = userID };
                ctx.PartnerCallSubscriptions.InsertOnSubmit(subscription);
                CommitChanges();
            }

            return MapType(subscription);
        }


        public List<PartnerCallSubscription> GetUsersPartnerCallSubscriptions(Guid userID)
        {
            return MapList((from c in ctx.PartnerCallSubscriptions where c.UserID == userID select c).ToList());
        }
    
    }
}
