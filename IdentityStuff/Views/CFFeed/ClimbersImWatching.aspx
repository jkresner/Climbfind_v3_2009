<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="ClimbersImWatching.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.ClimbersImWatching" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
<h1>People in your 'Climbers Channel'</h1>

<div><b>Summary</b></div>

<p>You are watching <%= WatchedClimbers.Count %> climbers ... <%= Html.ActionLink<CFFeedController>(c => c.FindClimbersForWatchList(), "Find more climbers now!")%></p>

<% if (WatchedClimbers.Count > 0)
   { %>
<p>Latest climber to join your Climbers channel <b><%= CFControls.ClimberProfileLink(this, GetLatestWatchedClimber())%></b></p>
<% } %>
<% if (GetLatestWatchedClimber() != null) { %>
<p>Latest climber your requested to be on your Climbers channel <b><%= CFControls.ClimberProfileLink(this, GetLatestRequestedClimber())%></b></p>
<% } %>

<% if (Climbers.Count != 0) { %>
<div style="margin:0px 0px 10px 0px"><b>Climbers you are watching</b></div>

<% foreach (FeedClimberChannelRequest c in Climbers)
   { %>
    <div style="padding:4px 4px 4px 6px;float:left;border:solid 1px #D3D3D3;width:204px;height:45px;margin:0px 3px 3px 0px">
       <img src="<%= GetC(c).ProfilePictureUrlMini %>" style="width:25px;border:none;padding:0;margin:3px 6px 0px 0px;float:left" />
       <div style="float:left">
            <b><%= CFControls.ClimberProfileLink(this, GetC(c)) %></b>
            <br />
            <% if (c.Approved) { %><a href="#">Stop watching</a><% } else { %>
            <span>Request pending</span><% } %>            
        </div>
    </div>
       
<% } %>


<% } %>



</div>

</asp:Content>
