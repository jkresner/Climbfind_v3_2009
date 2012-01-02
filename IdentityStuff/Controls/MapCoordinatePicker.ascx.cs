using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdentityStuff.Controls
{
    public partial class MapCoordinatePicker : System.Web.UI.UserControl
    {
        protected string DefaultCoordinateLogic;
        public decimal MapStartCenterLatitude { get; set; }
        public decimal MapStartCenterLongitude { get; set; }
        public decimal MapStartZoomLevel { get; set; }
        public string ClientFunction { get; set; }

        private decimal _latitude=0, _longitude=0;

        public decimal Latitude 
        { 
            get 
            { 
                if (decimal.TryParse(LatitudeHD.Value.ToString(), out _latitude))
                {
                    return _latitude;
                }
                else { return 0; }
            }
        }

        public decimal Longitude 
        { 
            get 
            { 
                if (decimal.TryParse(LongitudeHD.Value.ToString(), out _longitude))
                {
                    return _longitude;
                }
                else { return 0; }
            } 
        }

        public bool HasCoordinates { get { return !(Latitude == 0 && Longitude == 0); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (MapStartCenterLatitude == default(decimal))
            {
                MapStartCenterLatitude = 24;
                MapStartCenterLongitude = -40;
            }
        }

        

        public void SetMapStartPosition(decimal latitude, decimal longitude, int zoomLevel)
        {
            MapStartCenterLatitude = latitude;
            MapStartCenterLongitude = longitude;
            MapStartZoomLevel = zoomLevel - 1;

            DefaultCoordinateLogic = string.Format(@"map.SetCenterAndZoom(new VELatLong({0}, {1}), {2});", 
                latitude, longitude, MapStartZoomLevel);
        }

        public void SetPoint(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude;

            if (MapStartZoomLevel == default(int)) { MapStartZoomLevel = 10; }

            DefaultCoordinateLogic = string.Format(@"var shape = new VEShape(VEShapeType.Pushpin, new VELatLong({0}, {1}));
		shape.SetTitle('New location'); shape.SetCustomIcon('<img src=""/images/UI/inpin.bmp"">');
		map.AddShape(shape);map.SetCenterAndZoom(new VELatLong({0}, {1}), {2});", latitude, longitude, MapStartZoomLevel);
        }

    }
}