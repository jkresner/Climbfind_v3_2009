<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteCachedDiskImages.aspx.cs" Inherits="IdentityStuff.Views.Admin.DeleteCachedDiskImages" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<%= ClimbFind.Controller.CFSettings.OSClimberProfilePicImgDir %>

<% foreach (var f in Files)
{%>
  <br /><%= f %>
<% } %>

</asp:Content>
