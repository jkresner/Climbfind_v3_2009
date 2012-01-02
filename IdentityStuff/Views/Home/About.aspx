<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="IdentityStuff.Views.Home.About" %>
<%@ Register TagName="IndexNewsFeed" TagPrefix="cf" Src="~/Views/Home/IndexNewsFeed.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<style type="text/css">
 p { margin:0px 0px 10px 10px }
 ul { margin:15px 0px 20px 10px }
 .FullScreen { font-size:9px }
</style>

<div class="vPageSecionTop">



<div style="width:74%;float:left">


<h1>About, Introduction & Helper Videos</h1>

<dl class="Video">
    <dd style="width:98%">
        <span>1) Intro to Climbfind : The Concept & Website</span>
        <p>This is a 110 second introduction to the main concepts and benifits of Climbfind, which are:</p>
        <ul style="font-size:10px"><li>1) Knowing where there's climbing around you, where ever you are in the world</li>
        <li>2) Finding people to climb with at any single climbing location as late as hours before you want to climb</li></ul>
        
    </dd>
    <dt>
    
    <object width="640" height="498"> <param name="movie" value="http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/flvplayer.swf"></param> <param name="quality" value="high"></param> <param name="bgcolor" value="#FFFFFF"></param> <param name="flashVars" value="thumb=http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/FirstFrame.jpg&containerwidth=640&containerheight=498&content=http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/Climbfind3.5Intro.mp4"></param> <param name="allowFullScreen" value="true"></param> <param name="scale" value="showall"></param> <param name="allowScriptAccess" value="always"></param> <param name="base" value="http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/"></param>  <embed src="http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/flvplayer.swf" quality="high" bgcolor="#FFFFFF" width="640" height="498" type="application/x-shockwave-flash" allowScriptAccess="always" flashVars="thumb=http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/FirstFrame.jpg&containerwidth=640&containerheight=498&content=http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/Climbfind3.5Intro.mp4" allowFullScreen="true" base="http://content.screencast.com/users/climbfind/folders/Default/media/8ae13ae1-163c-480d-a0d4-80e62b21260d/" scale="showall"></embed> </object>
    
    </dt>
<hr /></dl>

<%--<dl class="Video">
    <dd><span>2) Use the 'Climbing feed' to find partners & much more</span>
        <p>This short video demonstrates how to post to the homepage feed, then use the feed channels and
            views to get to know who climbs where you climb, find partners, organise lifts and much more...</p>
    </dd>
    <dt>
        <div style="width:480px;height:385px;border:dotted 1px gray"><p style="text-align:center;margin:140px auto 0px auto"><b>Movie coming next week...</b></p></div>
    </dt>
<hr /></dl>--%>




</div>



<div id="ShareActions" style="width:20%;float:right;margin:0px 20px 0px 0px">

<h1>Share the passion</h1>

<%--<p>
    <i>Become fans of</i><br /> <img style="padding: 0pt;border:none" src="/images/site-partners/fbfavicon.jpg"/>
    <a href="http://www.facebook.com/pages/Climbfind/40120560277" target="_blank"><b>Climbfind on facebook</b></a>
</p>
    
<p><i>Follow</i> <br /><img style="padding: 0pt;border:none" src="/images/site-partners/twitterfavicon.jpg"/>
    <a href="http://twitter.com/climbfind"><b>Climbfind on Twitter</b></a></p>  

<p><i>Share Climbfind with friends</i>
    <br /><%= CFControls.AddThisBookmark(this, "/About", "Climbfind - the worlds first truly global climber's social network") %>
</p>

<p><i>Stumble Climbfind</i>
<br />
<a href="http://www.stumbleupon.com/submit?url=http%3A%2F%2Fwww.climbfind.com%2FAbout%26title%3DAbout%2BClimbfind"> <img border=0 src="http://cdn.stumble-upon.com/images/120x20_su_gray.gif" alt=""></a>
</p>

<p style="float:left"><i>Tweet this page</i>
   <br /> <a href="http://twitter.com/home?status=I recommend looking at www.climbfind.com version 3 - It's awesome http://www.climbfind.com/About" title="Tweet this" target="_blank"><img src="/images/ui/tweetthis.jpg" title="Tweet this page" /></a></p>

<p style="float:left;margin:0px 0px 0px 20px"><i>Digg this</i><br />
<script type="text/javascript">    digg_url = 'http://digg.com/extreme_sports/Climbfind_com_Find_and_share_your_passion_for_climbing'; </script><script src="http://digg.com/tools/diggthis.js" type="text/javascript"></script></p>
--%>

    <div id="News" style="clear:both;padding:10px 0px 0px 0px">
        <cf:IndexNewsFeed ID="SiteNewsUC" runat="server" />         
    </div>

</div>




</div>




    
</asp:Content>
