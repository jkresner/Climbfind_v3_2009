using System;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.ClimberProfiles
{
    public partial class ExtendedProfile : System.Web.Mvc.ViewUserControl<ClimberProfileExtended>
    {
        public ClimberProfileExtended extendedProfile { get { return ViewData.Model; } }
        public string ProfileDisplayMode { get; set; }

        protected string displayExtendedProfilePart(string fieldText, string fieldValue)
        {            
            if (String.IsNullOrEmpty(fieldValue) && ProfileDisplayMode == "Me") 
            { 
                return string.Format("<p><b>{0}</b><br /><i>Not specified</i></p>", fieldText); 
            }
            else if (String.IsNullOrEmpty(fieldValue)) { return ""; }
            else { return string.Format("<p><b>{0}</b><br />{1}</p>", fieldText, fieldValue.GetHtmlParagraph()); }
        }    
    }
}

