using System;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_Competition = ClimbFind.Model.LinqToSqlMapping.Competition;


namespace ClimbFind.Model.DataAccess
{
    public class CompetitionDA : AbstractBaseDA<Competition, LinqToSql_Competition, int>
    {
        /// <summary>
        /// 
        /// </summary>
        public Competition Get(DateTime date, string friendlyUrl)
        {
            return MapType((from c in ctx.Competitions where c.Date == date && c.FriendlyUrl == friendlyUrl select c).SingleOrDefault());
        }
    }
}
