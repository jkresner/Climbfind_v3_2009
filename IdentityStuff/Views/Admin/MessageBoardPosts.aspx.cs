using System;
using System.Web.Mvc;
using ClimbFind.Controller;

namespace IdentityStuff.Views.Admin
{
    public partial class MessageBoardPosts : ViewPage
    {
        protected void Page_Load(Object s, EventArgs e)
        {
            MessagesLV.DataSource = new CFController().GetLast100MessageBoardMessages();
            MessagesLV.DataBind();
        }
    }
}
