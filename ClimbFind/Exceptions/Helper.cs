using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ClimbFind.Controller;

namespace ClimbFind.Exceptions
{
    public static class ErrorHelper
    {
        public static bool ShouldRecord(this Exception ex, string relativeUrl)
        {
            if (SpecialUrls.Instance.UrlsGone.Contains(relativeUrl)) { return false; }
            if (SpecialUrls.Instance.PermanentlyMoved.Keys.Contains(relativeUrl)) { return false; }
            
            string p = ex.Message;
            
            //***********
            // - Think about not recording "Unable to validate data." repetition?
            //*******************


            //-- MS Office toolbar shit
            if (p.Contains("MSOffice/cltreq.asp") || p.Contains("_vti_bin/owssvr.dll")) { return false; }
            
            //-- Stop recording 301
            if (p.Contains(".php")) { return false; }
            
            //-- search engine photo not found
            if (p.Contains("Photo not found")) { return false; }
            
            //-- Stop recording 301
            if (p.Contains("Thread was being aborted")) { return false; }

            return true;
        }
    }
}
