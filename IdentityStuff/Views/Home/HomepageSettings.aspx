<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomepageSettings.aspx.cs" Inherits="ClimbFind.Web.Mvc.HomepageSettings" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

   
<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>

<%--<script type="text/javascript">

    $().ready(function() {
        ToggleAreaTxB();

        $("#ShowTD input").change(function() {
            ToggleAreaTxB();
        });
    });

    function ToggleAreaTxB() 
    {
        if ($("#cf_m_ShowAreaRB").is(":checked")) { $("#cf_m_TxB").removeAttr('disabled'); }
        else { $("#cf_m_TxB").attr('disabled', 'disabled'); }
    }



    $().ready(function() {

        var atxb = $("#<%= TxB.ClientID %>");
        var resultHD = $("#<%= ResultsHD.ClientID %>");

        atxb.autocomplete("/Places/FilterAreaSearch", {
            scroll: false,
            minChars: 2,
            width: 300,
            selectFirst: false,
            formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1]; },
            formatResult: function(data, value) { return value.split(",")[1]; }
        });

        function cancelValue() {
            atxb.removeClass('successSelectTxB');
            resultHD.val('');
            atxb.unbind("change", cancelValue);
        }

        atxb.result(function(event, data, formatted) {
            if (data) {
                if (data[0].split(",")[2] != -1) {
                    atxb.addClass('successSelectTxB');
                    resultHD.val(data[0].split(",")[2]);
                    atxb.bind("change", cancelValue);
                }
            }
        });

    });


</script>
--%>
<div class="vPageSecionTop">
<h1>Homepage settings</h1>

<form runat="server">

<%--<table style="width:90%">
    <tr>
        <th colspan="2">Latest Partner Calls Feed</th>
    </tr>
    <tr>
        <td style="width:90px">Call types</td>
        <td>
            <input id="TypeIndoorRB" type="radio" name="PartnerCallTypes" runat="server" /> Indoor 
            <br /><input id="TypeOutdoorRB" type="radio" name="PartnerCallTypes" runat="server" /> Outdoor 
            <br /><input id="TypeBothRB" type="radio" name="PartnerCallTypes" runat="server" /> Both 
        </td>
    </tr>
    <tr>
        <td style="width:90px">Show</td>
        <td id="ShowTD">
             <input id="ShowAllRB" type="radio" name="PartnerCallShow" runat="server" /> All
             <br />
             <br /><input id="ShowAreaRB" type="radio" name="PartnerCallShow" runat="server" /> Calls within a certain an area (<a href="/Places" target="_blank">see available areas</a>)
             <br />
             <VAM:TextBox ID="TxB" runat="server" Width="200" ValueWhenBlank="Type city/state/country name" />
            <VAM:MultiConditionValidator ID="AreaVAL" runat="server" ErrorMessage="Area not chosen" 
                ErrorFormatterSkinID="Default">
                <Conditions>
                    <VAM:RangeCondition ControlIDToEvaluate="ResultsHD" Minimum="1" Maximum="10000" />
                    <VAM:TextLengthCondition ControlIDToEvaluate="ResultsHD" Minimum="1" />
                </Conditions>     
                <EnablerContainer>
                    <VAM:CheckStateCondition ControlIDToEvaluate="ShowAreaRB" Checked="true" EvaluateOnClickOrChange="false" />
                </EnablerContainer>
            </VAM:MultiConditionValidator>

            <input id="ResultsHD" type="hidden" runat="server" />

             
             <br /><br /><input id="ShowCustomRB" type="radio" name="PartnerCallShow" disabled="disabled" runat="server" /> Custom list of places (Coming soon)            
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <VAM:LinkButton ID="SavePartner" runat="server" OnClick="SaveHomepagePartnerCallFeedSetting_Click" Text="Save" CssClass="button" />
        </td>
    </tr>
</table>--%>


<table style="width:90%">
    <tr>
        <th>Feed email notifications</th>
    </tr>
    <tr>
        <td>
            <div><input id="NotifyOnPostCommentCB" type="checkbox" runat="server" /> Notify me when someone comments on a post that I made.</div>
            <div><input id="NotifyOnPostsICommentedOnCB" type="checkbox" runat="server" /> Notify me when someone else comments on a post that I commented on.</div>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="SaveNotificationsLkB" runat="server" OnClick="SaveFeedSetting_Click" Text="Save" CssClass="button" />
        </td>
    </tr>
</table>   
    

<table style="width:90%">
    <tr>
        <th>Feed privacy settings</th>
    </tr>
    <tr>
        <td>
            <div><input id="PrivacyVisibleToAll" type="radio" runat="server" name="Privacy" /> Make my post visible to everyone</div>
            <div><input id="PrivacyVisibleToWatchers" type="radio" runat="server"  name="Privacy"/> Show my posts only to climbers who I have allowed to watch me.</div>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="SaveFeedPrivacyLkB" runat="server" OnClick="SaveFeedSetting_Click" Text="Save" CssClass="button" />            
        </td>
    </tr>
</table>  

    

</form>

 
 </div>
    
</asp:Content>
