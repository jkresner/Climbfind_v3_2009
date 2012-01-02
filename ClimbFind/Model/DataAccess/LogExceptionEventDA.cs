using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_LogExceptionEvent = ClimbFind.Model.LinqToSqlMapping.LogExceptionEvent;
using System.Collections.Generic;


namespace ClimbFind.Model.DataAccess
{
    public class LogExceptionEventDA : AbstractBaseDA<LogExceptionEvent, LinqToSql_LogExceptionEvent, int>
    {
        public List<LogExceptionEvent> GetLastNExceptions(int n)
        {
            return MapList((from c in EntityTable orderby c.ID descending select c).Take(n).ToList());
        }
        
    }

}
