using System;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Clubs
{
    public partial class New : ClimbFindViewPage<ISessionViewData>
    {
        protected void AddClub_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                Club club = new Club {
                    CreatedByUserID = UserID,
                    Name = NameTxB.Text,
                    FriendlyUrlName = NameTxB.Text.GetFriendUrlFromString(),
                    Website = WebsiteTxB.Text,
                    CountryID = (short)CountryDDL.SelectedNation,
                    Description = DescriptionTxB.Text,
                    LogoImageFile = "Default.jpg", 
                    AreaCode = AreaCodeTxB.Text,
                    ContactEmail = ContactEmailTxB.Text
                };
                
                Club newClub = cfController.CreateClub(club);
                RedirectTo<ClubsController>(c => c.Detail( ((Nation)newClub.CountryID).GetCountryFriendlyUrl(), newClub.FriendlyUrlName));
            }
        }
    }
}
