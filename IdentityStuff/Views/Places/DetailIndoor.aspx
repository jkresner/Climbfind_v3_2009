<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="DetailIndoor.aspx.cs" Inherits="IdentityStuff.Views.Places.DetailIndoor" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
 
<div style="float:left;width:49%">

    <div class="vPageSectionTop">
        <h1><%= place.Name %></h1>
     
        <% if (!UserClimbsHere) { %>
            <p class="attentionDIV" style="margin:0px 10px 10px 10px">=> <b><%= Html.ActionLink<ClimberProfilesController>(c=>c.AddPlaceToPlacesUserClimbs(place.ID), string.Format("Add to 'Places I've climbed'", place.ShortName)) %></b></p>
        <% } %>
     
        <img src="<%= place.LogoImageUrl %>" alt="<%= place.Name %>" class="float-left" />        
        <p style="margin-left:0px"><%= place.Description.GetHtmlParagraph() %></p>    
    </div>
    
    <div class="vPageSection">
        <h1>Info <span style="font-size:14px">
            &nbsp <%= Html.ActionLink<ModerateController>(c => c.EditIndoorPlace(place.ID), "Edit details")%>
            &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditPlaceMap(place.ID), "Edit map")%>
                <% if (UserIsModerator) { %>&nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditIndoorPlaceLogo(place.ID), "Change logo")%><% } %></span></h1>
     
        <div style="width:266px;float:left">
            <b>Climbing available:</b><hr />
            
            <% if (place.HasTopRope) { %><div class="climbingTypeDIV"><div>Top rope</div>
            <img src="/images/UI/cf/TopRope.bmp" alt="Top rope" /></div><% } %>
            <% if (place.HasLead) { %><div class="climbingTypeDIV"><div>Lead</div>
            <img src="/images/UI/cf/Lead.bmp" alt="Lead" /></div><% } %>
            <% if (place.HasBoulder) { %><div class="climbingTypeDIV"><div>Boulder</div>
            <img src="/images/UI/cf/Boulder.bmp" alt="Boulder" /></div><% } %>
            
            <hr />
            
            <b>Website:</b> <%= string.Format(@"<a rel=""nofollow"" href=""http://{0}"" target=""_blank"">{1}</a>", place.Website, GetWebsite(place.Website))%>
            <br /><b>Short name: </b> <%= place.ShortName %> 
            <br /><b>Contact: </b> <%= place.Contact %> 
            <br /><b>Address:</b> <%= place.Address %>
         
            <div style="margin-top:10px"><%= MapBuilder.GeneratePlaceMap("map-around-"+place.FriendlyUrlName, (double)place.Latitude, (double)place.Longitude, 14,
                mapPlace, "VEMapStyle.Road", "VEDashboardSize.Tiny", 260, 380, "Map and directions to " + place.Name) %>
            </div>
        </div>
        
        <div style="float:left;width:161px">
            <%= CFAdControls.IndoorPlaceDetailsRight160(this, mapPlace) %>
        </div>

    </div>
    
    <div class="vPageSection">
        <%= Html.RenderUserControl("~/Views/Places/DetailPlaceRegularsSampleCache.ascx", place, new { NumberOfRegularsToShow = 15, LogoImageFileUrl=place.LogoHalfSizeImageUrl })%>
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
