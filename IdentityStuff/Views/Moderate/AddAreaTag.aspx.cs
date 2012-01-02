using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.Mvc.Models.ViewData;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class AddAreaTag : ClimbFindViewPage<ISessionViewData>
    {

        protected void CreateAreaTag_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                //-- Validate country is not unknown or UK

                string friendlyUrlName = NameTxB.Text.Replace(" ", "-").ToLower();

                AreaTag tag = new AreaTag
                {
                    DefaultVirtualEarthZoom = 8,
                    FriendlyUrlName = friendlyUrlName,
                    Latitude = 0,
                    Longitude = 0,
                    Name = NameTxB.Text,
                    ParagraphName = ParagraphNameTxB.Text,
                    CountryID = (short)NationalityDDLUC.SelectedNation
                };

                AreaTag newTag = cfController.AddAreaTag(tag);
                RedirectTo<ModerateController>(c => c.EditAreaTag(newTag.ID));

            }
        }

    }
}
