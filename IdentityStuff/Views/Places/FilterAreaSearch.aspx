<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterAreaSearch.aspx.cs" Inherits="IdentityStuff.Views.Places.FilterAreaSearch" %><% foreach (AreaTag a in ViewData.Model) { %>
<%= a.FlagImageUrl %>,<%= a.Name %>,<%= a.ID %>    
<% } %>