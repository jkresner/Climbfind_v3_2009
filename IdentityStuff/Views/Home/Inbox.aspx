<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="ClimbFind.Web.Mvc.Inbox" MasterPageFile="~/Views/Shared/cf.Master" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<div style="width:660px;float:left">

    <h1>Messages received</h1>

    <p class="attentionDIV">See also <%= Html.ActionLink<HomeController>(c=>c.Sent(), "messages sent") %></p>

    <% foreach (UserMessage message in InboxMessages) { %>
    
        <div class="message">        
            <img src="<%= GetUsersPic(message.SendingUserID) %>" width="50px" />
        
            <a href="/write-message/<%= message.SendingUserID %>?RID=<%= message.ID %>">Reply</a> 
            <%= Html.ActionLink<ClimberProfilesController>(c=>c.ReceiverDeleteUserMessage(message.ID), "Delete") %>
            
            <div>From: <b><%= CFControls.ClimberProfileLink(this, message.SendingUserID, GetUsersFullName(message.SendingUserID))%></b> 
                <%= message.SentDateTime.ToShortTimeString() %>, <%= message.SentDateTime.ToLongDateString() %>
                <br />Subject: <b><%= message.Subject %></b>            
                <p><%= message.Message.GetHtmlParagraph() %>... </p>
            </div>        
        </div>  
            
    <% } %>

</div>

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
    <% if (InboxMessages.Count > 5)
      { %><br /><br /><Ad:Google160x600 id="Ad2" runat="server" /><% } %>
</div>


</asp:Content>