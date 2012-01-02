<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Places.Index" %>
<%@ Register TagPrefix="cf" TagName="PlaceList" Src="~/Views/Places/IndexCache.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
  
    <cf:PlaceList id="PlaceListUC" runat="server" />

</asp:Content>
