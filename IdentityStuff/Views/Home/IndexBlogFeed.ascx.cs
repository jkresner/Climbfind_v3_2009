using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using ClimbFind.Helpers;
using ClimbFind.Controller;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using System.ServiceModel.Syndication;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml.Xsl;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace IdentityStuff.Views.Home
{
    public partial class IndexBlogFeed : System.Web.Mvc.ViewUserControl
    {
        private static int numberPerUser = 2;
        public int NumberPerUser { get { return numberPerUser; } set { numberPerUser = value; } }


        public List<CFUserSyndicationItem> SyndicatedItems { get; set; }

        protected void Page_Init(Object o, EventArgs e)
        {
            SyndicatedItems = new List<CFUserSyndicationItem>();

            //if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
            {
                List<SyndicationFeed> feeds = new List<SyndicationFeed>();


                //AddToSyndication(new Guid("485c1de2-2847-44d6-865c-8b780b2a8422"), "http://feeds2.feedburner.com/ClimbingNarc", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("a858a000-b3cb-4c5c-bb56-36930056aa6e"), "http://feeds.feedburner.com/Climbingholdreview", new ClimbingHoldreviewFeedFormatter());
                //AddToSyndication(new Guid("67c17990-1613-49e3-a538-7b43b3c24baa"), "http://feeds.feedburner.com/DreamInVertical", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("2ac9cd49-2792-412f-9916-76a2e119ff9c"), "http://feeds.feedburner.com/RockgrrlBlog", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("6b32263b-3d2a-41ff-a354-f715d5c165e4"), "http://www.b2climbing.com/?feed=rss2", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("e1c57cd2-c230-4849-97f4-87aa62cbbaaf"), "http://martinpribble.wordpress.com/feed/", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("b95e146f-ada8-4ef3-9ac5-c012d5aa87b7"), "http://www.theclimbingacademy.com/blog/rss.xml", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("130b1de1-fd5d-46f5-9df1-d6e030a4158b"), "http://feeds.feedburner.com/RockClimberGirl", new ClimberGirlFeedFormatter());
                //AddToSyndication(new Guid("9e63157f-0bc0-4470-b802-7ceae4cec430"), "http://www.bluemonkeygirl.com/blog/feed/", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("2006a9ec-c703-4b18-88c7-e5de1fa52079"), "http://www.anadventuregrrl.com/feeds/posts/default?alt=rss", new CFPerformanceFeedFormatter());
                //AddToSyndication(new Guid("31e32099-9dd0-4382-ab03-88ee53bb0a91"), "http://yukonerdownunder.blogspot.com/feeds/posts/default?alt=rss", new CFPerformanceFeedFormatter());

                SyndicatedItems.Sort(delegate(CFUserSyndicationItem p1, CFUserSyndicationItem p2) { return p2.PublishDate.CompareTo(p1.PublishDate); });
            }
        }

        private void AddToSyndication(Guid userID, string rSSUri, SyndicationFeedFormatter feedFormatter)
        {
            try
            {
                ClimberProfile owner = new CFController().GetClimberProfile(userID);

                using (XmlReader reader = XmlReader.Create(rSSUri, new XmlReaderSettings { CloseInput = true, IgnoreWhitespace = false }))
                {
                    feedFormatter.ReadFrom(reader);

                    var items = (from c in feedFormatter.Feed.Items where c.PublishDate > DateTime.Now.AddMonths(-1).AddDays(-10) select c); //.Take(NumberPerUser);

                    foreach (SyndicationItem item in items)
                    {
                        SyndicatedItems.Add(new CFUserSyndicationItem(item, owner));
                    }
                }
            }
            catch (Exception ex)
            {
                CFLogger.RecordException(ex, "Failed to load RSS from " + rSSUri);
            }
        }



        public class CFUserSyndicationItem : SyndicationItem
        {
            public ClimberProfile Owner { get { return _owner; } }
            private ClimberProfile _owner;
            
            public string Blurb
            {
                get
                {
                    if (Summary != null)
                    {
                        string stripped = Regex.Replace(Summary.Text, @"<(.|\n)*?>", string.Empty);
                        return stripped.Take(512);
                    }
                    return "Summary unavailable";
                }
            }

            public CFUserSyndicationItem(SyndicationItem item, ClimberProfile user)
                : base(item)
            {
                _owner = user;
            }
        }

        private class CFPerformanceFeedFormatter : Rss20FeedFormatter
        {
            protected override IEnumerable<SyndicationItem> ReadItems(XmlReader reader, SyndicationFeed feed, out bool areAllItemsRead)
            {
                if (feed == null) { throw new ArgumentNullException("feed"); }
                else if (reader == null) { throw new ArgumentNullException("reader"); }

                Collection<SyndicationItem> items = new Collection<SyndicationItem>();
                while (reader.IsStartElement("item") && items.Count < numberPerUser)
                {
                    items.Add(this.ReadItem(reader, feed));
                }

                areAllItemsRead = false;

                return items;
            }
        }


        private class ClimbingHoldreviewFeedFormatter : CFPerformanceFeedFormatter
        {
            protected override SyndicationItem ReadItem(XmlReader reader, SyndicationFeed feed)
            {
                SyndicationItem result = new SyndicationItem();
                reader.ReadStartElement();
                while (reader.IsStartElement())
                {
                    if (reader.IsStartElement("title")) { result.Title = new TextSyndicationContent(reader.ReadElementString()); }
                    else if (reader.IsStartElement("feedburner:origLink")) { result.Links.Add(new SyndicationLink(new Uri(reader.ReadElementString()))); }
                    else if (reader.IsStartElement("atom:summary")) { result.Summary = new TextSyndicationContent(reader.ReadElementString()); }
                    else if (reader.IsStartElement("pubDate")) { result.PublishDate = DateTime.Parse(reader.ReadElementString()); }
                    else { reader.Skip(); }
                }
                reader.ReadEndElement();
                return result;
            }
        }

        private class ClimberGirlFeedFormatter : SyndicationFeedFormatter
        {
            public override string Version { get { return "TheClimberGirlFeedBurner"; } }
            public virtual string AtomNamespaceUri { get { return "http://www.w3.org/2005/Atom"; } }

            protected override SyndicationFeed CreateFeedInstance() { return new SyndicationFeed(); }

            public override bool CanRead(XmlReader reader)
            {
                if (reader == null) { throw new ArgumentNullException("reader"); }
                return reader.IsStartElement("feed", this.AtomNamespaceUri);
            }

            public override void ReadFrom(XmlReader reader)
            {
                if (!this.CanRead(reader)) { throw new XmlException("Not ClimberGirl feed format."); }
                this.ReadFeed(reader);
            }

            private void ReadFeed(XmlReader reader)
            {
                this.SetFeed(this.CreateFeedInstance());
                this.ReadXml(reader, base.Feed);
            }

            protected virtual void ReadXml(XmlReader reader, SyndicationFeed result)
            {
                if (result == null) { throw new ArgumentNullException("result"); }
                else if (reader == null) { throw new ArgumentNullException("reader"); }

                reader.ReadStartElement();              // Read in <feed>

                while (reader.IsStartElement())
                {
                    if (reader.IsStartElement("entry"))
                    {
                        bool allItemsRead;
                        result.Items = this.ReadItems(reader, result, out allItemsRead);
                        break;
                    }
                    else { reader.Skip(); }
                }
            }

            public virtual IEnumerable<SyndicationItem> ReadItems(XmlReader reader, SyndicationFeed feed, out bool areAllItemsRead)
            {
                if (feed == null) { throw new ArgumentNullException("feed"); }
                else if (reader == null) { throw new ArgumentNullException("reader"); }

                Collection<SyndicationItem> items = new Collection<SyndicationItem>();
                while (reader.IsStartElement("entry") && items.Count < numberPerUser) 
                {
                    SyndicationItem result = new SyndicationItem();
                    reader.ReadStartElement();
                    while (reader.IsStartElement())
                    {
                        if (reader.IsStartElement("title")) { result.Title = new TextSyndicationContent(reader.ReadElementString()); }
                        else if (reader.IsStartElement("link") && reader.GetAttribute("rel") == "alternate")
                        {
                            result.Links.Add(new SyndicationLink(new Uri(reader.GetAttribute("href"))));
                            reader.ReadElementString();
                        }
                        else if (reader.IsStartElement("content")) { result.Summary = new TextSyndicationContent(reader.ReadElementString()); }
                        else if (reader.IsStartElement("published")) { result.PublishDate = DateTime.Parse(reader.ReadElementString()); }
                        else { reader.Skip(); }
                    }
                    reader.ReadEndElement();
                    items.Add(result); 
                }

                areAllItemsRead = false;

                return items;
            }

            public override void WriteTo(XmlWriter writer)
            {
                throw new Exception("This class does not create feeds");
            }
        }
    }
}

//private XmlReader TransformXmlDocument(string rSSUri)
//{
//    // Load the style sheet.
//    XslCompiledTransform xslt = new XslCompiledTransform();
//    xslt.Load(Server.MapPath("~/Views/Blog/RSSTransformHelper.xslt"));

//    // Transform the node fragment.
//    XPathDocument transformedDoc;

//    using (MemoryStream inMemoryTransformedXML = new MemoryStream())
//    {
//        XmlTextWriter wr = new XmlTextWriter(inMemoryTransformedXML, Encoding.UTF8);
//        xslt.Transform(rSSUri, wr);
//        inMemoryTransformedXML.Capacity = (int)inMemoryTransformedXML.Length;
//        inMemoryTransformedXML.Position = 0;
//        //File.WriteAllBytes(@"C:\Debug.xml", inMemoryTransformedXML.GetBuffer());
//        transformedDoc = new XPathDocument(inMemoryTransformedXML);
//        wr.Close();
//        inMemoryTransformedXML.Close();
//    }

//    XPathNavigator nav = transformedDoc.CreateNavigator();
//    return nav.ReadSubtree();
//}
