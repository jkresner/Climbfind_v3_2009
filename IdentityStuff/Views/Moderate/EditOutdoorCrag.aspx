<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditOutdoorCrag.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditOutdoorCrag" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Edit <%= Crag.Name %></h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>

<table style="width:98%">
    <tr>
        <th colspan="2">Enter climbing details</th>
    </tr>
    <tr>
        <td style="width:100px">Name </td>
        <td>
            <asp:Label ID="NameLb" runat="server" />
         </td>
    </tr>
<%--    <tr>
        <td style="width:100px">Type </td>
        <td><DDL:OutdoorClimbingTypeDDL ID="OutdoorClimbingTypeDDLUC" runat="server" Width="170" /></td>
    </tr>--%>
    <tr>
        <td style="width:100px">Description</td>
        <td><VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65"  /></td>
    </tr>
    <tr>
        <td style="width:100px">History <div style="font-size:9px">E.g. First climbed / bolted, pioneers & heros, last rebolting etc.</div></td>
        <td><VAM:TextBox ID="HistoryTxB" runat="server" TextMode="MultiLine" Width="98%" Height="70"  /></td>
    </tr>
    <tr>
        <td style="width:100px">Access <div style="font-size:9px">E.g. Is access effected by tides, do you need a permit, 4WD, boat, machete, hiking boots...</div></td>
        <td><VAM:TextBox ID="AccesssTxB" runat="server" TextMode="MultiLine" Width="98%" Height="80"  /></td>
    </tr>
    <tr>
        <td style="width:160px">Approach <div style="font-size:9px">"From the carpark follow the path, turn left when you get to the sign... "</div></td>
        <td><VAM:TextBox ID="ApproachTxB" runat="server" TextMode="MultiLine" Width="98%" Height="80"  /></td>
    </tr>    
    <tr>
        <td style="width:100px">Mosquitoes / sandflies</td>
        <td>
            Not sure <input id="MaybeMosquitoRB" type="radio" runat="server" Checked="True" />,            
            Yes <input id="YesMosquitoRB" type="radio" runat="server" />,
            No <input id="NoMosquitoRB" type="radio" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width:160px">Climbing types</td>
        <td>
            <input id="HasAlpineCB" type="checkbox" runat="server" /> Alpine climbing          
            <br /><input id="HasBoulderCB" type="checkbox" runat="server" /> Bouldering
            <br /><input id="HasBuilderingCB" type="checkbox" runat="server" /> Buildering
            <br /><input id="HasDeepWaterSoloingCB" type="checkbox" runat="server" /> Deep water soloing
            <br /><input id="HasIceCB" type="checkbox" runat="server" /> Ice climbing
            <br /><input id="HasLeadCB" type="checkbox" runat="server" /> Lead climbing
            <br /><input id="HasMultipitchCB" type="checkbox" runat="server" /> Multipitch routes
            <br /><input id="HasSoloCB" type="checkbox" runat="server" /> Has soloing promblems (with no water)
            <br /><input id="HasSportCB" type="checkbox" runat="server" /> Has sport routes
            <br /><input id="HasTopRopeCB" type="checkbox" runat="server" /> Has top rope 
            <br /><input id="HasTradCB" type="checkbox" runat="server" /> Has trad routes (climbing with gear placement)
        </td>    
    </tr>    
    <tr>
        <td style="width:100px">Ok to climb</td>
        <td>
            <div>
                <b>Summer AM:</b> 
                Not sure <input id="SummerAMNotSure" type="radio" runat="server" Checked="True" name="SummerAM" />,            
                Yes <input id="SummerAMYes" type="radio" runat="server" name="SummerAM" />,
                No <input id="SummerAMNo" type="radio" runat="server" name="SummerAM" />
            </div>
            <div>
                <b>Summer PM:</b> 
                Not sure <input id="SummerPMNotSure" type="radio" runat="server" Checked="True" name="SummerPM" />,            
                Yes <input id="SummerPMYes" type="radio" runat="server" name="SummerPM" />,
                No <input id="SummerPMNo" type="radio" runat="server" name="SummerPM" />
            </div>        
            <div>
                <b>Winter AM:</b> 
                Not sure <input id="WinterAMNotSure" type="radio" runat="server" Checked="True" name="WinterAM" />,            
                Yes <input id="WinterAMYes" type="radio" runat="server" name="WinterAM" />,
                No <input id="WinterAMNo" type="radio" runat="server" name="WinterAM" />
            </div>        
            <div>
                <b>Winter PM:</b> 
                Not sure <input id="WinterPMNotSure" type="radio" runat="server" Checked="True" name="WinterPM" />,            
                Yes <input id="WinterPMYes" type="radio" runat="server" name="WinterPM" />,
                No <input id="WinterPMNo" type="radio" runat="server" name="WinterPM" />
            </div>        
        </td>
    </tr>           
        <tr>
            <td style="width:130px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="UpdateCrag_Click" Group="AddPlace" CssClass="button" />
                <%= Html.ActionLink<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, Crag.FriendlyUrlName), "Cancel", new { _class = "button" })%>
            </td>
        </tr>           
</table>

</form>

</asp:Content>
