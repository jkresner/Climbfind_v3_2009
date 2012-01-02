<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" AutoEventWireup="true" CodeBehind="AddIndoorPlace.aspx.cs" Inherits="IdentityStuff.Views.Moderate.AddIndoorPlace" %>
<%@ Register Src="~/Views/Moderate/PlaceChecker.ascx" TagName="PlacePicker" TagPrefix="cf" %>
<%@ Register TagName="AreaTagForCountryTxB" Src="~/Views/Moderate/AreaTagForCountryTxB.ascx" TagPrefix="cf" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<asp:HiddenField ID="PlaceIDHD" runat="server" Visible="false" />
<h1>Add a new indoor place</h1>

<form runat="server">

<asp:MultiView ID="AddPlaceMV" runat="server" ActiveViewIndex="0">

<asp:View ID="VIEWCheckFirst" runat="server">

<h3>Step 1 of 4) Confirm you are NOT adding a place that's already in our system</h3>

<div class="inputForm">
    <label>Name of place you wish to add</label>

    <cf:PlacePicker id="PlaceCheckerUC" runat="server" Mode="Indoor" />
    <hr />
    <p> > <b><asp:LinkButton ID="ContinueToDetailsLkB" runat="server" Text="Continue to step 2" OnClick="ContinueToDetails_Click" /></b> ONLY if the location you want to add did not come up in the text box.</p>

</div>

</asp:View>



<asp:View ID="VIEWAddDetails" runat="server">

<h3>Step 2 of 4 Supply basic information</h3>


<div class="inputForm" style="width:600px">

<label>Country</label>
<DDL:NationalityDDL ID="NationalityDDLUC" runat="server" Width="182" AllowUK="false" />

<label>Name <i>E.g. 'The Castle Climbing Centre'</i></label>
<VAM:TextBox ID="NameTxB" runat="server" Width="190"/>
<VAL:PlaceName ID="NameVAL" runat="server" TargetID="NameTxB" FieldName="Place name" Group="AddPlace" Maximum="150" />

<label>Short name <i> E.g. 'The Castle'</i></label>
<VAM:TextBox ID="ShortNameTxB" runat="server" Width="190" />
<VAL:PlaceName ID="ShortNameVAL" runat="server" TargetID="ShortNameTxB" FieldName="Short name" Group="AddPlace" Maximum="50" />

<label>Do you climb here regularly?</label>
<input id="IsRegularRB" type="radio" runat="server" name="IsRegular" checked="true" /> Yes
<br /><input id="IsNotRegularRB" type="radio" runat="server" name="IsRegular" /> No

<%--<label>Description</label>
<VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" /></td>--%>
<%--<label>Contact number</label>
<VAM:TextBox ID="ContactTxB" runat="server" Width="170" />
<VAM:RegexValidator ID="RegexValidator1" ControlIDToEvaluate="ContactTxB" Expression="[ 0-9+()]" runat="server" Group="AddPlace" />
--%>

<label>Address</label>
<VAM:TextBox ID="AddressTxB" runat="server" Width="280" />

<label>Website</label>
<i style="float:left">http://</i><VAM:TextBox ID="WebsiteTxB" runat="server" Width="242" />
<VAM:RequiredTextValidator ID="WebsiteVAL" runat="server" ErrorMessage="Please supply a website so we can research the rest of this gyms details"
                 ControlIDToEvaluate="WebsiteTxB" Group="AddPlace" ErrorFormatterSkinID="Default" />

<label>Climbing types</label>

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

<VAM:MultiConditionValidator ID="ClimbingTypeVAL" runat="server" Operator="OR" Group="AddPlace"
    ErrorFormatterSkinID="Selection"  ErrorMessage="You must select at least one type of climbing.">
    <Conditions>
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="TopRopeCB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="LeadClimbCB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="BoulderCB" />
    </Conditions>
</VAM:MultiConditionValidator>             
        
    <hr />
    <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Continue" OnClick="CreatePlace_Click" Group="AddPlace" CssClass="superButton" />
    <hr />

</div>

</asp:View>

<asp:View ID="VIEWPlotOnMap" runat="server">

    <h3>Step 3 of 4 plot place on our world map so other users can find it</h3>
   
    <div class="inputForm">
    
        <label>Spot where <%= NewPlace.Name %></label>
    
        <cf:MapCoordinatePicker ID="MapCoordinatePickerUC" runat="server" ClientFunction="UpdateMapFromClient();" />
        
        <script type="text/javascript">
            function UpdateMapFromClient() {
                var LatHD = document.getElementById('cf_m_MapCoordinatePickerUC_LatitudeHD');
	            var LonHD = document.getElementById('cf_m_MapCoordinatePickerUC_LongitudeHD');
                $("XZ").load("/Moderate/SavePlaceMap", { placeID:<%= NewPlaceID %>, lat: LatHD.value, lon:LonHD.value });
            }
        </script>
        <div id="XZ"></div>
        <hr />
        <asp:LinkButton ID="SaveCoordinatesLkb" runat="server" OnClick="SaveCoordinates_Click" Text="Save" CssClass="superButton" />
        &nbsp <asp:Label ID="SelectOnMapLb" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Please plot point on the map" />
        <p style="margin:8px 0px 0px 70px">or if you are having trouble <asp:LinkButton ID="SkipMapLkB" runat="server" OnClick="GoToAreaTags_Click" Text="skip this step" /></p>
        <hr />
        
    </div>

</asp:View>

<asp:View ID="VIEWAddAreaTags" runat="server">

    <h3>Step 4 of 4) Add area tags</h3>
   
    <div class="inputForm" style="width:640px">
    
        <p class="formTip">
            <b>About area tags</b>
        Area tags are how climbfind categorises places into areas pages and channels for the homepage feed. You can see all areas on Climbfind <a href="/Places" target="_blank">here</a>.
            We are always adding more. <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">Email us</a>
            If you think we need to add one             
        </p>  
            
              
        <label>Tag <%= NewPlace.Name %> with all relevant area tags</label>


        <cf:AreaTagForCountryTxB id="AreaTxB" runat="server" Group="AddArea" />
        <div style="clear:left">> <VAM:LinkButton ID="AddAreaLkB" runat="server" Text="Add area tag" OnClick="AddAreaTag_Click" Group="AddArea" /></div>
        
        <div style="border-bottom:solid 1px black;color:Black;font-size:9px;width:90px;margin:10px 0px 10px 5px">Current area tags</div>
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
        

        <hr />
        <asp:LinkButton ID="FinishLkB" runat="server" OnClick="GoToPlacePage_Click" Text="Finish" CssClass="superButton" />
        <hr />            
        
    </div>

</asp:View>

</asp:MultiView>

</form>

</asp:Content>
