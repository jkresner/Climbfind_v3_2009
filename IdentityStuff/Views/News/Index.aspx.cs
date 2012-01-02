using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.News
{
    public partial class Index : ViewPage
    {
        protected List<MainNewsFeedItem> LatestNews;

        protected void Page_Load(Object o, EventArgs e)
        {
            LatestNews = new MainNewsFeedItemDA().GetAll();
            LatestNews.Reverse();
            LatestNews = LatestNews.Take(15).ToList();
        }        
    }
}
