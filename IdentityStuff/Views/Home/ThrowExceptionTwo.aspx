<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="ThrowExceptionTwo.aspx.cs" Inherits="IdentityStuff.Views.Home.ThrowExceptionTwo" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<% throw new Exception("Testing exception two"); %>

</asp:Content>
