using System.Web.Mvc;

namespace IdentityStuff.Views.Shared
{
    public partial class FullSizeImage : ViewPage<string>
    {
        public string ImageSrc { get { return ViewData.Model; } }
    }
}
