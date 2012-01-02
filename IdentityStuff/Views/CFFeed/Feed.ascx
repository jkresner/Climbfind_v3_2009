<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feed.ascx.cs" Inherits="IdentityStuff.Views.CFFeed.Feed" %>
<script type="text/javascript">
    $(document).ready(function() { IntialiseFeed('<%= ((int)Settings.CurrentChannelType) %>'); });
</script>

<dl id="FeedFilters">
    <dd><b>Channel</b></dd> 
    <dt>[<a id="MLk">Movies</a>|<a id="PoLk" class="CurrentFilter">Posts</a>]</dt>
    <%--<dt>[<a id="CLnk" title="Show posts by Climbers I'm watching">Climbers</a>]</dt>--%>
    <dt>[<a id="PlaceLink" title="Filter feed for a specific place like your climbing gym"><i>Place</i></a>|<a id="PLnk" href="javascript:ChangeChannel('2')"><%= CurrentPlaceName.Take(12).Trim()%></a>]</dt>
    <dt>[<a id="AreaLink" title="Filter feed for a specifc area like 'United States' or 'California'"><i>Area</i></a>|<a id="ArLnk" href="javascript:ChangeChannel('1')"><%= CurrentAreaName.Take(12).Trim() %></a>]</dt>
    <dt>[<a id="AllLnk" title="Show all posts on Climbfind">All</a>]</dt>
    <hr />
    <div id="SelectArea" style="display:none">
        <input id="AreaTxB" type="text" class="FilterTxBWaterMark" value="Type city/state/country" />        
        &nbsp <a href="javascript:HideAllFeedFilters()">Close</a></div> 
    <div id="SelectPlace" style="display:none">
        <input id="Place2TxB" type="text" class="FilterTxBWaterMark" value="Type name of place" />
        &nbsp <a href="javascript:HideAllFeedFilters()">Close</a></div> 
    <dd id="MAct" style="float:right;width:160px;display:none;font-size:12px">> <%= Html.ActionLink<MediaController>(c => c.SubmitMovie(), "Submit your own movie")%></dd>
    <%--<dd id="CLAct" style="float:right;width:200px;display:none">> <%= Html.ActionLink<CFFeedController>(c => c.ClimbersImWatching(), "Manage climbers I'm watching")%></dd>--%>
    <dd id="TAct" style="float:right;text-align:right;width:260px;display:none">> Current tag <span id="tag"></span> <a href="javascript:ClearTag()">clear</a></dd>  
</dl>
<input id="VID" type="hidden" name="VID" tabindex="10000" value="<%= ((byte)FeedView.Posted).ToString() %>" /> 
<input id="CID" type="hidden" name="CID" tabindex="10001" value="<%= ((byte)Settings.CurrentChannelType).ToString() %>" /> 
<input id="AID" type="hidden" name="AID" tabindex="10002" value="<%= Settings.AreaID.ToString() %>" /> 
<input id="PID" type="hidden" name="PID" tabindex="10003" value="<%= Settings.PlaceID.ToString()%>" />
<input id="TID" type="hidden" name="TID" tabindex="10005" />

<div id="FeedLoading" style="display:none"><img src="/images/load.gif" /><b>Refreshing feed...</b></div>
<div id="FeedResults"></div>