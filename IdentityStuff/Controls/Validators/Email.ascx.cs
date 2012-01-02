using System;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public partial class Email : BaseVAL
    {
        private bool _required = true;

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Minimum = 8;
            Maximum = 60;

            EmailVAM.ControlIDToEvaluate = TargetID;
            EmailVAM.IgnoreBlankText = !_required;

            LoadLengthValidator(LengthVAM);
            LengthVAM.IgnoreBlankText = !_required;
        }

    }
}
