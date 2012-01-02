using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using ClimbFind.Helpers;
using ClimbFind.Model.Objects;

namespace ClimbFind.Controls
{
    public static class MapBuilder
    {
        //-- Dashboard Types : VEDashboardSize.Tiny
        //-- Map Styles : VEMapStyle.Road

        public static readonly double WorldMapStartLat = 28.01309, WorldMapStartLong = 13.00267;
        public static readonly short WorldZoomLevel = 2;
        public static readonly string IndoorIcon = "inpin.bmp";
        public static readonly string OutdoorIcon = "outpin.bmp";
        private static readonly string ScriptReference = @"<script type=""text/javascript"" src=""http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2""></script>";
      
        /// <summary>
        /// 
        /// </summary>
        public static string GeneratePlaceMap(string mapDivID, double statLat, double startLong,
            short zoomLevel, Place place, string mapStyle, string dashType,
            int width, int height, string title)
        {
            List<Place> places = new List<Place>();
            places.Add(place);

            return GeneratePlaceMap(mapDivID, statLat, startLong, zoomLevel, places,  
                mapStyle, dashType, width, height, title);
        }

 
        public static string GenerateWorldPlaceMap(string mapDivID, List<Place> places,
            string mapStyle, string dashType, string title)
        {
            return GeneratePlaceMap(mapDivID, WorldMapStartLat, WorldMapStartLong, WorldZoomLevel, places, 
                mapStyle, dashType, 880, 540, title);
        }


        /// <summary>
        /// 
        /// </summary>
        public static string GeneratePlaceMap(string mapDivID, double statLat, double startLong,
            short zoomLevel, List<Place> places, string mapStyle, string dashType, int width, int height, string title)
        {
            StringBuilder sb = new StringBuilder(ScriptReference + @"<script type=""text/javascript""> var map = null; function GetMap() { ");          

            sb.Append("var ss = new Array();");
            sb.AppendFormat("map = new VEMap('{0}');", mapDivID);
            sb.AppendFormat("map.SetDashboardSize({0});", dashType);
            sb.AppendFormat("map.LoadMap(new VELatLong({0}, {1}), {2}, 'h', false);", statLat, startLong, zoomLevel);
            sb.AppendFormat("map.SetMapStyle({0});", mapStyle);

            if (places.Count > 0)
            {
                foreach (Place p in places) { AddShape(sb, p); }
                sb.AppendFormat(@"map.AddShape(ss);");
            }

            sb.Append("} </script>");
            sb.Append(@"<body onload=""GetMap();"">");
            sb.AppendFormat(@"<div id=""{0}"" style=""position:relative;width:{1}px;height:{2}px;"" title=""{3}""></div>", 
                mapDivID, width, height, title);
            sb.Append(@"</body>");

            return sb.ToString();
        }

        
        private static void AddShape(StringBuilder sb, Place place)
        {
            string pinImg = IndoorIcon;
            if (!place.IsIndoor) { pinImg = OutdoorIcon; }
            
            int shapeNumber = 0;
            string shapeName = "s" + (shapeNumber++).ToString();
            sb.AppendFormat("var {0} = new VEShape(VEShapeType.Pushpin, new VELatLong({1}, {2}));", shapeName, place.Latitude.GetNoTrailingZerosString(), place.Longitude.GetNoTrailingZerosString());
            sb.AppendFormat(@"{0}.SetCustomIcon('<img src=""/images/UI/{1}"">');", shapeName, pinImg);
            sb.AppendFormat(@"{0}.SetTitle('<a href=""{1}"">{2}", shapeName, place.ClimbfindUrl, place.Name.RemoveSpecialCharsExcludingSpaces());
            if (place.HasPrimaryImage) { sb.AppendFormat(@"<img src=""{0}"">", place.PrimaryImageUrl); }
            sb.Append(@"</a>');");

            sb.AppendFormat(@"ss.push({0});", shapeName);
        }

    }
}
