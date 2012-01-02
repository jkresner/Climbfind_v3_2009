<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreaTagForCountryTxB.ascx.cs" Inherits="IdentityStuff.Views.Moderate.AreaTagForCountryTxB" %>

<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>


<script type="text/javascript">

    $().ready(function() {
        var txb = $("#AreaTxB");
        AddWaterMark(txb, "Type city/state/country");

        txb.autocomplete("/Places/FilterCountryAreaSearch?CID=<%= (short)Country %>", { scroll: false, minChars: 2, width: 300, selectFirst: false,
            formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1]; },
            formatResult: function(data, value) { return value.split(",")[1]; }
        });

        txb.result(function(event, data, formatted) {
            if (data) {
                var aID = data[0].split(",")[2];
                if (aID != -1) {
                    $("#<%= AreaID.ClientID %>").val(aID);
                }
            }
        });
    });
      
    //-- Function to add textbox watermark
    function AddWaterMark(txb, text) {
        txb.focus(function() { $(this).filter(function() { return $(this).val() == "" || $(this).val() == text }).removeClass("TxBWatermark").val(""); });
        txb.blur(function() { $(this).filter(function() { return $(this).val() == "" }).addClass("TxBWatermark").val(text); });
    }

</script>

<input id="AreaTxB" type="text" class="TxBWatermark" value="Type city/state/country" style="width:180px" />
<VAM:IntegerTextBox ID="AreaID" runat="server" style="display:none" AllowNegatives="false" />
<VAM:RequiredTextValidator ID="AreaVAL" runat="server" ControlIDToEvaluate="AreaID" ErrorFormatterSkinID="Selection"
    ErrorMessage="Select a <a href='/Places' target='_blank'><b>valid area</b></a>" />  
<asp:HiddenField ID="CID" runat="server" Visible="false" />