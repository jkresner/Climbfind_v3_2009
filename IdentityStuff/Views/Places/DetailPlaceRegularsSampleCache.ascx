<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailPlaceRegularsSampleCache.ascx.cs" Inherits="IdentityStuff.Views.Places.DetailPlaceRegularsSampleCache" %>

<% if (Regulars.Count == 0) { %>
<h2>Who has climbed at <%= place.ShortName %></h2>
<p>No one has said they climb here yet :(</p>  
<p class="attentionDIV" style="margin:0px 10px 10px 10px">=> <b><%= Html.ActionLink<ClimberProfilesController>(c=>c.AddPlaceToPlacesUserClimbs(place.ID), string.Format("Add to 'Places I've climbed'", place.ShortName)) %></b></p>

<% } else { %>

<h2><%= Regulars.Count %> have climbed @ <%= place.ShortName %></h2>

<b><%= Html.ActionLink<PlacesController>(c=>c.Regulars(place.FriendlyUrlLocation, place.FriendlyUrlName), "See all people who climb @ " + place.Name) %></b>
 
    <% int j = 0; foreach (ClimberProfile cp in RegularsToDispaly)
       { %><% if(j++ % 3 == 0) { %><div style="padding:10px 0px 5px 0px" class="RowOfProfilesInList"><% } %>            
        <div class="SingleProfileInList" style="width:120px">
            <%= Html.ImagePreview(cp.ProfilePictureUrlMini, cp.ProfilePictureUrlFull, cp.FullName) %>                             
            <br /><img src="<%= cp.FlagImageUrl_Absolute %>" alt="Nationality" style="margin-top:4px" />
            <div><%= CFControls.ClimberProfileLink((ViewPage)this.Page, cp)%></div>
        </div><% if (j % 3 == 0) { %></div><%} %>
    <% } if (j % 3 != 0)
       { %></div><% }
}  %>
   
<div style="clear:both;height:15px"></div>
