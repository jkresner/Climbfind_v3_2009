using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Home
{
    public partial class IndexNewsFeed : System.Web.Mvc.ViewUserControl
    {
        protected List<MainNewsFeedItem> LatestNews;

        protected void Page_Init(Object o, EventArgs e)
        {
            LatestNews = new MainNewsFeedItemDA().GetLastN(4);
        }  
    }
}