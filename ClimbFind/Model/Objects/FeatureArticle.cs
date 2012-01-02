using LinqToSql_FeatureArticle = ClimbFind.Model.LinqToSqlMapping.FeatureArticle;

namespace ClimbFind.Model.Objects
{
    public partial class FeatureArticle : LinqToSql_FeatureArticle
    {
        public string ClimbfindUrl
        {
            get
            {
                return string.Format("/Feature-Article/{0}/{1}", this.Date.ToString("yyyy-MM-dd"), this.FriendlyUrl);
            }
        }
    }
}

