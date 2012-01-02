using System.Web.UI;

namespace ClimbFind.Web.UI.Adapters
{
    /// <summary>
    /// BaseControlAdapter class used to expose shared methods across adapters
    /// </summary>
    public abstract class BaseControlAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter
    {
        protected void RenderContainer(Control control, HtmlTextWriter writer)
        {
            foreach (Control c in control.Controls) { c.RenderControl(writer); }
        }

    }
}
