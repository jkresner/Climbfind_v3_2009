using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.News
{
    public partial class FeatureArticles : ViewPage
    {
        public List<FeatureArticle> Articles { get; set; }

        public void Page_Init(Object o, EventArgs e)
        {
            Articles = new FeatureArticleDA().GetAll().OrderBy(c => c.Date).ToList();
            Articles.Reverse();
        }
    }
}
