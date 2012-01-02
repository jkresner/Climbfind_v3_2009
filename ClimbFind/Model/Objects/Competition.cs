using LinqToSql_Competition = ClimbFind.Model.LinqToSqlMapping.Competition;

namespace ClimbFind.Model.Objects
{
    public partial class Competition : LinqToSql_Competition
    {
        public string ClimbfindUrl
        {
            get
            {
                return string.Format("/News/Competitions/{0}/{1}", this.Date.ToString("yyyy-MM-dd"), this.FriendlyUrl);
            }
        }
    }
}

