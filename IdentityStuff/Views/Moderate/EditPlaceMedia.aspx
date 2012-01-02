<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditPlaceMedia.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditPlaceMedia" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Edit media for <%= place.Name %></h1>

<% if (Media.Count == 0)
   {  %> <%= place.Name%> has no associated media.  <% }
   else
   { %>

    <table style="width:100%;font-size:8px" class="NoStylesTable">
        <tr>
            <td><b>Title</b></td><td><b>Type</b></td><td><b>Description</b></td><td><b>By</b></td><td><b>Submitted</b></td>
        </tr>

<% foreach (MediaShare media in Media)
   { %><tr>
    <td><%= media.Name.Take(20) %>..</td>
    <td><%= media.Type.ToString()%></td>
    <td><%= media.Description.Take(40) %>  ...</td>
    <td><a href="/climber-profile/<%= media.SubmittedByUserID %>" target="_blank"><%= GetClimberName(media.SubmittedByUserID) %></a></td>
    <td><%= media.SubmittedDateTime.ToShortDateString() %></td>
    </tr>
<% } %> </table>
<% } %>


<div class="vPageSection">
    <h1>Add media</h1>

    <table width="98%">
        <tr>
            <th colspan="2">Add you tube movie</th>
        </tr>
        <tr>
            <td style="width:100px">YouTube ID</td>
            <td><VAM:TextBox ID="YouTubeUrlTxB" runat="server" Width="330" /> 
            <div style="font-size:9px">(e.g. http://www.youtube.com/watch?v=<span style="color:Red"><b>7FpOFhZX48w</b></span> )</div></td>
        </tr>
        <tr>
            <td style="width:100px">Title</td>
            <td><VAM:TextBox ID="YouTubeTitleTxB" runat="server" Width="230" /></td>
        </tr>
        <tr>
            <td style="width:100px">Description</td>
            <td><asp:TextBox id="YouTubeDescriptionTxB" runat="server" TextMode="MultiLine" Width="96%" Height="60" /></td>
        </tr>
    <tr>
        <td style="width:100px"></td>
        <td style="padding:6px 0px 6px 10px">
            <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" Group="UpdatePlace" OnClick="AddYouTubeMovie_Click" CssClass="button" />
        </td>
    </tr>          
    </table>

</div>


</form>

</asp:Content>
