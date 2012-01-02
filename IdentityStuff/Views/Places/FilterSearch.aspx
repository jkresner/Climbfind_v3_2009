<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterSearch.aspx.cs" Inherits="IdentityStuff.Views.Places.FilterSearch" %><% foreach (Place p in ViewData.Model) { %>
<%= p.FlagImageUrl2 %>,<%= p.ShortName %>,<%= p.Name %>,<%= p.ID %>    
<% } %>