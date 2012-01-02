<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="ShowReply.aspx.cs" Inherits="IdentityStuff.Views.PartnerCalls.ShowReply" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
    <h1>Reply to your call from <%= Html.Encode(Replier.FullName)%></h1>

    <%= CFControls.ClimberProfileFull(this, Replier)%>

    <div style="margin:25px 0px 25px 0px" class="vPageSection">

      <h1><%= Html.Encode(Replier.FullName)%> Said on
        <%= Html.Encode(CurrentReply.ReplyDateTime.ToString("hh:mm tt dd MMM"))%>
      </h1>  

       <%= Html.Encode(CurrentReply.Message) %>

    </div>
</div>
  
</asp:Content>
