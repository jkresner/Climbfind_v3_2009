using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class GroupName : BaseVAL
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Minimum = 1;
            Maximum = 60;

            LoadRegExValidator(GroupNameRegExVAM);
            LoadLengthValidator(GroupNameLengthVAM);
        }
    }
}
