<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ByPlace.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.PartnerCalls.ByPlace" MasterPageFile="~/Views/Shared/cf.Master" %>
<%@ Register TagPrefix="cf" TagName="ByPlace" Src="~/Views/PartnerCalls/ByPlaceCache.ascx" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<cf:ByPlace id="ByPlaceCacheUC" runat="server" />   

</asp:Content>