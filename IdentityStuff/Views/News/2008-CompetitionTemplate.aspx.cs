using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.News
{
    public partial class _2008_12_Alien_Bouldering_Competition : ClimbFindViewPage<Competition>
    {
        public Competition Comp { get { return ViewData.Model;} }
        
        //public DateTime Date { get; set; }

        //public string ArticleHeading { get; set; }
        //public string ArticleTextHtml { get; set; }
        public string ArticleMainPhoto1Url { get { return string.Format("/images/news/{0}/{1}", Comp.ContentDirectory, Comp.ArticleMainPhoto1); } }
        public string ArticleMainPhoto2Url { get { return string.Format("/images/news/{0}/{1}", Comp.ContentDirectory, Comp.ArticleMainPhoto2); } }
        public string ArticleMainPhoto3Url { get { return string.Format("/images/news/{0}/{1}", Comp.ContentDirectory, Comp.ArticleMainPhoto3); } }      

        //public string PhotoHeading1 { get; set; }        
        public string PhotoWebDirectory1
        {
            get { return string.Format(@"/images/news/{0}/PhotosSet1", Comp.ContentDirectory); }
        }

        public List<string> PhotoImageNames1 { get; set; }

        public string PhotoWebDirectory2
        {
            get { return string.Format(@"/images/news/{0}/PhotosSet2", Comp.ContentDirectory); }
        }

        public List<string> PhotoImageNames2 { get; set; }
        public bool PageHasSecondSetOfPhone { get { return !String.IsNullOrEmpty(Comp.PhotoHeading2); } }


        public void Page_Load(Object o, EventArgs e)
        {            
        }
    }
}
