using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Places
{
    public partial class MediaList : System.Web.Mvc.ViewUserControl<List<MediaShare>>
    {
        public List<MediaShare> Media { get { return ViewData.Model; } }

        public List<MediaShare> MediaByDateSubmitted { get { return (from c in Media orderby c.SubmittedDateTime descending select c).ToList(); } }
    }
}
