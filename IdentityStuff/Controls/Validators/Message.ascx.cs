using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class Message : BaseVAL
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Minimum = 1;
            
            LoadLengthValidator(MessageVAM);
        }
    }
}
