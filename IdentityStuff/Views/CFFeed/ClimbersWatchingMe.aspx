<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="ClimbersWatchingMe.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.ClimbersWatchingMe" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
<h1>Climbers watching me</h1>

<% if (WatchRequestsNeedingReply.Count > 0)
   { %>
    <div><b>Users wanting to add you to their <i>climbers channel</i></b></div> 
   <%
       foreach (FeedClimberChannelRequest c in WatchRequestsNeedingReply)
       { %>
    <div style="padding:4px 4px 4px 6px;float:left;border:solid 1px #D3D3D3;width:204px;height:45px;margin:0px 3px 3px 0px">
       <img src="<%= GetC(c).ProfilePictureUrlMini %>" style="width:25px;border:none;padding:0;margin:3px 6px 0px 0px;float:left" />
       <div style="float:left">
            <b><%= CFControls.ClimberProfileLink(this, GetC(c)) %></b>
            <br />
            <span><a href="/join-climbers-channel/<%= c.ID %>">Allow</a> - <a href="#">Deny</a> - <a href="#">Block user</a></span>        
        </div>
    </div>  <% } %>    
<% } %>

<div style="clear:both"><b>Summary</b></div>

<p>You are being watched by <%= Climbers.Count%> climbers</p>

<% if (Climbers.Count > 0 && GetClimberWhoseChannelYouJoined() != null)
   { %>
<p>Latest climber whose channel you joined <b><%= CFControls.ClimberProfileLink(this, GetClimberWhoseChannelYouJoined())%></b></p>
<% } %>

<div style="margin-bottom:10px"><b>You appear in the channels of</b></div>

<% foreach (FeedClimberChannelRequest c in Climbers)
   { %>
    <div style="padding:4px 4px 4px 6px;float:left;border:solid 1px #D3D3D3;width:204px;height:45px;margin:0px 3px 3px 0px">
       <img src="<%= GetC(c).ProfilePictureUrlMini %>" style="width:25px;border:none;padding:0;margin:3px 6px 0px 0px;float:left" />
       <div style="float:left">
            <b><%= CFControls.ClimberProfileLink(this, GetC(c)) %></b>
            <br />
            <% if (c.Approved) { %><a href="#">Leave channel</a><% } else { %>
            <span>Request pending</span><% } %>            
        </div>
    </div>
<% } %>

</div>



</asp:Content>
