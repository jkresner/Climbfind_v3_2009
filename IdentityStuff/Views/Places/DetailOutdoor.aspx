<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="DetailOutdoor.aspx.cs" Inherits="IdentityStuff.Views.Places.DetailOutdoor" %>



<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="float:left;width:49%">
 
<div class="vPageSectionTop">
    <h1><%= place.Name %></h1>

    <div style="float:left;width:245px">
        <%= GetPhotoHtml(place.DescriptionImageUrl, descriptionImageFile1ByUser, "Outdoor rock climbing {0}")%>   
    </div>

    <p style="text-align:justify">
        <% if (!String.IsNullOrEmpty(place.Description)) 
        { %>
            <%-- Twenga Hack (allows links of certain pages) --%>
            <% if (place.ID == 1006 || place.ID == 539)
               { %><%= HttpUtility.HtmlDecode(place.Description.GetHtmlParagraph()) %>
            <% }
               else
               { %><%= place.Description.GetHtmlParagraph()%><% } %>
        <% } 
            else 
        { %>       
           No info. Please <%= Html.ActionLink<ModerateController>(c => c.EditOutdoorLocation(place.ID), "edit this entry")%>.<% } %></p> 
</div> 


<div class="vPageSection">       
 
    <h1>Info
        <% if (UserLoggedIn) { %>   
            <span style="font-size:14px">&nbsp<%= Html.ActionLink<MediaController>(c => c.EditOutdoorLocationPictures(place.ID), "Change pics")%>
             &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditOutdoorLocation(place.ID), "Edit details")%>
             &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditPlaceMap(place.ID), "Edit map")%>
             &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.AddOutdoorCrag(place.ID), "Add crag") %>
<%--            <% if (UserIsModerator)
               { %>
                &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditOutdoorAuthoritySites(place.ID), "Edit authority sites")%>
            <% } %>
--%>            </span>        
        <% } %>

    </h1>

    <div style="float:left;width:256px;padding:0px 10px 0px 0px">
    
        <b>Crags: </b>
             <% if (Crags.Count == 0)
               { %>No information is available on crags around <%= place.Name %>. Please 
                <%= Html.ActionLink<ModerateController>(c => c.AddOutdoorCrag(place.ID), "Add a crag")%> if you know about it.
               <% } else { %> &nbsp <%= Html.RenderUserControl("~/Views/Places/CragsList.ascx", Crags, new { place = place })%><% }%>
                       
           <div style="margin:10px 2px 0px 0px">

                <%= GetPhotoHtml(place.DescriptionImageUrl2, descriptionImageFile2ByUser, "{0} mountain climbing") %>   
                
                <%= GetPhotoHtml(place.DescriptionImageUrl3, descriptionImageFile3ByUser, "{0} rock climbing at mountaineering")%>    
                
                <% if (!String.IsNullOrEmpty(place.Food)) { %><p><%= place.Food.GetHtmlParagraph()%></p><% } %> 
                
                <% if (!String.IsNullOrEmpty(place.Accomodation)) { %><p><%= place.Accomodation.GetHtmlParagraph()%></p><% } %> 
                
                <% if (!String.IsNullOrEmpty(place.LocalBeta)) { %><p><%= place.LocalBeta.GetHtmlParagraph()%></p><% } %> 
                
               <h6 style="margin-top:10px"><b>Directions</b></h6>
               <p title="Directions-for-climbing-around-<%= place.FriendlyUrlName %>" style="margin:4px 30px 0px 2px">
                 <% if (!String.IsNullOrEmpty(place.Directions)) { %><%= place.Directions.GetHtmlParagraph()%><% } else { %>
                    No one has supplied directions to <%= place.ShortName %> climbing. If you have the info, <%= Html.ActionLink<ModerateController>(c => c.EditOutdoorLocation(place.ID), "edit the details")%>.
                <% } %></p> 
                                    
            </div>           
    </div>
  
  
    <div style="float:left;width:161px">
        <%= CFAdControls.IndoorPlaceDetailsRight160(this, mapPlace) %>
    </div>

    <div style="padding-top:10px;clear:both"><%= MapBuilder.GeneratePlaceMap("map-around-"+place.FriendlyUrlName, (double)place.Latitude, (double)place.Longitude, 14,
        mapPlace, "VEMapStyle.Road", "VEDashboardSize.Tiny", 420, 380, "Map and directions to " + place.Name) %>
    </div>

    <div class="vPageSection">
        <%= Html.RenderUserControl("~/Views/Places/DetailPlaceRegularsSampleCache.ascx", place, new { NumberOfRegularsToShow = 9 })%>
    </div>
    
           
<%--       <body onload="GetMap();">
          <div id='<%= MapDivID %>' style="position:relative; width:340px; height:280px;margin:10px 5px 20px 50px" title="<%= MapTitle %>"></div>
       </body>     
        
        <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>
        <script type="text/javascript"> var map = null; function GetMap() { <%= GetVirtualEarthMapLoadCode() %> }  </script>     
--%>         
       <% if (AuthoritySites.Count > 0)
          { %><h2>Authority sites on <%= place.Name %></h2>     
       
           <% foreach (OutdoorPlaceAuthority site in AuthoritySites) { %>
            <p>=> <a href="http://<%= site.Url %>" target="_blank"><%= site.Name %></a></p>  
        <% } } %>          
      
       <%--  <p>Climbfind does not know of websites with information on climbing <%= place.Name%>. If you run a site
            about rock climbing in <%= place.Name%> and want it listed here, email us at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">contact@climbfind.com</a></p>             
       <% } else {--%>

</div>





</div>




<div style="float:right;width:50%">
    
    <div class="AdDivTopRight">
        Sponsored Ad - <a href="/Ads">Advertise</a>
                    
        <% if (place.CountryID == (int)Nation.England) { %><%= CFAdControls.Ad("Place.TopRight", 35)%><% } else { %>
        <%= CFAdControls.Ad("Place.TopRight", 29)%><% } %>
            
    </div>

    <h1>Climbing activity</h1>

    <p class="attentionDIV" style="margin:0px 10px 10px 10px">=> <b><%= Html.ActionLink<PartnerCallsController>(c => c.Subscribe(place.FriendlyUrlLocation, place.FriendlyUrlName), "Subscribe to activity @ " + place.ShortName) %></b></p>
    
    <% if (FeedPosts.Count > 0) { %>
        <%= Html.RenderUserControl("~/Views/CFFeed/FeedItemList.ascx", FeedPosts) %>
    <% } else { %>
        <p>:( No one has posted anything for <%= place.Name %></p>
        <p><b>Start the conversation!</b></p>
        <p>=> <%= Html.ActionLink<CFFeedController>(c=>c.NewPost(place.ID), "Post when you're climbing here") %></p>
        <p>=> <%= Html.ActionLink<MediaController>(c=>c.AddPlaceYouTube(place.ID), "Submit a movie of " + place.Name) %></p>
    <% } %>

</div>

<hr />
<%= CFControls.OtherAreasInCountryCloud(this, (Nation)place.CountryID)%>  



   






</asp:Content>
