<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddThisBookmark.ascx.cs" Inherits="IdentityStuff.Views.Shared.AddThisBookmark" %>


    <% if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
       { %>
       
    
<script type="text/javascript">    var addthis_pub = "jkresner"; </script>
<a href="http://www.addthis.com/bookmark.php?v=20" onmouseover="return addthis_open(this, '', 'http://cf3.climbfind.com<%= BookmarkUrl %>', '<%= BookmarkTitle %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()">
    <img src="http://s7.addthis.com/static/btn/lg-share-en.gif" width="125" height="16" alt="Bookmark and Share" style="border:0;padding:0px 10px 0px 0px"/></a>
    <script type="text/javascript" src="http://s7.addthis.com/js/200/addthis_widget.js"></script>
       
       <% }
       else
       { %>
    
     <img src="/images/UI/lg-share-en.gif" width="125" height="16" alt="Bookmark and Share" style="border:0;padding:0px 10px 0px 0px"/>
   
    <% } %>
    