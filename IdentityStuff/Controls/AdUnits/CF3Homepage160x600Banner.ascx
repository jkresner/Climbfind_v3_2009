<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CF3Homepage160x600Banner.ascx.cs" Inherits="IdentityStuff.Controls.AdUnits.CF3Homepage160x600Banner" %>

<div style="float:right;width:161px;margin:0px 0px 10px 5px">
<% if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment) { %>      
<script type="text/javascript"><!--
google_ad_client = "pub-8929518485692248";
/* 160x600, created 7/22/09 */
google_ad_slot = "3087131999";
google_ad_width = 160;
google_ad_height = 600;
//--></script><script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
<% } else { %>
<div style="color:Blue;text-decoration:underline;text-align:center;vertical-align:middle;width:160px;height:600px;border:dashed 1px gray">
Google ads 160x600
</div>
<% } %>
</div>

<div style="float:right;width:160px">
    <% if (CurrentCountry == Nation.Canada) { %><%= CFAdControls.Ad("AreaMap.Right", 24)%>
    <% } else if (DateTime.Now.Millisecond % 2 == 0) { %><%= CFAdControls.Ad("Home.TopRight", 31)%>
    <% } else { %><%= CFAdControls.Ad("Home.TopRight", 32)%><% } %>    
</div>  

