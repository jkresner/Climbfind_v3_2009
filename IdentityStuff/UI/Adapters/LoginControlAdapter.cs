using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbFind.Web.UI.Adapters
{
    /// <summary>
    /// LoginControlAdapter makes the output html only that which is inside the <LayoutTemplate>
    /// instead off all the crap the inbuilt render method spits out.    /// </summary> 
    public class LoginControlAdapter : BaseControlAdapter
    {
        /// <summary>
        /// Easy reference to our login control
        /// </summary>  
        protected Login login { get { return Control as Login; } }

        /// <summary>
        /// We ovveride RenderContents so we output what we want (only what is inside the <LayoutTemplate>)
        /// </summary>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            //-- If <LayoutTemplate> has not been specified we just use default render            
            if (login.LayoutTemplate == null) { base.RenderEndTag(writer); }
            {
                RenderContainer(login.Controls[0], writer);
            }
        }
    }
}
