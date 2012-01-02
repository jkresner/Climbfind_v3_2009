<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="WorldMap.aspx.cs" Inherits="IdentityStuff.Views.Places.WorldMap" %>
<%@ Register Src="~/Views/Places/WorldMapCache.ascx" TagPrefix="cf" TagName="WorldMap" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<cf:WorldMap id="WorldMapUC" runat="server" />

</asp:Content>
