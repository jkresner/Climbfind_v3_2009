<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.NewPost" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:660px;float:left">

<script type="text/javascript" src="/js/ui.datepicker.js"></script>
<script type="text/javascript">  $(document).ready(function() { 
var dtxt = $("#<%= DateTxB.ClientID %>");dtxt.datepicker({ constrainInput: true, minDate: new Date(<%= DateTime.Now.Year %>, 1 - 1, 1), altFormat: 'dd MM yy', altField: '#<%= DateTxB.ClientID %>',  onClose: function(dateText, inst) {  dtxt.removeAttr("disabled"); } });dtxt.bind('mouseenter', function() { dtxt.datepicker('show'); dtxt.attr("disabled", "disabled"); });
}); </script>
   
    <script type="text/javascript">
        $(document).ready(function() {
            SelectTagGroup("Climbing");
            $("#TagInputs input").change(function() {
                $("#<%= TagIDHD.ClientID %>").val($(this).val());
            });

        });

        function SelectTagGroup(group) {
            HideAllTagGroups();
            if (group == 'Climbing') { $("#ClimbingTags").show(); $("#ClimbingA").attr("style", "font-weight:bold"); }
            if (group == 'Logistics') { $("#LogisticsTags").show(); $("#LogisticsA").attr("style", "font-weight:bold"); }
            if (group == 'News') { $("#NewsTags").show(); $("#NewsA").attr("style", "font-weight:bold"); }
            if (group == 'None') { $("#NoTag").show(); $("#NoneA").attr("style", "font-weight:bold"); $("#<%= TagIDHD.ClientID %>").val('0'); }
        }

        function HideAllTagGroups() {
            $("#ClimbingTags").hide();
            $("#LogisticsTags").hide();
            $("#NewsTags").hide();
            $("#NoTag").hide();
            $("#ClimbingA").removeAttr("style");
            $("#LogisticsA").removeAttr("style");
            $("#NewsA").removeAttr("style");
            $("#NoneA").removeAttr("style");
        }           
            </script>
        

<h1>Post for <%= place.Name %></h1>    

<form runat="server">

<input id="placeID" name="placeID" value="<%= place.ID %>" type="hidden" />

<div class="inputForm">

<p class="formTip" style="text-align:center;width:150px">
   <b><%= place.ShortName %></b>
   <img src="<%= place.PrimaryImageUrl %>" style="margin:5px auto 5px auto;width:120px" />
</p>


<label>Date <i style="font-size:10px;"> &nbsp(for a non-date specific shout out, try <%= Html.ActionLink<PartnerCallsController>(c=>c.New(), "post a partner call") %>)</i></label>
<div id="DatePickerTD">
    <VAM:TextBox ID="DateTxB" runat="server" />
    <VAM:RequiredTextValidator ID="DateVALl" runat="server" ControlIDToEvaluate="DateTxB" ErrorMessage="Date is required. Choose today if you are not sure." ErrorFormatterSkinID="Default" runat="server" />
</div>

<label>Tag <i style="font-size:10px">&nbsp Not sure which to use? See </i><%= Html.ActionLink<CFFeedController>(c => c.AboutFeedTags(), "tag explanations", new { target = "_blank", style= "font-weight:normal" } )%></label>
<div style="width:55px;float:left;font-size:9px;margin:0px 10px 10px 0px">
    <div style="border-bottom:1px solid gray;color:Black">Categories</div>
    <a id="ClimbingA" href="javascript:SelectTagGroup('Climbing');">Climbing</a>
    <a id="LogisticsA" href="javascript:SelectTagGroup('Logistics');">Logistics</a>
    <a id="NewsA" href="javascript:SelectTagGroup('News');">News</a>
    <br /><a id="NoneA" href="javascript:SelectTagGroup('None');">No tag</a>
</div>
<div id="TagInputs" style="float:left">
    <div id="ClimbingTags"><%= GetTagsFor("Climbing") %></div>
    <div id="LogisticsTags"><%= GetTagsFor("Logistics")%></div>
    <div id="NewsTags"><%= GetTagsFor("News")%></div>
    <div id="NoTag">No tag</div>
</div>

<asp:HiddenField ID="TagIDHD" runat="server" Value="0" />

<div style="width:71%">
<label>Message <cf:CharacterCount ID="MessageCount" runat="server" TargetID="MessageTxB" /></label>
</div>
<asp:TextBox id="MessageTxB" runat="server" TextMode="MultiLine" Width="70%" Height="80px" />
<div style="width:2px;float:left"><VAL:Message ID="MessageVAL" FieldName="Message" Minimum="5" Maximum="255" TargetID="MessageTxB" runat="server" />
</div>

<hr />
<VAM:LinkButton ID="PostBtN" Text="Post" CssClass="superButton" OnClick="SavePost_Click" runat="server" />
<hr />

</div>


</form>
</div>


<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
</div>


</asp:Content>


