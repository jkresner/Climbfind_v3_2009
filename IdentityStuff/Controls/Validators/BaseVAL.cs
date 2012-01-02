using System;
using System.Web.UI;

namespace ClimbFind.Web.Mvc.Controls.Validators
{
    public abstract class BaseVAL : UserControl
    {
        //--------------------------------------------------------------------------------//
        //- Attributes -------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//

        protected int _maximum = 255, _minimum = 5;

        public int Maximum { get { return _maximum; } set { _maximum = value; } }
        public int Minimum { get { return _minimum; } set { _minimum = value; } }

        public string FieldName { get; set; }
        public string Group { get; set; }
        public string TargetID { get; set; }

        public bool IgnoreBlankText { get; set; }

        public bool HasGroup { get { return !String.IsNullOrEmpty(Group); } }

        //--------------------------------------------------------------------------------//
        //- Constructor ------------------------------------------------------------------//
        //--------------------------------------------------------------------------------//

        protected BaseVAL() { }

        //----------------------------------------------------------------------------//

        protected PeterBlum.VAM.MultiConditionValidator _validator;

        //----------------------------------------------------------------------------//

        protected void LoadLengthValidator(PeterBlum.VAM.TextLengthValidator validator)
        {
            validator.ControlToEvaluate = this.Parent.FindControl(TargetID);

            validator.IgnoreBlankText = IgnoreBlankText;

            if (_minimum == default(int)) { _minimum = 1; }
            if (_maximum == default(int)){ _maximum = 30; }

            validator.Minimum = _minimum;
            validator.Maximum = _maximum;
            validator.ErrorMessage = 
                String.Format("{0} must be between {1:G} and {2:G} characters long.",
                    FieldName, _minimum, _maximum);
            
            if (HasGroup) { validator.Group = Group; }
        }

        protected void LoadRegExValidator(PeterBlum.VAM.RegexValidator validator)
        {
            validator.ControlToEvaluate = this.Parent.FindControl(TargetID);

            if (HasGroup) { validator.Group = Group; }
        }

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FieldName))
            {
                throw new NotImplementedException("FieldName not specified");
            }
        }
    }
}
