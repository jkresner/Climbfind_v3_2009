<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="FirstPost.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.FirstPost" %>
<%@ Register Src="~/Controls/PlacePicker.ascx" TagName="PlacePicker" TagPrefix="cf" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />
<script type='text/javascript' src='/js/jquery.boxy.js'></script>
<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>
<script type="text/javascript">

    $().ready(function() {

        var placeTxB = $("#<%= PlacesTxB.ClientID %>");
        var resultHD = $("#<%= PID.ClientID %>");

        placeTxB.autocomplete("/Places/FilterSearch", {
            scroll: false,
            minChars: 2,
            width: 300,
            selectFirst: false,
            formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1] + "; " + value.split(",")[2]; },
            formatResult: function(data, value) { return value.split(",")[2]; }
        });

        function cancelValue() {
            placeTxB.removeClass('successSelectTxB');
            resultHD.val('');
            placeTxB.unbind("change", cancelValue);
        }

        placeTxB.result(function(event, data, formatted) {
            if (data) {
                if (data[0].split(",")[3] != '-1') {
                    placeTxB.addClass('successSelectTxB');
                    resultHD.val(data[0].split(",")[3]);
                    placeTxB.bind("change", cancelValue);
                } else if (data[0].split(",")[3] = '-1') {
                    placeTxB.addClass('alertSelectTxB');
                }
            }
        });
    });

</script>


<h1>Welcome to Climbfind</h1>

<h3>First step, introduce yourself to others who climb where you want to climb</h3>

<form runat="server">

<div class="inputForm" style="width:740px">

<p class="formTip" style="width:140px"><b>Help</b>Place not coming up in the textbox? <a id="AddLink" href="#AddPlaceModal" title="Add a place to Climbfind">Add it to Climbfind</a></p>


<label>Where you want to climb</label>
<VAM:TextBox ID="PlacesTxB" runat="server" Width="300" ValueWhenBlank="Type to select place" />
<VAM:TextBox id="PID" runat="server" style="display:none" />
<div style="width:2px;float:left">
<VAM:RequiredTextValidator ID="PVAL" runat="server" ControlIDToEvaluate="PID" ErrorMessage="Place not found, please add place to climbfind." ErrorFormatterSkinID="Default" Group="Post" />
<VAM:RangeValidator ID="PIDVAL" runat="server" ControlIDToEvaluate="PID" DataType="Integer" Minimum="1" Maximum="100000" ErrorMessage="Place not found, please add place to climbfind." ErrorFormatterSkinID="Default" Group="Post" />
</div>

<div style="width:71%"><label>About you - <i style="font-size:10px"><b style="color:Red">NOTE</b> people will receive this in an email. <br /><%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Skip this step", new { tabIndex = "100" })%> if you don't want to tell them about yourself.</i><cf:CharacterCount id="ContextCount" runat="server" TargetID="MessageTxB" /></label></div>
<asp:TextBox id="MessageTxB" runat="server" TextMode="MultiLine" Width="70%" Height="80px" />
<div style="width:2px;float:left"><VAL:Message ID="MessageVAL" FieldName="Message" Minimum="5" Maximum="255" TargetID="MessageTxB" runat="server" Group="Post" /></div>

<hr />
<VAM:LinkButton ID="PostBtN" Text="Save" CssClass="superButton" OnClick="SavePost_Click" runat="server" Group="Post" />
<hr />

</div>

</form>


</asp:Content>
