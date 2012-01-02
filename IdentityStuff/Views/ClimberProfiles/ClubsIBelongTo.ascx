<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClubsIBelongTo.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.ClubsIBelongTo" %>

        <% if (Clubs.Count != 0)
           { %>    
    <div id="IndoorPlacesDIV" style="clear:both">

     <p style="margin-top:0px"><b>Clubs I belong (or belonged) to:</b></p>     
            
        <% foreach (Club club in Clubs)
               { %>                        
           <div style="margin-right:10px;float:left;text-align:center">
                <img src="<%= club.LogoMiniImageUrl %>" alt='<%= club.Name %>' class="imgGrayBorder" />
                       
                    <br />   
                 <div style="max-width:150px;">
                    <b><%= Html.ActionLink<ClubsController>(c=>c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName), club.Name) %></b>
                 </div>
           </div>                   
        <% }  %>

     </div> 

    <div style="clear:both"></div>

<% } %>