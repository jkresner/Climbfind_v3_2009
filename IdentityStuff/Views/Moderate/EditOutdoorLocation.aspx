<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" AutoEventWireup="true" CodeBehind="EditOutdoorLocation.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditOutdoorLocation" %>
<%@ Register TagName="AreaTagForCountryTxB" Src="~/Views/Moderate/AreaTagForCountryTxB.ascx" TagPrefix="cf" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Edit outdoor location</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>


<table style="width:95%">
    <tr>
        <th colspan="2">Enter place details</th>
    </tr>
    <tr>
        <td style="width:100px">Name </td>
        <td>
            <asp:Label ID="NameLb" runat="server"/>
         </td>
    </tr>    
    <% if (UserIsModerator)
       { %>
    <tr>
        <td style="width:100px">Short Name </td>
        <td>
            <asp:TextBox ID="ShortNameTxB" runat="server"/>
         </td>
    </tr>     
    <% } %>
    <tr>
        <td style="width:120px">Latitude
        </td><td><VAM:DecimalTextBox ID="LatitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp 51.52878200 )</span></td>
    </tr>
    <tr>
        <td style="width:120px">Longitude</td>
        <td><VAM:DecimalTextBox ID="LongitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp -0.03961200 )</span></td>
    </tr>
    <tr>
        <td style="width:120px">Area Tags</td>
        <td>
            <div style="font-size:9px;font-style:italic;float:right;width:210px">Area tags are how climbfind categorises places into areas pages and channels for the homepage feed. You can see all areas on Climbfind <a href="/Places" target="_blank">here</a>.
            We are always adding more. <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">Email us</a>
                If you think we need to add one             
            </div>


            <p style="padding:0;margin:0px  0px 5px 0px">Make sure <%= place.Name %> is tagged with ALL appropriate areas</p>

            <cf:AreaTagForCountryTxB id="AreaTxB" runat="server" Group="AddArea" />
            <br />> <VAM:LinkButton ID="AddAreaLkB" runat="server" Text="Add area tag" OnClick="AddAreaTag_Click" Group="AddArea" />
            
            <div style="margin:5px  0px 5px 0px">
                   <asp:DataList ID="AreaTagsLV" runat="server">
                    <ItemTemplate>
                        <img src='<%# Bind("FlagImageUrl") %>' runat="server" id="FlagImg" style="border:none;padding:0;margin:0" />
                        <asp:Literal id="NameLtr" Text='<%# Bind("Name") %>' runat="server" /> 
                        <asp:LinkButton ID="DelLkB" runat="server" Text="Del" OnClick="RemoveAreaTag_Click" Visible='<%# !(bool)Eval("IsCountry") %>' />
                        <asp:Literal id="AreaTagIDLtr" Text='<%# Bind("ID") %>' Visible="false" runat="server" />
                        <br />
                    </ItemTemplate>    
                </asp:DataList>
            </div>
            
              
        
        </td>
    </tr>    
    <tr>
        <td style="width:90px">About <br />(intro description)</td>
        <td><VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65" /></td>
    </tr>
    <tr>
        <td style="width:90px">Directions</td>
        <td><VAM:TextBox ID="DirectionsTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65" /></td>
    </tr>
    <tr>
        <td style="width:90px">Accommodation</td>
        <td><VAM:TextBox ID="AccommodationTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65" /></td>
    </tr>
    <tr>
        <td style="width:90px">Food</td>
        <td><VAM:TextBox ID="FoodTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65" /></td>
    </tr>    
    <tr>
        <td style="width:90px">Local beta<br />(other useful info)</td>
        <td><VAM:TextBox ID="LocalBetaTxB" runat="server" TextMode="MultiLine" Width="98%" Height="65"/></td>
    </tr>  
    
        <tr>
            <td style="width:120px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="UpdatePlace_Click" Group="UpdatePlace" CssClass="button" />
                <%= Html.ActionLink<PlacesController>(c => c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName), "Cancel", new { _class = "button" })%>
            </td>
        </tr>           
</table>

</form>

</asp:Content>
