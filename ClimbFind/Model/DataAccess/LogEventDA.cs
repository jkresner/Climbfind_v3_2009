using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using LinqToSql_LogEvent = ClimbFind.Model.LinqToSqlMapping.LogEvent;

namespace ClimbFind.Model.DataAccess
{
    public class LogEventDA : AbstractBaseDA<LogEvent, LinqToSql_LogEvent, int>
    {
        public List<LogEvent> GetLastN(int n)
        {
            return MapList((from c in EntityTable orderby c.ID descending select c).Take(n).ToList());
        }

        public List<LogEvent> Get(Guid userID, CFLogEventType eventType)
        {
            int eventTypeID = (int)eventType;
            var query = default(IQueryable<LinqToSql_LogEvent>);

            if (userID == Guid.Empty && eventType == CFLogEventType.All) { return GetAll(); }
            else if (userID != Guid.Empty && eventType != CFLogEventType.All)
            {
                query = from c in EntityTable
                        where
                            c.EventType == eventTypeID &&
                            c.UserID == userID
                        select c;
            }
            else if (eventType == CFLogEventType.All)
            {
                query = from c in EntityTable
                        where c.UserID == userID
                        select c;
            }
            else
            {
                query = from c in EntityTable
                        where c.EventType == eventTypeID
                        select c;
            }

            return MapList(query.ToList());
        }
    }
}
