<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlaceGoingClimbingTxB.ascx.cs" Inherits="IdentityStuff.Views.CFFeed.PlaceGoingClimbingTxB" %>

<script type="text/javascript" src="/js/CF3.52Home.js"></script>
<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>
<script type='text/javascript' src='/js/jquery.boxy.js'></script>

<link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />

<p id="ClimbingNextP">Where did / are you climbing?</p>
<input id="PlaceClimbingTxB" type="text" class="PlaceClimbingTxBWaterMark" value="Type place name to post to feed" />
<p id="NotShowingP">Place not showing? <a id="AddLink" href="#AddPlaceModal" title="Add a place to Climbfind">Add to Climbfind</a></p>
<form action="/CFFeed/NewPost" method="post"><input type="hidden" name="placeID" id="placeID" /></form>

<div id="AddPlaceModal" style="display:none">
<p>What type of place do you want to add?</p>
<p>> <a href='/Moderate/AddOutdoorLocation'>Add outdoor climbing</a></p>
<p>> <a href='/Moderate/AddIndoorPlace'>Add indoor climbing</a></p>
</div>