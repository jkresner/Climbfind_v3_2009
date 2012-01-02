using System.Collections.Generic;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class ProfileLinkWithPictureList : System.Web.Mvc.ViewUserControl<List<ClimberProfile>>
    {
        private short _ColumnWidth = 5;
        public short ColumnWidth { get { return _ColumnWidth; } set { _ColumnWidth = value; } }

        public List<ClimberProfile> Profiles { get { return ViewData.Model; } }
    }
}
