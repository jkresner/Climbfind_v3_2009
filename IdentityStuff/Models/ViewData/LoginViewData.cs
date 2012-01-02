
namespace ClimbFind.Web.Mvc.Models.ViewData
{
    public class LoginViewData
    {
        public string LoginReason { get; set; }
        public string ReturnUrl { get; set; }

        public LoginViewData()
        {
            LoginReason = "";
            ReturnUrl = "";
        }
    }
}
