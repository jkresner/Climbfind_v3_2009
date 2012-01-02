using System;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_FeatureArticle = ClimbFind.Model.LinqToSqlMapping.FeatureArticle;


namespace ClimbFind.Model.DataAccess
{
    public class FeatureArticleDA : AbstractBaseDA<FeatureArticle, LinqToSql_FeatureArticle, int>
    {
        /// <summary>
        /// 
        /// </summary>
        public FeatureArticle Get(DateTime date, string friendlyUrl)
        {
            return MapType((from c in ctx.FeatureArticles where c.Date == date && c.FriendlyUrl == friendlyUrl select c).SingleOrDefault());
        }
    }
}
