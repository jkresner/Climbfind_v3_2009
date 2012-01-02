<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IdentityStuff.Views.Clubs.Index" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
 
<div class="vPageSectionTop">
    
    <h1>Climbing clubs by country</h1>

    <div class="attentionDIV">If you can't see your club below, <b><%= Html.ActionLink<ClubsController>(c => c.New(), "Add your club") %></b> now</div>    
       
     <style type="text/css">
        .SingleProfileInList { width:145px;margin-top:15px }
     </style>  
       
     <div>   
        
     <% foreach (short countryID in countriesWithClubs) { %>   
       
            <%= getCountrysClubs(countryID) %>
       
     <% } %>
          
     </div>
          
       <%--   
              <div>
            <img src="<%= club.FlagImageUrl %>" style="border:none;padding:0px" />
            <%= Html.ActionLink<ClubsController>(c=>c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName), club.Name) %>
        </div>--%>
         
</div>

</asp:Content>
