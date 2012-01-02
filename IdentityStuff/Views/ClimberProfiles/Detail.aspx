<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.Detail" %>
<%@ Register TagName="ProfileAds" TagPrefix="ad" Src="~/Controls/AdUnits/ProfileAds.ascx" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">  

      
<div id="ProfileDetails">

    <%= Html.ProfileImagePreview(Current.ProfilePictureUrl, Current.ProfilePictureUrlFull, Html.Encode(Current.FullName)) %>

    <div><b>Full name:</b> <%= Html.Encode(Current.FullName)%></div>
    <div><b>Nick name:</b> <%=  Html.Encode(Current.NickName)%></div>
    <div><b>Nationality: </b>
            <img src="<%= Current.FlagImageUrl_Absolute %>" class="flag" style="padding:2px 2px 0px 2px" />
            <%= Current.NationalityString%></div>
    <div><b>Sex: </b><%= Current.Sex%></div>
    <div><b>Contact: </b><%= Html.Encode(Current.ContactNumber)%></div>
    <div><b>Climbing ability: </b><%= Html.Encode(Current.ClimbingLevel)%></div>
    <div><b>Partner status: </b><%= ClimbFind.Model.DataAccess.CFDataCache.GetPartnerStatusName(Current.PartnerStatusID)%></div>
 
    <div class="vPageSection" style="margin:5px 0px 10px 0px"> 
        <%= Html.RenderUserControl("~/Views/ClimberProfiles/PlacesIClimb.ascx", Current)%> 
    </div> 
  
</div>


<div style="float:left;width:460px">
    <h1>Activity</h1>
    
    <div style="overflow:hidden">
    
    <ul id="FeedItems" style="margin-top:-15px">
    <% foreach (ClimbFind.Model.Objects.Interfaces.IFeedItem item in UsersActivity)
       { %>
    <li>        
        <img src="<%= item.UserProfileImgUrl %>" />        
        <div>
            <b style="float:left"><%= Current.FullName%></b>
            <span><%= item.PostedDateTime.GetAgoString()%></span>
            <%= item.RenderHTMLPostTopDetails() %>        
            <br />
            <%= item.RenderHTMLOptions() %>
        </div>
      
        <%= item.RenderHTMLPostBody() %>
        <% if (item.Comments.Count > 0) { %><dl><% foreach (FeedPostComment c in item.Comments) { %>
            <dt><%= Html.ImagePreview(c.UserProfileImgUrl, c.User.ProfilePictureUrl, c.User.FullName)%></dt>
            <dd><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %>
            <% if (c.UserID == UserID) { %><a href="/CFFeed/DeletePostComment/<%= c.ID %>">delete</a><% } } %></dd>
        </dl><% } %>   
        <hr />
    </li><% } %>   
    </ul>
     
    </div>

    <% if (!Current.IsUnfinished)
               { %>       
  
          <% if (!extendedProfile.IsEmpty || clubs.Count > 0)
           { %>  
            <div id="ExtendedProfile"> 
            
                    <h1>Extended profile</h1>
                
                    <%= Html.RenderUserControl("~/Views/ClimberProfiles/ClubsIBelongTo.ascx", clubs )%>
                     
                    <div style="clear:both">
                        <%= Html.RenderUserControl("~/Views/ClimberProfiles/ExtendedProfile.ascx", extendedProfile)%>
                    </div>
             </div>     
           <% } %>           
    
    <% } %>
     
</div>


<div id="sidebar">
   
    <h1>Options</h1>
    <ul id="Options">
        
        <li><b><%= Html.ActionLink<ClimberProfilesController>(c => c.WriteMessage(Current.ID), "Send message")%></b></li>        
        <li><%= Html.ActionLink<MediaController>(c => c.UsersMedia(Current.ID), "View user's movies")%> </li> 
    </ul>

    <div style="margin:20px 0px 0px 0px"><ad:ProfileAds id="PAds" runat="Server" /></div>
</div>

</asp:Content>
