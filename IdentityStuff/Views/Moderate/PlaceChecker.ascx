<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlaceChecker.ascx.cs" Inherits="IdentityStuff.Views.Moderate.PlaceChecker" %>


<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>


<script type="text/javascript">

    $().ready(function() {

        var placeTxB = $("#<%= PlacesTxB.ClientID %>");
        var resultHD = $("#<%= ResultsHD.ClientID %>");
        var GoToSpan = $("#GoToSpan");

        placeTxB.autocomplete("<%= SearchService %>", {
            scroll: false,
            minChars: 2,
            width: 300,
            selectFirst: false,
            formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1] + "; " + value.split(",")[2]; },
            formatResult: function(data, value) { return value.split(",")[2] + " (Already in system)"; }
        });

        function cancelValue() {
            placeTxB.removeClass('alertSelectTxB');
            placeTxB.unbind("change", cancelValue);
            resultHD.val('');
            GoToSpan.hide();
        }

        placeTxB.result(function(event, data, formatted) {
            if (data) {
                placeTxB.addClass('alertSelectTxB');
                placeTxB.bind("change", cancelValue);
                resultHD.val(data[0].split(",")[3]);
                document.getElementById('PlaceNameLb').innerHTML = data[0].split(",")[2];
                GoToSpan.show();
            }
        });

    });

</script>

	
<VAM:TextBox ID="PlacesTxB" runat="server" Width="300" ValueWhenBlank="Type name to check place" />
<input id="ResultsHD"  type="hidden" runat="server" />
<div id="GoToSpan" style="display:none;clear:both;padding:15px">
    <b style="color:Red"><span id="PlaceNameLb"></span> is already on Climbfind.</b> 
    Please open <b><asp:LinkButton ID="GoToFoundPlaceLkB" runat="server" Text="the place page" OnClick="GoToPlacePage_Click" /></b> 
    and check if it is plotted correctly on our world map and has all the appropriate area tags.
</div>

