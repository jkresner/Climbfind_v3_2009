<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ClubsList.aspx.cs" Inherits="IdentityStuff.Views.Admin.ClubsList" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<table style="font-size:11px">
    <tr>
        <td style="width:30px"></td>
        <td style="width:260px"><b>Name</b></td>
        <td></td>
    </tr>
    
<% int i=1; foreach (Club club in Clubs)
   { %>
    
    <tr>
        <td><%= i++ %></td>
        <td>
            <img src="<%= club.FlagImageUrl %>" style="border:none;padding:0px" />
            <%= Html.ActionLink<ClubsController>(c=>c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName), club.Name) %></td>      
        <td>- <a href="/Admin/DeleteClubCompletely/<%= club.ID %>" style="color:Red">delete</a></td>
    </tr>

<% } %>

</asp:Content>
