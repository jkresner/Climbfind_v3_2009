<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="IdentityStuff.Views.Moderate.UnauthorizedAccess" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Unauthorized access to moderator's feature</h1>

<p><%= User.Identity.Name %>, you need moderator privilages to access the feature you have requested. If you would like to become a
moderator for Climbfind, please email us and introduce yourself :).</p>

</asp:Content>
