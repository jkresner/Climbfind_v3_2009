using System;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_MainNewsFeedItem = ClimbFind.Model.LinqToSqlMapping.MainNewsFeedItem;
using System.Collections.Generic;


namespace ClimbFind.Model.DataAccess
{
    public class MainNewsFeedItemDA : AbstractBaseDA<MainNewsFeedItem, LinqToSql_MainNewsFeedItem, DateTime>
    {
        public List<MainNewsFeedItem> GetLastN(int n)
        {
            return MapList((from c in EntityTable orderby c.ID descending select c).Take(n).ToList());
        }
    }
}
