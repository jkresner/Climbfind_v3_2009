<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Google160x600.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.AdUnits.Google160x600" %>


<% if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
   {  
       if (DateTime.Now.Millisecond % 2 == 0)
{  %>      


<script type="text/javascript"><!--
google_ad_client = "pub-8929518485692248";
/* 160x600, created 7/17/08 */
google_ad_slot = "5415897911";
google_ad_width = 160;
google_ad_height = 600;
//-->
</script>
<script type="text/javascript"
src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>

<% }
   else
   { %>

<%--<script type="text/javascript"><!--
amazon_ad_tag = "climbfind-21"; amazon_ad_width = "160"; amazon_ad_height = "600"; amazon_ad_logo = "hide"; amazon_ad_link_target = "new"; amazon_ad_border = "hide"; amazon_color_link = "CB4721"; amazon_color_price = "6B8E23"; amazon_ad_include = "climbing+harness+rope+karabina+shoes+sport+mountaineering+scarpa+mamut+dmm+mountain"; amazon_ad_categories = "k";//--></script>
<script type="text/javascript" src="http://www.assoc-amazon.co.uk/s/ads.js"></script>
--%>
<% } } else {
%>
<div style="color:Blue;text-decoration:underline;text-align:center;vertical-align:middle;width:160px;height:600px;border:dashed 1px gray">

Google ads 160x600

</div>

<% 
   }%>
   
  