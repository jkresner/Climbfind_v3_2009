<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Outdoor.aspx.cs" Inherits="IdentityStuff.Views.Places.Outdoor" %>
<%@ Register TagPrefix="cf" TagName="OutdoorWorldMap" Src="~/Views/Places/OutdoorMapCache.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

    <cf:OutdoorWorldMap id="MapUC" runat="server" />

</asp:Content>
