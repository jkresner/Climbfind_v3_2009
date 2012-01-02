<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditAreaTag.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditAreaTag" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Edit Area Tag</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>

      <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>
      <script type="text/javascript">
          var map = null;

          function GetMap() 
          {
              <%= GetVirtualEarthMapLoadCode() %>              
          }   
      </script>

   <body onload="GetMap();">
      <div id='<%= MapDivID %>' style="position:relative; width:660px; height:400px;" title="<%= MapTitle %>"></div>
   </body>




<table style="width:90%">
    <tr>
        <th colspan="2">Enter are tag details</th>
    </tr>

    <tr>
        <td style="width:100px">Name</td>
        <td>
            <asp:Label ID="NameLb" runat="server" Width="170" />
         </td>
    </tr> 
    <tr>
        <td style="width:100px">Paragraph name</td>
        <td>
            <VAM:TextBox ID="ParagraphNameTxB" runat="server" Width="170" />
            <VAL:FullName ID="ParagraphNameVAL" runat="server" TargetID="ParagraphNameTxB" FieldName="Short name" Group="AddPlace" Maximum="150" />
        </td>  
    </tr>
    <tr>
        <td style="width:120px">Map Zoom</td>
        <td><VAM:IntegerTextBox ID="MapZoomTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. 6 - 13 )</span></td>
    </tr>
    <tr>
        <td style="width:120px">Latitude &nbsp
        </td><td><VAM:DecimalTextBox ID="LatitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp 51.52878200 )</span></td>
    </tr>
    <tr>
        <td style="width:120px">Longitude</td>
        <td><VAM:DecimalTextBox ID="LongitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp -0.03961200 )</span></td>
    </tr>  
        <tr>
            <td style="width:120px"></td> 
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="UpdateAreaTag_Click" Group="AddPlace" CssClass="button" />
                <%= Html.ActionLink<ModerateController>(c => c.Index(), "Finish", new { _class = "button" })%>
            </td>
        </tr>           
</table>

</form>

</asp:Content>
