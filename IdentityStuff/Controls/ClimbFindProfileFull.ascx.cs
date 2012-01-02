using System.Web.Mvc;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Controls
{
    public partial class ClimbFindProfileFull : ViewUserControl<ClimberProfile>
    {
        public ClimberProfile climberProfile { get { return ViewData.Model; }}
    }
}
