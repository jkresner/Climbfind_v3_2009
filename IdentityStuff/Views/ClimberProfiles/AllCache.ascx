<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllCache.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.AllCache" %>
<%@ OutputCache Duration="53600" VaryByParam="None" %>


<style type="text/css">
    .RowOfProfilesInList img { margin-top:4px; }
    .RowOfProfilesInList { overflow:hidden }
</style>


<h1>The Climbfind community</h1>

<div style="width:950px">
<% int i = 0; foreach (ClimberProfile cp in AllProfiles) { %>
<% if (i++ % ColumnWidth == 0) { %> <div class="RowOfProfilesInList"> <% } %>
<a href="/climber-profile/<%= cp.ID %>"><img src="<%= cp.ProfilePictureUrlMini %>" /></a>
<% if (i % ColumnWidth == 0) { %> </div> <% } %><% } %><% if (i % ColumnWidth != 0)
         { %> </div> <% } %>               
</div>
