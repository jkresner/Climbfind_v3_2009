<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegularsShortlist.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.RegularsShortlist" %>


<div>          
    
     <table style="width:100%">
        <tr><td>
            Displaying <%= DisplayCount %> of  <%= TotalCount %> regulars for        
                <a href="<%= PlaceUrl %>"><%= PlaceName %></a>
        </td>
        <td style="text-align:right">
                <b><a href="<%= AllRegularsForPlaceUrl %>" title="<%= PlaceName %> rock climbing partners">
                    See all regulars at <%= PlaceNameShort%></a></b>                                   
        </td></tr> 
      </table>
          
     <div style="padding:20px 0px 25px 0px" class="RowOfProfilesInList">
        <% foreach (ClimberProfile cp in RegularsToDisplay)
        { %>
        
        <div class="SingleProfileInList">
            <%= Html.ImagePreview(cp.ProfilePictureUrl, cp.ProfilePictureUrlMini, Html.Encode(cp.FullName))%>
                           
            <br /><img src="<%= cp.FlagImageUrl_Absolute %>" alt="Nationality" style="margin-top:4px" />
            <div><%= CFControls.ClimberProfileLink(this, cp)%></div>
        </div>
    
        <% } %>
    </div>
    
</div>