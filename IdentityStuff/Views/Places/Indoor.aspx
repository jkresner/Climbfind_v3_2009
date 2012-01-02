<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Indoor.aspx.cs" Inherits="IdentityStuff.Views.Places.Indoor" %>
<%@ Register TagPrefix="cf" TagName="IndoorWorldMap" Src="~/Views/Places/IndoorMapCache.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

    <cf:IndoorWorldMap id="MapUC" runat="server" />

</asp:Content>
