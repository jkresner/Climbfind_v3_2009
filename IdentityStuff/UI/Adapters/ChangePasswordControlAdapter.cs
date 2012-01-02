using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClimbFind.Web.UI.Adapters
{
    /// <summary>
    /// ChangePasswordControlAdapter makes the output html only that which is inside the <ChangePasswordTemplate>
    /// instead off all the crap the inbuilt render method spits out. 
    /// </summary>
    public class ChangePasswordControlAdapter : BaseControlAdapter
    {       
        /// <summary>
        /// An enum and private member variable to help us know which template we need to load in RenderContents
        /// </summary>
        private enum State { ChangePassword, Success }
        private State _state = State.ChangePassword;

        /// <summary>
        /// Easy reference to our password control
        /// </summary>
        protected ChangePassword changePassword { get { return Control as ChangePassword; } }
      
  
        /// <summary>
        /// We override OnInit just so we can set the state
        /// </summary>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //-- set the state (using an anonymous method)
            changePassword.ChangedPassword += delegate { _state = State.Success; };

            //-- These two lines arn't necessary they just make the html output pretty than using the default IDs
            changePassword.ID = "chgPwd";
            changePassword.ChangePasswordTemplateContainer.ID = "c";
        } 


        /// <summary>
        /// We ovveride RenderContents so we output what we want (only what is inside the <ChangePasswordTemplate>)
        /// </summary>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            //-- If <ChangePasswordTemplate> has not been specified we just use default render
            if (changePassword.ChangePasswordTemplate == null) { base.RenderContents(writer); }           
            else
            {
                if (_state == State.ChangePassword)
                {
                    RenderContainer(changePassword.ChangePasswordTemplateContainer, writer);
                }

                if (_state == State.Success)
                {
                    RenderContainer(changePassword.SuccessTemplateContainer, writer);
                }               
            }
        }


        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            
        }

    }
}
