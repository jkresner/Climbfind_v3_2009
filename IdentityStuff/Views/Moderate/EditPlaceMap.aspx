<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" AutoEventWireup="true" CodeBehind="EditPlaceMap.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditPlaceMap" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Edit place map location</h1>

<form runat="server">

<div class="inputForm" style="width:95%">
    <label>Map where <%= place.Name %> is</label>
    <cf:MapCoordinatePicker ID="MapCoordinatePickerUC" runat="server" />
        
    <hr />
        <asp:LinkButton ID="SaveBtn" OnClick="SaveMap_Click" Text="Save" runat="server" CssClass="superButton" />
        <a href="<%= place.ClimbfindUrl %>" class="button" style="margin:26px 0px 0px 8px">Cancel</a>
    <hr />
</div>

</form>

</asp:Content>
