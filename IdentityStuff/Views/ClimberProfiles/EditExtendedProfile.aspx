<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditExtendedProfile.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.EditExtendedProfile" %>



<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1>Update extended profile</h1>
<style type"text/css"> #ExtendedProfileTAB tbody tr td textarea { width:98%;height:65px } </style>

<p><span style="color:Red"><b>Note: </b></span>Each section below is optional you may fill out one, all, none or any combination.</p>

<form id="Form1" runat="server">

<table style="width:100%" id="ExtendedProfileTAB">
    <tbody>
        <tr>
            <th colspan="2">Extended profile information</th>
        </tr>
        <tr>
            <td style="width:130px">Grades I climb</td>
            <td><VAM:TextBox ID="GradesTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>        
        <tr>
            <td style="width:130px">Types of climbing I enjoy</td>
            <td><VAM:TextBox ID="LikeToClimbTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>                       
        <tr>
            <td style="width:130px">Climbing ambitions</td>
            <td><VAM:TextBox ID="ClimbingAmbitionsTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Best ever climbing moment</td>
            <td><VAM:TextBox ID="BestMomentTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Favorite places / routes I've climbed</td>
            <td><VAM:TextBox ID="FavoritePlacesTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Places / routes I would like to climb</td>
            <td><VAM:TextBox ID="PlacesIWouldLikeToClimbTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Competitions I compete in</td>
            <td><VAM:TextBox ID="CompetitionsICompeteInTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Projects (specific climbs) I'm working on</td>
            <td><VAM:TextBox ID="CurrentProjectsTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Role models</td>
            <td><VAM:TextBox ID="RoleModelsTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">Favorite climbing brands</td>
            <td><VAM:TextBox ID="FavoriteBrandsTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">What I like about Climbfind</td>
            <td><VAM:TextBox ID="LikeAboutClimbfindTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px">What I think could be better about Climbfind</td>
            <td><VAM:TextBox ID="DislikeAboutClimbfindTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        </tr>
        <tr>
            <td style="width:130px">General climbing history (anything else you want to write)</td>
            <td><VAM:TextBox ID="ClimbingHistoryTxB" runat="server" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td style="width:130px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="UpdateClimberBtN" runat="server" Text="Save" OnClick="SaveExtendedClimberProfile_Click" CssClass="button" />
                <%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Cancel", new { _class = "button" })%>
            </td>
        </tr>                                
    </tbody>
</table>

</form>


</div>

</asp:Content>
