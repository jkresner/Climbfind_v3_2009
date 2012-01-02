<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PageNotFound.aspx.cs" Inherits="IdentityStuff.Views.Shared.PageNotFound" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Page not found</h1>

<p style="color:Red;font-weight:bold">Sorry we could not retrieve the page you requested :(</p>

<p>There are a number of reasons this could have happened... it's probably our fault because we have moved something around.</p>

<p><b>What to do next:</b></p>

<ol style="margin:0px">
    <li>1) Go for a climb.</li>
    <li>2) Browse to what you are looking for from one of the pages below and let us know if you can't find what you're after.</li>
</ol>

<ul style="margin:0px 0px 40px 10px">
    <li><b><a href="/Places">Places</a></b> - A list of areas with climbing gyms, outdoor locations and clubs.</li>
    <li><b><a href="/Clubs">Clubs</a></b> - A list of rock climbing & mountaineering clubs</li>
</ul>


<p>Climb hard :),</p>

<p>The Climbfind Team</p>

</asp:Content>
