using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Ads
{
    public partial class Report : ClimbFindViewPage<AdClient>
    {
        public AdClient Client { get { return ViewData.Model;} }
        public List<AdProduct> Products { get; set; }
        public List<Ad> Ads { get; set; }
        public Dictionary<int, List<AdClick>> AdClicks { get; set; }

        public int TotalClicks { get {
            int j = 0; foreach (int key in AdClicks.Keys) { j += AdClicks[key].Count; }
            return j;
            ;} }

        public int TotalImpressions
        {
            get
            {
            int j = 0; foreach (Ad a in Ads) { j += a.Impressions; }
            return j;
            ;} }

        


        protected void Page_Init(Object o, EventArgs e)
        {
            Products = cfController.GetClientsProducts(Client.ID);
            Ads = cfController.GetClientsAds(Client.ID);

            AdClicks = new Dictionary<int, List<AdClick>>();
            foreach (Ad a in Ads)
            {
                AdClicks.Add(a.ID, cfController.GetAdClickForAd(a.ID));
            }
        }
    }
}
