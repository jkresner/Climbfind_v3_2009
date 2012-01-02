using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_AdClick = ClimbFind.Model.LinqToSqlMapping.AdClick;

namespace ClimbFind.Model.DataAccess
{
    public class AdClickDA : AbstractBaseDA<AdClick, LinqToSql_AdClick, int>
    {

        public List<AdClick> GetAdClicksForAd(int adID)
        {
            return MapList((from c in EntityTable where c.AdID == adID select c).ToList());
        }
    }

}
