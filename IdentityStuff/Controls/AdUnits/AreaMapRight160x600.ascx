﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreaMapRight160x600.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.AdUnits.AreaMapRight160x600" %>
<% if (DateTime.Now.Millisecond % 2 == 0)
{  
   if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
   {  %>      
<script type="text/javascript"><!--
google_ad_client = "pub-8929518485692248";
/* 160x600, created 7/17/08 */
google_ad_slot = "5415897911";google_ad_width = 160;google_ad_height = 600;
//-->
</script><script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
<% } else { %><div style="color:Blue;text-decoration:underline;text-align:center;vertical-align:middle;width:160px;height:600px;border:dashed 1px gray">Google ads 160x600</div><% } %>
<% }
   else
   { %>
<% if (Area.CountryID == (short)Nation.Canada)
   { %>
<%= CFAdControls.Ad("AreaMap.Right", 24)%>
 <% }
   else if (Area.CountryID == (short)Nation.England)
   { %>
 <%= CFAdControls.Ad("AreaMap.Right", 33)%>

    <% } else { %>
<%= CFAdControls.Ad("Home.TopRight", 31)%>
    <% } %>
<% } %>
   
 