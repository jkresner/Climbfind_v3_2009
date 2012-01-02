using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbFind.Web.UI.Adapters
{
    public class CreateUserWizardControlAdapter : BaseControlAdapter
    {
        /// <summary>
        /// Easy reference to our CreateUserWizard control
        /// </summary>  
        protected CreateUserWizard wizard { get { return Control as CreateUserWizard; } }

        /// <summary>
        /// override RenderBeginTag to stop default <table> junk
        /// </summary>
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);
        }

        /// <summary>
        /// override RenderBeginTag to stop default </table> junk
        /// </summary>
        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            // base.RenderEndTag(writer);
        }

        /// <summary>
        /// We ovveride RenderContents so we output what we want (only what is inside the <ContentTemplate>)
        /// </summary>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            TemplatedWizardStep activeStep = wizard.ActiveStep as TemplatedWizardStep;

            if (activeStep.ContentTemplate != null)
            {
                //-- Render what is inside the active step <ContentTemplate>
                RenderContainer(activeStep.ContentTemplateContainer.Controls[0], writer);

                if (activeStep.CustomNavigationTemplate != null)
                {
                    //-- Render what is inside the active step <CustomNavigationTemplate>
                    RenderContainer(activeStep.CustomNavigationTemplateContainer, writer);
                }
            }
            else
            {
                base.RenderContents(writer);
            }
        }
    }
}


