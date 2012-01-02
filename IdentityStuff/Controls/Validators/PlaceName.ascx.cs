using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class PlaceName : BaseVAL
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Minimum = 1;
            Maximum = 100;

            LoadRegExValidator(PlaceNameRegExVAM);
            LoadLengthValidator(PlaceNameLengthVAM);
        }
    }
}
