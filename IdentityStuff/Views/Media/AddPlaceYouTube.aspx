<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="AddPlaceYouTube.aspx.cs" Inherits="IdentityStuff.Views.Media.AddPlaceYouTube" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">

<div class="vPageSectionTop">
<h1>Add YouTube movie to <%= place.Name %></h1>

    <table width="98%">
        <tr>
            <th colspan="2">Add you tube movie</th>
        </tr>
        <tr>
            <td style="width:100px">YouTube ID</td>
            <td>www.youtube.com/watch?v=<VAM:TextBox ID="YouTubeUrlTxB" runat="server" Width="130" /> 
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
