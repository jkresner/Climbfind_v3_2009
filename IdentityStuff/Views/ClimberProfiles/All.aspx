<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.All" %>
<%@ Register TagPrefix="cf" TagName="AllProfiles" Src="~/Views/ClimberProfiles/AllCache.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
  
    <cf:AllProfiles id="AllProfilesUC" runat="server" />


</asp:Content>
