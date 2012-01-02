using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class Length : BaseVAL
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            LoadLengthValidator(LengthVAM);
        }
    }
}
