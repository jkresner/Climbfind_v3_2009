using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;
using ClimbFind.Web.Mvc.Models.ViewData;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class Moderators : ClimbFindViewPage<ISessionViewData>
    {
        public List<ClimberProfile> Mods { get; set; }

        protected void Page_Init(Object s, EventArgs e)
        {

        
        }
    }
}
