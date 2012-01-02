using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_FeatureArticlePhotoSet = ClimbFind.Model.LinqToSqlMapping.FeatureArticlePhotoSet;


namespace ClimbFind.Model.DataAccess
{
    public class PhotoSetDA : AbstractBaseDA<PhotoSet, LinqToSql_FeatureArticlePhotoSet, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PhotoSet> Get(int featureArticleID)
        {
            return MapList((from c in ctx.FeatureArticlePhotoSets where c.FeatureArticleID == featureArticleID select c).ToList());
        }
    }
}
