<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="WebFormError.aspx.cs" Inherits="IdentityStuff.Views.Home.WebFormError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<h1>An error has occurred</h1>

<p><b>We apologize for the inconvenience</b>, please 

<%= Html.ActionLink<HomeController>(c=>c.Feedback(), "use the feedback page") %>
 to tell us what happened.</p>

<p>Cheers :)</p>

</asp:Content>
