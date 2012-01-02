using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Content;
using ClimbFind.Mail;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Exceptions;
using System.Web;


namespace ClimbFind.Controller
{
    public partial class CFController
    {
        List<String> Climbfindians = new List<string>()
        {
            "jkresner@yahoo.com.au"
        };
        
        public void RecordAdClick(int adID, string srcUrl)
        {
            Guid userID = Guid.Empty;
            if (User.IsAuthenticated) { userID = CurrentClimber.ID; }
        
            new AdClickDA().Insert( new AdClick() { AdID = adID, ClickDateTime = DateTime.Now, 
                SrcUrl = srcUrl, UserID = userID } );
        }


        public Ad GetAdAndRecordImpression(int adID, string adUnitID)
        {
            AdDA da = new AdDA();
            
            Ad currentAd = da.GetByID(adID);

            if (currentAd.SrcAdUnitID != adUnitID) { 
                throw new Exception(string.Format("AdUnitID[{0}] for ad[{1}] on page [{2}] does not match", 
                    adUnitID, adID, HttpContext.Current.Request.Url)); }

            if (User.IsAuthenticated)
            {
                if (Climbfindians.Contains(User.Name)) { return currentAd; }
            }

            try
            {
                da.AddOneImpression(adID); 
            }
            catch (Exception ex)
            {
                CFLogger.RecordException(ex);
            }

            return currentAd;            
        }


        public AdClient GetAdClient(int id)
        {
            return new AdClientDA().GetByID(id);
        }


        public List<AdProduct> GetClientsProducts(int id)
        {
            return new AdProductDA().GetClientsProducts(id);
        }

        public List<Ad> GetClientsAds(int id)
        {
            return new AdDA().GetClientsAds(id);
        }

        public List<AdClick> GetAdClickForAd(int id)
        {
            return new AdClickDA().GetAdClicksForAd(id);
        }
        

    }
}
