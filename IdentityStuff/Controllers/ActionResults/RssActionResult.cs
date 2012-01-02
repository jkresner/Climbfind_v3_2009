using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Web.Mvc;

namespace IdentityStuff.Controllers.ActionResults
{
    public class RssActionResult : ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(Feed);
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }
        }
    }
}
