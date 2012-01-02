<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditIndoorPlace.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditIndoorPlace" %>
<%@ Register TagName="AreaTagForCountryTxB" Src="~/Views/Moderate/AreaTagForCountryTxB.ascx" TagPrefix="cf" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Edit indoor place</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>

<table style="width:95%">
    <tr>
        <th colspan="2">Enter place details</th>
    </tr>
    <tr>
        <td style="width:110px">Name </td>
        <td>
            <asp:Label ID="NameLb" runat="server"/>
         </td>
    </tr> 
    <tr>
        <td style="width:120px">Description</td>
        <td><VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" Width="95%" /></td>
    </tr> 
    <tr>
        <td style="width:100px">Address</td>
        <td><VAM:TextBox ID="AddressTxB" runat="server" Width="170" /></td>  
    </tr> 
        <tr>
        <td style="width:100px">Contact number</td>
        <td>
            <VAM:TextBox ID="ContactTxB" runat="server" Width="170" />
            <VAM:RegexValidator ID="RegexValidator1" ControlIDToEvaluate="ContactTxB" Expression="[ 0-9+()]" runat="server" Group="AddPlace" />        
        </td>  
    </tr>
    <tr>
        <td style="width:100px">Website</td>
        <td>http://<VAM:TextBox ID="WebsiteTxB" runat="server" Width="170" />
            <VAM:RequiredTextValidator ID="WebsiteVAL" runat="server" ErrorMessage="Please supply a website so we can research the rest of this gyms details"
                 ControlIDToEvaluate="WebsiteTxB" Group="AddPlace" ErrorFormatterSkinID="Default" />
        </td>  
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
        <td style="width:120px">Latitude &nbsp
        </td><td><VAM:DecimalTextBox ID="LatitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp 51.52878200 )</span></td>
    </tr>
    <tr>
        <td style="width:120px">Longitude</td>
        <td><VAM:DecimalTextBox ID="LongitudeTxB" runat="server" /> &nbsp <span style="font-size:9px">(e.g. &nbsp -0.03961200 )</span></td>
    </tr>      
    <tr>
        <td style="width:120px">Climbing types</td>
        <td>
                    <table id="ClimbingTypesTAB" style="text-align:center;padding:0px">
                        <tr>
                            <td><b>Top Rope</b></td>
                            <td><b>Lead Climb</b></td>
                            <td><b>Boulder</b></td>
                        </tr>
                        <tr>
                            <td style="padding-top:10px"><asp:CheckBox ID="TopRopeCB" runat="server" /></td>
                            <td style="padding-top:10px"><asp:CheckBox ID="LeadClimbCB" runat="server" /></td>
                            <td style="padding-top:10px"><asp:CheckBox ID="BoulderCB" runat="server" /></td>
                        </tr>
                    </table>

            
                <VAM:MultiConditionValidator ID="ClimbingTypeVAL" runat="server" Operator="OR" Group="UpdatePlace"
                     ErrorFormatterSkinID="Selection"  ErrorMessage="You must select at least one type of climbing.">
                    <Conditions>
                        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="TopRopeCB" />
                        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="LeadClimbCB" />
                        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="BoulderCB" />
                    </Conditions>
                </VAM:MultiConditionValidator>             
        </td>
    </tr>    
    <tr>
        <td style="width:120px"></td>
        <td style="padding:6px 0px 6px 10px">
            <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="UpdatePlace_Click" Group="UpdatePlace" CssClass="button" />
            <%= Html.ActionLink<ModerateController>(c => c.Index(), "Cancel", new { _class = "button" })%>
        </td>
    </tr>           
</table>

</form>

</asp:Content>
