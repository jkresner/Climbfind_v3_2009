<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="NewPostPlace.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.NewPostPlace" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<script type="text/javascript">

    $(document).ready(function() {
    var txb = $("#PlaceClimbingTxB");
    AddWaterMark(txb, "Type name of place", "PlaceClimbingTxBWaterMark");

    txb.autocomplete("/Places/FilterSearch", { scroll: false, minChars: 2, selectFirst: false,
        formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1] + "; " + value.split(",")[2]; },
        formatResult: function(data, value) { return value.split(",")[2]; }
    });

    txb.result(function(event, data, formatted) {
        if (data) {
            if (data[0].split(",")[3] != -1) {
                $("#placeID").val(data[0].split(",")[3]); document.forms[1].submit();
            }
        }
    });

    $('#AddLink').boxy();});

</script>
<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>
<script type='text/javascript' src='/js/jquery.boxy.js'></script>
<link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />


<div style="width:660px;float:left">


<h1>Post to the climbing feed</h1>

<p>There are 3 types of feed posts, please choose:</p>

<ul style="margin:0px 0px 20px 0px">
    <li>1) If you want to submit a climbing clip => <b><%= Html.ActionLink<MediaController>(c=>c.SubmitMovie(), "post a movie") %></b></li>
    <li>2) If you <b>don't have a date</b> in mind & you're generally looking for partners => <b><%= Html.ActionLink<PartnerCallsController>(c => c.New(), "post a partner call")%></b></li>
    <li>3) For everything else, including looking for a partner for specific date/time => enter the name of the place you're interested in the textbox</li>
</ul>


<div style="width:435px">

<p id="ClimbingNextP">Where did / are you climbing?</p>
<p id="NotShowingP">Place not showing? <a id="AddLink" href="#AddPlaceModal" title="Add a place to Climbfind">Add to Climbfind</a></p>
<input id="PlaceClimbingTxB" type="text" class="PlaceClimbingTxBWaterMark" value="Type name of place" />
<form action="/CFFeed/NewPost" method="post"><input type="hidden" name="placeID" id="placeID" /></form>

<div id="AddPlaceModal" style="display:none">
<p>What type of place do you want to add?</p>
<p>> <a href='/Moderate/AddOutdoorLocation'>Add outdoor climbing</a></p>
<p>> <a href='/Moderate/AddIndoorPlace'>Add indoor climbing</a></p>
</div></div>

</div>

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
</div>


</asp:Content>
