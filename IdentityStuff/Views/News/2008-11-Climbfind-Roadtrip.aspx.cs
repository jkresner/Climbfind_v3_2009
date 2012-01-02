using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IdentityStuff.Views.News
{
    public partial class _2008_11_Climbfind_Roadtrip : ViewPage
    {
        public List<string> FavoritePhotos { get; set; }     
        
        public void Page_Load(Object o, EventArgs e)
        {
            string[] imagePaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"images\news\2008-Climbfind-UK-Roadtrip");
            FavoritePhotos = (from c in imagePaths select Path.GetFileName(c)).ToList();
        }
    }
}
