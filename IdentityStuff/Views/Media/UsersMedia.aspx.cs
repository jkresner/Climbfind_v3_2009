using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using System.Collections.Generic;

namespace IdentityStuff.Views.Media
{
    public partial class UsersMedia : ClimbFindViewPage<ClimberProfile>
    {
        public ClimberProfile UserWithMedia { get { return ViewData.Model;} }
        public List<MediaShare> Media { get; set; }


        protected void Page_Init(Object s, EventArgs e)
        {
            Media = cfController.GetAllUsersMedia(UserWithMedia.ID);
        }
    }
}
