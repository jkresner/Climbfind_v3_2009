<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreaPicker.ascx.cs" Inherits="IdentityStuff.Controls.AreaPicker" %>


<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>


<script type="text/javascript">

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
                atxb.addClass('successSelectTxB');
                resultHD.val(data[0].split(",")[2]);
                atxb.bind("change", cancelValue);
            }
        });

    });

</script>
	
<VAM:TextBox ID="TxB" runat="server" Width="200" ValueWhenBlank="Type city/state/country name" />
<VAM:MultiConditionValidator ID="AreaVAL" runat="server" ErrorMessage="Area not chosen" 
    ErrorFormatterSkinID="Default">
    <Conditions>
        <VAM:RangeCondition ControlIDToEvaluate="ResultsHD" Minimum="1" Maximum="10000" />
        <VAM:TextLengthCondition ControlIDToEvaluate="ResultsHD" Minimum="1" />
    </Conditions>     
</VAM:MultiConditionValidator>

<input id="ResultsHD" type="hidden" runat="server" />
