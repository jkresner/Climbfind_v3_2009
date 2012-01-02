<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapCoordinatePicker.ascx.cs" Inherits="IdentityStuff.Controls.MapCoordinatePicker" %>

<script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>
<script type="text/javascript">
	
	var map = null;
	var clickPoint = null;
	
	function MouseHandler(e)
	{
		var msg;
		if (e.rightMouseButton){
		    setClickPoint(e);
		    notificate();
		} else {
		}		
	}
	
	function GetMap()
	{
		map = new VEMap('myMap');
		map.SetDashboardSize(VEDashboardSize.Small);
		map.LoadMap(new VELatLong(<%= MapStartCenterLatitude %>, <%= MapStartCenterLongitude %>), 2, 'h', false);
		map.AttachEvent("onclick",MouseHandler);
		map.SetMapStyle(VEMapStyle.Hybrid);
		
		setDefaultCoordinate();
	}   

	function setClickPoint(e)
	{
		clickPoint = null;
		clickPoint = map.PixelToLatLong(new VEPixel(e.mapX, e.mapY));
		return true;
	}
	
	function notificate()
	{
        map.DeleteAllShapes();
	
	    var LatHD = document.getElementById('<%= LatitudeHD.ClientID %>');
	    var LonHD = document.getElementById('<%= LongitudeHD.ClientID %>');
		var latlong = clickPoint.toString().split(',');
		LatHD.value = latlong[0];
		LonHD.value = latlong[1];

		var shape = new VEShape(VEShapeType.Pushpin, new VELatLong(LatHD.value, LonHD.value));
		shape.SetTitle('New location');
		shape.SetCustomIcon('<img src="/images/UI/inpin.bmp">');
		map.AddShape(shape);		
	
	    <%= ClientFunction %>
	}
	
	function setDefaultCoordinate()
	{
	    <%= DefaultCoordinateLogic %>    	
	}
	
	
</script>

<table style="margin:0">
    <tr>
        <td style="width:200px">
            <div style="margin-bottom:20px"><b>Map instructions </b></div>
            <div style="font-size:10px">
            <div>1) Double click to zoom in</div>
            <div>2) Right-click to plot point</div>
            <div>3) Zoom in as much as possible to confirm correct location</div>
            <div>4) User 'Road' view button if necessary</div>
            </div>
        </td>
        <td style="padding:0">
            <body onload="GetMap();">
                <div id='myMap' style="position:relative; width:400px; height:350px;"></div>
            </body>
            <input id="LatitudeHD" type="hidden" runat="server" />
            <input id="LongitudeHD" type="hidden" runat="server" />        
        </td>
    </tr>
</table>



