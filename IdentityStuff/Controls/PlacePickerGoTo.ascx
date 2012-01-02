<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlacePickerGoTo.ascx.cs" Inherits="IdentityStuff.Controls.PlacePickerGoTo" %>


<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>


<script type="text/javascript">

    $().ready(function() {

        var placeTxB = $("#<%= PlacesTxB.ClientID %>");

        placeTxB.autocomplete("/Places/FilterGoTo", {
            scroll: false,
            minChars: 2,
            width: 300,
            selectFirst: false,
            formatItem: function(data, i, n, value) { return value; },
            formatResult: function(data, value) { return value; }
        });

        function cancelValue() {
            placeTxB.removeClass('successSelectTxB');
            placeTxB.unbind("change", cancelValue);
        }

        placeTxB.result(function(event, data, formatted) {
            if (data) {
                placeTxB.addClass('successSelectTxB');
                placeTxB.bind("change", cancelValue);
            }
        });

    });

</script>
	
<VAM:TextBox ID="PlacesTxB" runat="server" Width="300" ValueWhenBlank="Type to select place" />
