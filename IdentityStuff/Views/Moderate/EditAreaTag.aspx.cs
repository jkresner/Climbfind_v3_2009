using System;
using System.Text;
using ClimbFind.Model.Objects;
using ClimbFind.Web.Mvc.Controllers;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Moderate
{
    public partial class EditAreaTag : ClimbFindViewPage<AreaTag>
    {
        public AreaTag Tag { get { return ViewData.Model; } }

        public string MapDivID { get { return string.Format("Map-Of-Climbing-Gyms-In-{0}", Tag.ParagraphName.Replace(" ", "-")); } }
        public string MapTitle { get { return string.Format("Map showing indoor rock climbing gyms in {0}", Tag.ParagraphName); } }         

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NameLb.Text = Tag.Name;
                MapZoomTxB.IntegerValue = (int)Tag.DefaultVirtualEarthZoom;
                LatitudeTxB.DoubleValue = (double)Tag.Latitude;
                LongitudeTxB.DoubleValue = (double)Tag.Longitude;
                ParagraphNameTxB.Text = Tag.ParagraphName;
            }
        }

        protected string GetVirtualEarthMapLoadCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("map = new VEMap('{0}');", MapDivID);
            sb.Append("map.SetDashboardSize(VEDashboardSize.Tiny);");
            sb.AppendFormat("map.LoadMap(new VELatLong({0}, {1}), {2}, 'h', false);", Tag.Latitude, Tag.Longitude, Tag.DefaultVirtualEarthZoom);
            sb.Append("map.SetMapStyle(VEMapStyle.Road);");

            return sb.ToString();
        }

        protected void UpdateAreaTag_Click(Object sender, EventArgs e)
        {
            if (PeterBlum.VAM.Globals.Page.IsValid)
            {
                //-- Validate country is not unknown or UK

                Tag.Latitude = (decimal)LatitudeTxB.DoubleValue;
                Tag.Longitude = (decimal)LongitudeTxB.DoubleValue;
                Tag.DefaultVirtualEarthZoom = (short)MapZoomTxB.IntegerValue;
                Tag.ParagraphName = ParagraphNameTxB.Text;

                cfController.UpdateAreaTag(Tag);

                RedirectTo<ModerateController>(c => c.EditAreaTag(Tag.ID));
            }
        }

    }
}
