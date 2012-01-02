<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Promote.aspx.cs" Inherits="IdentityStuff.Views.Home.Promote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<h1>Promote Climbfind</h1>

<%= BodyHTML %>

<p>We were touched that so many people asked how they could help promote Climbfind, so this page lists ways in which you can help.</p>

<p style="margin-top:20px">1) <b>Link to us</b> by including this html code on your website:</p>

<blockquote style="font-size:9px;padding:15px">

<%= Html.Encode("<table><tr><td><a href=\"http://cf3.climbfind.com\"><img src=\"http://cf3.climbfind.com/images/climbing-partner.png\" alt=\"Find rock climbing partners on Climbfind\" title=\"Indoor climbing\" /></a></td><td><p title=\"Find climbing partners, indoor climbing partner\">Looking for climbing friends? <a href=\"http://cf3.climbfind.com/\" title=\"Climbfind indoor rock climbing partners, indoor rock climbing gyms, outdoor climbing partner\">www.climbfind.com</a> helps you meet climbers at your local indoor climbing centre, find places to climb outdoors and share your passion for rock climbing.</p></td></tr></table>")%>

</blockquote>

<p>The code should render on your website looking something like this: </p>

<div style="margin:auto;width:80%;padding:6px;font-weight:bold" class="attentionDIV">
    <table class="NoStylesTable" border="0"><tr><td><a href="http://cf3.climbfind.com"><img src="http://cf3.climbfind.com/images/climbing-partner.png" alt="Find rock climbing partners on Climbfind" title="Indoor climbing" /></a></td><td><p style="margin:0px 0px 0px 10px" title="Find climbing partners, indoor climbing partner">Looking for climbing friends? <a href="http://cf3.climbfind.com/" title="Climbfind indoor rock climbing partners, indoor rock climbing gyms, outdoor climbing partner">www.climbfind.com</a> helps you meet climbers at your local indoor climbing centre, find places to climb outdoors and share your passion for rock climbing.</p></td></tr></table> 
</div>


<p style="margin-top:20px">2) <b>Follow us on Facebook and Twitter</b></p>

<ul>
    <li><img src="/images/site-partners/fbfavicon.jpg" /> <a href="http://www.facebook.com/addfriend.php?id=1511067549" target="_blank">Friend Climbfind</a></li>
    <li><img src="/images/site-partners/fbfavicon.jpg" /> Become a member on the <a href="http://en-gb.facebook.com/pages/Climbfind/40120560277" target="_blank">Climbfind fan page</a></li>
    <li><img src="/images/site-partners/fbfavicon.jpg" /> Join the <a href="http://en-gb.facebook.com/event.php?eid=70404927091&ref=mf" target="_blank">Climbfind 2009 Roadtrip event</a></li>
    <li><img src="/images/site-partners/twitterfavicon.jpg" /> Follow <a href="http://twitter.com/climbfind">Climbfind on Twitter</a></li>
</ul>

<p style="margin-top:20px">3) <b><a href="/images/specialpages/CFPartnersPoster.jpg">Download our poster</a>, print it off and stick it up at your climbing centre's notice board:</b></p>



<img src="/images/news/Climbfind-Partners-Poster-01-Thumbnail.jpg"/>


<p style="margin-top:20px">4) <b>Share your passion for climbing across the internet</b><br /><br /> Click these buttons <%= CFControls.AddThisBookmark(this, "http://cf3.climbfind.com/", "Climbfind.com - Find and share your passion for climbing") %> 
to spread Climbfind to your friends on your other favorite websites.</p>


<p style="margin-top:20px">5) <b>Tell your climbing friends</b><br /><br /> Post on forums or facebook groups explaining why you think Climbfind is great and don't forget to include a link back to the site.</p>


<p style="margin-top:20px">6) <b>Paint our logo at your climbing wall!</b></p>

<img src="/images/news/main-feed/AleterRockClimbfindLogo.jpg" />






</asp:Content>
