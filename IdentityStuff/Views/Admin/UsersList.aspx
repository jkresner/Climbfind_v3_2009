<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="IdentityStuff.Views.Admin.UsersList" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<style> #Users {font-size:10px } #Users a { text-decoration:none } </style>

<div style="font-size:10px;margin:5px 5px 10px 20px">
    <a href="/Admin/UsersList?ProfileComplete=True">Completed profiles</a> -
    <a href="/Admin/UsersList?ProfileComplete=False">Incomplete profiles</a> - 
    <a href="/Admin/UsersList?ActiveOnly=True">Active users</a>
</div>

<table id="Users" style="">

    <tr>
        <td style="width:30px"></td>
        <td style="width:120px"><b>Name</b></td>
        <td style="width:60px"><b>Created</b></td>
        <td style="width:80px"><b>Last Login</b></td>        
        <td style="width:45px"><b>Profile</b></td>        
        <td style="width:190px"><b>Email</b></td>
        <td></td>
    </tr>  
<% int i=1; foreach (MembershipUser user in SiteMembers) { %>
<tr>
    <td><%= i++ %></td>
    <td><%= GetIsModerator(user.Email)%><a href="/Climber-Profile/<%= user.ProviderUserKey %>"><%= GetFullName(user.Email) %></a></td>
    <td><%= user.CreationDate.ToString("dd-MM") %></td>      
    <td><%= user.LastLoginDate.GetDaysToGoString()%></td>        
    <td><%= GetIsFinished(user.Email)%></td>
    <td><%= GetEmailVerified(user.Email)%> <%= user.Email %></td>
    <td><% if (!IsModerator(user.Email)) { %>
        <a href="/Admin/GiveUserModeratorRights/<%= user.ProviderUserKey %>" style="color:green">+ mod</a>            
        <% } else { %>- <a href="/Admin/TakeUserModeratorRights/<%= user.ProviderUserKey %>" style="color:red">- mod</a><% } %>
        - <a href="/Admin/DeleteUserCompletely/<%= user.ProviderUserKey %>" style="color:Red">del</a>            
    </td>
</tr><% } %>

</table>


</asp:Content>
