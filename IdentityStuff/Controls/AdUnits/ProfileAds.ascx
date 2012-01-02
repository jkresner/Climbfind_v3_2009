<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileAds.ascx.cs" Inherits="IdentityStuff.Controls.AdUnits.ProfileAds" %>
<% if (DateTime.Now.Millisecond % 2 == 0) {
   if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
   { %>      
<script type="text/javascript"><!--
google_ad_client = "pub-8929518485692248";
/* 160x600, created 7/17/08 */
google_ad_slot = "5415897911";
google_ad_width = 160;
google_ad_height = 600;
//-->
</script>
<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
<% } else { %>
<div style="color:Blue;text-decoration:underline;text-align:center;vertical-align:middle;width:160px;height:600px;border:dashed 1px gray">Google ads 160x600</div>
<% } } else {
%><%= CFAdControls.Ad("InputForm.Right", 36) %><% }%>