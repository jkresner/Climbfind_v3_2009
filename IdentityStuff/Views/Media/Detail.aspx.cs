using System;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Media
{
    public partial class Detail : ClimbFindViewPage<MediaShare>
    {
        public MediaShare Media { get { return ViewData.Model;} }


        protected void Page_Init(Object s, EventArgs e)
        {
            MessageBoardUC.RenderMessageBoard(cfController.GetMessageBoard(Media.MessageBoardID));
        }
    }
}
