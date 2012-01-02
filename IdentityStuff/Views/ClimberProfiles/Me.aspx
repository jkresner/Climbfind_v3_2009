<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Me.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.Me" %>
<%@ Register TagName="ProfileAds" TagPrefix="ad" Src="~/Controls/AdUnits/ProfileAds.ascx" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
      
<div id="ProfileDetails">
    <%= Html.ProfileImagePreview(climberProfile.ProfilePictureUrl, climberProfile.ProfilePictureUrlFull, Html.Encode(climberProfile.FullName)) %>
    
    <div><b>Full name:</b> <%= Html.Encode(climberProfile.FullName) %></div>
    <div><b>Nick name:</b> <%=  Html.Encode(climberProfile.NickName) %></div>
    <div><b>Nationality: </b>
            <img src="<%= climberProfile.FlagImageUrl_Absolute %>" class="flag" style="padding:2px 2px 0px 2px" />
            <%= climberProfile.NationalityString %></div>
    <div><b>Sex: </b><%= climberProfile.Sex %></div>
    <div><b>Contact: </b><%= Html.Encode(climberProfile.ContactNumber) %></div>
    <div><b>Climbing ability: </b><%= Html.Encode(climberProfile.ClimbingLevel) %></div>
    <div><b>Partner status: </b><%= ClimbFind.Model.DataAccess.CFDataCache.GetPartnerStatusName(climberProfile.PartnerStatusID) %></div>
 
    <div class="vPageSection" style="margin:5px 0px 10px 0px"> 
        <%= Html.RenderUserControl("~/Views/ClimberProfiles/PlacesIClimb.ascx", climberProfile) %> 
    </div>   
</div>


<div style="float:left;width:460px">
    <h1>Activity</h1>
 
    <% if (climberProfile.ImageNotUploaded)
       { %>
    <div class="attentionDIV" style="padding:6px 4px 2px 8px">
       <b> Next step => <%= Html.ActionLink<ClimberProfilesController>(c => c.EditPicture(), "Upload a photo for your profile")%></b>
    <p style="margin-bottom:10px"><span style="color:red"><b>Note</b></span>: You must upload a photo before you can view other peoples profiles, post partner calls and leave feedback.</p></div><%}
       else
       { %>
        <div class="attentionDIV">Be active => 
            <%= Html.ActionLink<MediaController>(c=>c.SubmitMovie(), "Submit a movie") %>
             or <%= Html.ActionLink<CFFeedController>(c=>c.NewPostPlace(), "Post where you're climbing next") %></div>
    <% } %>
      
    <ul id="FeedItems">
    <% foreach (ClimbFind.Model.Objects.Interfaces.IFeedItem item in UsersActivity)
       { %>
    <li>        
        <img src="<%= item.UserProfileImgUrl %>" />        
        <div>
            <b style="float:left"><%= climberProfile.FullName %></b>
            <span><%= item.PostedDateTime.GetAgoString()%></span>
            <%= item.RenderHTMLPostTopDetails() %>        
            <br />
            <%= item.RenderHTMLOptions() %>
        </div>
      
        <%= item.RenderHTMLPostBody() %>
        <% if (item.Comments.Count > 0) { %><dl><% foreach (FeedPostComment c in item.Comments) { %>
            <dt><img src="<%= c.UserProfileImgUrl %>" /></dt>
            <dd><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %>
            <% if (c.UserID == UserID) { %><a href="/CFFeed/DeletePostComment/<%= c.ID %>">delete</a><% } } %></dd>
        </dl><% } %>   
        <hr />
    </li><% } %>   
    </ul>
     


    <% if (!climberProfile.IsUnfinished)
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
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.Edit(), "Edit profile")%></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.EditPicture(), "Change picture") %></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.EditIndoorPlaces(), "Edit indoor places")%></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.EditOutdoorPlaces(), "Edit outdoor locations")%></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.EditExtendedProfile(), "Edit extended profile")%></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.EditPartnerStatus(), "Set partner status") %></li>
        <li><%= Html.ActionLink<MediaController>(c => c.UsersMedia(climberProfile.ID), "View my movies")%> </li> 
        <li><%= Html.ActionLink<HomeController>(c => c.ChangePassword(), "Change password") %></li>
        <li><%= Html.ActionLink<ClimberProfilesController>(c => c.ConfirmDeleteMe(), "Delete account") %></li>
    </ul>    
    
    <div style="margin:20px 0px 0px 0px"><ad:ProfileAds id="PAds" runat="Server" /></div>
</div>


</asp:Content>
