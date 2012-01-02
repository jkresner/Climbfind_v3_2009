<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Error.aspx.cs" Inherits="IdentityStuff.Views.Shared.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<h1>An error has occured</h1>

<p>Oooops! Climbfind is becoming a really busy site and we are still running in on a tiny little server (and one climbing programmer). 
Sometime errors happen now because too many people ask for something same time, so feel free to try what you were doing one more time.</p>

<p><b>Helpful detail that may explain what happened:</b> <%= exception.Message %></p>

<% if (ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
   { %>

   <p><b>Type:</b> <%= exception.GetType() %></p>
   
   <p><b>Stack Trance:</b> <%= exception.StackTrace %></p>

<% } %>

<p><b>We apologise for the inconvenience</b>, please 

<%= Html.ActionLink<HomeController>(c=>c.Feedback(), "use the feedback page") %>
 to tell us what happened.</p>

<p>Cheers :)</p>

<p><b>What to do next? Try one of these pages and browse to what you are looking for:</b></p>

<ul style="margin: 0px 0px 40px 10px;">
    <li><b><a href="/">Homepage</a></b> - Go back to your homepage feed.</li>
    <li><b><a href="/Places">Places</a></b> - Browse Climbfind's huge database of climbing locations.</li>
    <li><b><a href="/ClimberProfiles/Me">Me</a></b> - Update your profile.</li>
</ul>


</asp:Content>
