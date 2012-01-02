<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlacePicker.ascx.cs" Inherits="IdentityStuff.Controls.PlacePicker" %>
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
                } else if (data[0].split(",")[3] = '-1')
                {
                    placeTxB.addClass('alertSelectTxB');                
                }
            }
        });
    });

</script>
	
<VAM:TextBox ID="PlacesTxB" runat="server" Width="300" ValueWhenBlank="Type to select place" />
<VAM:TextBox id="PID" runat="server" style="display:none" />
<div style="width:2px;float:left"><VAM:RequiredTextValidator ID="PVAL" runat="server" ControlIDToEvaluate="PID"
    ErrorMessage="Place not found, please add place to climbfind." 
    ErrorFormatterSkinID="Default" Group="AddMovie" />
<VAM:RangeValidator ID="PIDVAL" runat="server"  ControlIDToEvaluate="PID" DataType="Integer" Minimum="1" Maximum="100000"
 ErrorMessage="Place not found, please add place to climbfind." 
    ErrorFormatterSkinID="Default" Group="AddMovie" /></div>

