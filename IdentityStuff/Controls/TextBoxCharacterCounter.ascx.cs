using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityStuff.Controls
{
    public partial class TextBoxCharacterCounter : System.Web.Mvc.ViewUserControl
    {
        public string TargetID { get; set; }
        public string TargetClientID { get { return this.Parent.FindControl(TargetID).ClientID; } }

        public int CharacterLimit { get { return _characterLimit; } set { _characterLimit = value; } }
        private int _characterLimit = 255;  
    }
}
