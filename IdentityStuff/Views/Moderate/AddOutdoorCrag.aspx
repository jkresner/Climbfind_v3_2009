<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="AddOutdoorCrag.aspx.cs" Inherits="IdentityStuff.Views.Moderate.AddOutdoorCrag" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Add a crag to <%= Place.Name %></h1>


<table style="width:98%">
    <tr>
        <th colspan="2">Enter crag details</th>
    </tr>
    <tr>
        <td style="width:160px">Name </td>
        <td>
            <VAM:TextBox ID="NameTxB" runat="server" Width="210" />
            <VAL:PlaceName ID="NameVAL" runat="server" TargetID="NameTxB" FieldName="Place name" Group="AddPlace" Maximum="150" />
         </td>
    </tr>
<%--    <tr>
        <td style="width:160px">Type </td>
        <td><DDL:OutdoorClimbingTypeDDL ID="OutdoorClimbingTypeDDLUC" runat="server" Width="170" /></td>
    </tr>
--%>
    <tr>
        <td style="width:160px">Description</td>
        <td><VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65"  /></td>
    </tr>
    <tr>
        <td style="width:160px">History <div style="font-size:9px">First climbed / bolted, pioneers & heros, last rebolted</div></td>
        <td><VAM:TextBox ID="HistoryTxB" runat="server" TextMode="MultiLine" Width="98%" Height="70"  /></td>
    </tr>
    <tr>
        <td style="width:160px">Access <div style="font-size:9px">Tides, permits, 4WD required, boat, machete, hiking boots...</div></td>
        <td><VAM:TextBox ID="AccesssTxB" runat="server" TextMode="MultiLine" Width="98%" Height="80"  /></td>
    </tr>
    <tr>
        <td style="width:160px">Approach <div style="font-size:9px">"From the carpark follow the path, turn left when you get to the sign... "</div></td>
        <td><VAM:TextBox ID="ApproachTxB" runat="server" TextMode="MultiLine" Width="98%" Height="80"  /></td>
    </tr>
    <tr>
        <td style="width:160px">Bugs <div style="font-size:9px">Mosquitoes, Sanflies etc.</div></td>
        <td>
            <input id="MaybeMosquitoRB" type="radio" runat="server" Checked="True" /> Not sure             
            <br /><input id="YesMosquitoRB" type="radio" runat="server" /> Yes 
            <br /><input id="NoMosquitoRB" type="radio" runat="server" /> No 
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
  <%--     <tr>
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
        <td style="width:130px">Short name </td>
        <td>
            <VAM:TextBox ID="ShortNameTxB" runat="server" Width="170" />
            <VAL:FullName ID="ShortNameVAL" runat="server" TargetID="ShortNameTxB" FieldName="Short name" Group="AddPlace" Maximum="50" />
        </td>  
    </tr>
    <tr>
        <td style="width:130px">Search group</td>
        <td><DDL:AreaDDL id="AreaDDLUC" runat="server" Width="250" /></td>
    </tr>  

--%>        
        <tr>
            <td style="width:130px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="CreateCrag_Click" Group="AddPlace" CssClass="button" />
                <%= Html.ActionLink<ModerateController>(c => c.Index(), "Cancel", new { _class = "button" })%>
            </td>
        </tr>           
</table>

</form>

</asp:Content>
