using System;
using System.Collections.Generic;

namespace ClimbFind.Model.Objects.Interfaces
{
    public interface IPartnerPageItem : IFeedItem 
    {
		string RenderHTMLOptionsForPartnerPage();
		string RenderHTMLPostTopDetailsForPartnerPage();
		string RenderHTMLPostBodyForPartnerPage();
	}
}
