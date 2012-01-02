using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class Password : BaseVAL
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Minimum = 5;
            Maximum = 15;

            LoadLengthValidator(PasswordLengthVAM);
        }
    }
}
