using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.News
{
    public partial class MainFeed : ViewPage
    {
        protected List<MainNewsFeedItem> AllNews;

        protected void Page_Load(Object o, EventArgs e)
        {
            AllNews = new MainNewsFeedItemDA().GetAll();
            AllNews.Reverse();
        }
    }
}
