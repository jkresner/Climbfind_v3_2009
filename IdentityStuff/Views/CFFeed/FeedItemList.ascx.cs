using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects.Interfaces;
using ClimbFind.Model.DataAccess;


namespace IdentityStuff.Views.CFFeed
{
    public partial class FeedItemList : System.Web.Mvc.ViewUserControl<List<IFeedItem>>
    {
        public List<IFeedItem> FeedItems { get { return ViewData.Model;} }
        public Guid UserID { get { return CFProfile.UserID; } }
    }
}
