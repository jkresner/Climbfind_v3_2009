<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileLinkWithPictureList.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.ProfileLinkWithPictureList" %>


<div>
 
<% int i = 0; foreach (ClimberProfile cp in Profiles) { %>
    
    <% if (i++ % ColumnWidth == 0) { %> <div class="RowOfProfilesInList"> <% } %>
    
        <div class="SingleProfileInList">       
            <%= Html.ImagePreview(cp.ProfilePictureUrlMini, cp.ProfilePictureUrl, Html.Encode(cp.FullName))%>
            <br /><img src="<%= cp.FlagImageUrl_Absolute %>" alt="Nationality" />
            <div><%= CFControls.ClimberProfileLink(this, cp) %></div>
        </div>
    
     <% if (i % ColumnWidth == 0) { %> </div> <% } %>               
    
<% } %>

      <% if (i % ColumnWidth != 0)
         { %> </div> <% } %>               

</div>
 
 
