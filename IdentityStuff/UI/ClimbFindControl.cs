using System;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.UI
{
    public class ClimbFindControl : BaseControl
    {      
        public UserSettings UsersSearchSettings { get 
            { return new CFController().GetUserSearchSettings(UserID); } }
        
        protected void Page_InitComplete(object sender, EventArgs e)
        {
        }
    }
}
