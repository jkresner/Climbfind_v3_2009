<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Regulars.aspx.cs" Inherits="IdentityStuff.Views.Places.Regulars" %>
<%@ Register TagName="AreaMapRight160x600" TagPrefix="Ad" Src="~/Controls/AdUnits/AreaMapRight160x600.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<div style="width:680px;float:left">

    <h1>Regulars at <%= place.Name %></h1>

    <% if (RegularClimbers.Count == 0)
       { %><p>No one has said they climb here yet :(</p>
       
       <% }
       else
       { %>      
        <p>Displaying <%= RegularClimbers.Count%> regulars for
            <a href="<%= place.ClimbfindUrl %>"><%= place.Name%></a></p>
         <%= Html.RenderUserControl("~/Views/ClimberProfiles/ProfileLinkWithPictureList.ascx", RegularClimbers)%>

    <% } %>
</div>

<div style="width:165px;float:right;margin:-10px 15px 0px 0px">
    <Ad:AreaMapRight160x600 id="AreaAd" runat="server" />
    <br /><br />  
    <Ad:Google160x600 ID="GoogleAds" runat="server" />
</div>


</asp:Content>
