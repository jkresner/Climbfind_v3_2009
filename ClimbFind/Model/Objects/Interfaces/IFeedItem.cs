using System;
using System.Collections.Generic;

namespace ClimbFind.Model.Objects.Interfaces
{
    public interface IFeedItem
    {
        DateTime PostedDateTime { get; set; }
        List<FeedPostComment> Comments { get; }
        ClimberProfile User { get; }
        string UserProfileImgUrl { get; }
        string CommentUrl { get; }
        string DeleteUrl { get; }

        string RenderHTMLOptions();
        string RenderHTMLPostTopDetails();
        string RenderHTMLPostBody();
	}
}
