using System;
using System.Web.UI.WebControls;

namespace ClimbFind.Web.UI.Adapters
{
    /// <summary>
    /// PasswordRecoveryControlAdapter makes the output html only that which is inside the <UserNameTemplate>
    /// instead off all the crap the inbuilt render method spits out.
    /// </summary>    
    public class PasswordRecoveryControlAdapter : BaseControlAdapter
    {
        /// <summary>
        /// An enum and private member variable to help us know which template we need to load in RenderContents
        /// </summary>
        private enum State { UserName, VerifyingUser, Success }
        private State _state = State.UserName;


        /// <summary>
        /// Easy reference to our password control
        /// </summary>
        protected PasswordRecovery passwordRecovery { get { return Control as PasswordRecovery; } }


        /// <summary>
        /// We override OnInit just so we can set the state
        /// </summary>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //-- set the state (using an anonymous method)
            passwordRecovery.VerifyingUser += delegate { _state = State.VerifyingUser; };
        }


        /// <summary>
        /// We ovveride RenderContents so we output what we want (only what is inside the <UserNameTemplate>)
        /// </summary>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            //-- If <UserNameTemplate> has not been specified we just use default render    
            if (passwordRecovery.UserNameTemplate == null) { base.Render(writer); }
            else
            {
                if (_state == State.UserName)
                {
                    RenderContainer(passwordRecovery.UserNameTemplateContainer, writer);
                }
                if (_state == State.Success)
                {
                    RenderContainer(passwordRecovery.SuccessTemplateContainer, writer);
                }
            }
        }


        /// <summary>
        /// really not sure how this works, it was taken from the CSS friendly adapters, but makes sure we enter 'Success' state.
        /// </summary>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // Success! We did not encounter an error while verifying the answer to the security question.
            if (_state == State.VerifyingUser) { _state = State.Success; }
        }
    }
}
