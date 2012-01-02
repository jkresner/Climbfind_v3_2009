using System;
using System.Web.Mvc;

namespace IdentityStuff.Views.Admin
{
    public partial class GuidGenerator : ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0;i<10;i++)
            {
                GuidsLB.Text += "<br />" + Guid.NewGuid().ToString();
            }
        }
    }
}
