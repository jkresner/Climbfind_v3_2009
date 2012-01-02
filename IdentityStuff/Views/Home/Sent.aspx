<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sent.aspx.cs" Inherits="ClimbFind.Web.Mvc.Sent" MasterPageFile="~/Views/Shared/cf.Master" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<div style="width:660px;float:left">
   
    <h1>Sent messages</h1>

    <p class="attentionDIV">See also <%= Html.ActionLink<HomeController>(c=>c.Inbox(), "messages received") %></p>

    <% foreach (UserMessage message in SentMessages)
   { %>
   
    <div class="message">        
        <img src="<%= GetUsersPic(message.ReceivingUserID)%>" width="50px" />
        
        <%= Html.ActionLink<ClimberProfilesController>(c=>c.WriteMessage(message.ReceivingUserID), "New msg") %>
        <%= Html.ActionLink<ClimberProfilesController>(c=>c.SenderDeleteUserMessage(message.ID), "Delete") %>
        
        <div>
            To: <%= CFControls.ClimberProfileLink(this, message.ReceivingUserID, GetUsersFullName(message.ReceivingUserID)) %> 
            <%= message.SentDateTime.ToShortTimeString() %>, <%= message.SentDateTime.ToLongDateString() %>
            <br />Subject: <b><%= message.Subject %></b>            
            <p><%= message.Message.GetHtmlParagraph() %>... </p>
        </div>        
    </div>

    <% } %>
    
</div>

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
    <% if (SentMessages.Count > 5)
      { %><br /><br /><Ad:Google160x600 id="Ad2" runat="server" /><% } %>
</div>


</asp:Content>