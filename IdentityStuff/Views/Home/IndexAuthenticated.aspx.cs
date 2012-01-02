using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;
using ClimbFind.Model.DataAccess;

namespace ClimbFind.Web.Mvc.Views.Home
{
    public partial class IndexAuthenticated : ClimbFindViewPage<ISessionViewData>
    {
        protected void Page_Init(Object o, EventArgs e)
        {
            
 
        }
        //private void InsertSomePosts()
        //{
        //    List<ClimberProfile> CFMembers =
        //        (from c in new ClimberProfileDA().GetAll() where !c.IsUnfinished select c).ToList();
          
        //    for (int i = 0; i < 25; i++)
        //    {
        //        int randomUserSeed = CFExtensions.GetRandomNumber(1, CFMembers.Count-10);
        //        ClimberProfile randomUser = CFMembers[randomUserSeed];

        //        int randomPlaceSeed = CFExtensions.GetRandomNumber(1, CFDataCache.AllPlaces.Count - 10);
        //        Place randomPlace = CFDataCache.AllPlaces[randomPlaceSeed];

        //        int randomDasSeed = CFExtensions.GetRandomNumber(1, 15);

        //        cfController.SaveFeedPost( new FeedClimbingPost { UserID = randomUser.ID, PlaceID = randomPlace.ID,
        //         ClimbingDateTime = DateTime.Now.AddDays(randomDasSeed),
        //         Message = string.Format("Test {0} again {1}", randomUserSeed, randomPlaceSeed),
        //         TagID = 1
        //        });

        //        System.Threading.Thread.Sleep(1000);
        //    }
        //}
    }
}
