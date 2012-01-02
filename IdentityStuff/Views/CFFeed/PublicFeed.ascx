<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublicFeed.ascx.cs" Inherits="IdentityStuff.Views.CFFeed.PublicFeed" %>
<%@ OutputCache Duration="300" VaryByParam="None" %>
<link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />
<script type='text/javascript' src='/js/jquery.boxy.js'></script>
<script type="text/javascript">
    $().ready(function() {
        $(".hExp").hide();
        $(".homeBoxy").boxy({ modal: true });
        $("#EnglandChannel").hide();
    });

    function ShowEnglandChannel() {
        $("#EnglandLink").addClass("CurrentFilter");
        $("#AllLink").removeClass("CurrentFilter");
        $("#AllChannel").hide();
        $("#EnglandChannel").show();

    }

    function ShowAllChannel() {
        $("#EnglandLink").removeClass("CurrentFilter");
        $("#AllLink").addClass("CurrentFilter");
        $("#AllChannel").show();
        $("#EnglandChannel").hide();
    }
</script>   
           
<dl id="FeedFilters">
    <dd>Channel</dd> 
    <dt>[<a id="AllLink" href="javascript:ShowAllChannel()" class="CurrentFilter">All</a>]</dt>
<%--    <dt>[<a href="#ClimbersExp" class="homeBoxy" title="The Climbers Channel">Climbers</a>]</dt>--%>
    <dt>[<a href="#PlaceExp" class="homeBoxy" title="The Place Channel"><i>Place</i></a>]</dt>
    <dt>[<a href="#AreaExp" class="homeBoxy" title="The Area Channel"><i>Area</i></a>|<a id="EnglandLink" href="javascript:ShowEnglandChannel()">England</a>]</dt>
</dl> 
<hr />
<div class="attentionDIV" style="margin:5px 9px 0px 4px;text-align:right">> Get started! <a href="/CFFeed/NewPost"><b>Post to the Climbing feed</b></a> now</div>
  
<div id="AllChannel">
<ul id="FeedItems">
<% foreach (ClimbFind.Model.Objects.Interfaces.IFeedItem item in AllChannelFeedItems) { %>
    <li>        
        <%= Html.ImagePreview(item.User.ProfilePictureUrlMini, item.User.ProfilePictureUrl, item.User.FullName)%>       
        <div><b><%= CFControls.ClimberProfileLink(this, item.User) %></b><span><%= item.PostedDateTime.GetAgoString()%></span><%= item.RenderHTMLPostTopDetails() %></div>
        <%= item.RenderHTMLPostBody() %>
        <% if (item.Comments.Count > 0) { %><dl><% foreach (FeedPostComment c in item.Comments) { %>
            <dt>
            <%= Html.ImagePreview(c.User.ProfilePictureUrlMini, c.User.ProfilePictureUrl, c.User.FullName)%>
            </dt><dd><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %><% } %></dd>
        </dl><% } %><hr />
    </li><% } %>   
</ul> 
</div>
<div id="EnglandChannel">
<ul id="FeedItems">
<% foreach (ClimbFind.Model.Objects.Interfaces.IFeedItem item in EnglandChannelFeedItems) { %>
    <li>        
        <%= Html.ImagePreview(item.User.ProfilePictureUrlMini, item.User.ProfilePictureUrl, item.User.FullName)%>       
        <div><b><%= CFControls.ClimberProfileLink(this, item.User) %></b><span><%= item.PostedDateTime.GetAgoString()%></span><%= item.RenderHTMLPostTopDetails() %></div>
        <%= item.RenderHTMLPostBody() %>
        <% if (item.Comments.Count > 0) { %><dl><% foreach (FeedPostComment c in item.Comments) { %>
            <dt><img src="<%= c.UserProfileImgUrl %>" /></dt><dd><%= CFControls.ClimberProfileLink(this, c.User) %> - <%= c.Message %><%  } %></dd>
        </dl><% } %><hr />
    </li><% } %>   
</ul> 
</div>
  
<div id="AreaExp" class="hExp">
    <p>The <i>area channel</i> lets you filter the feed to any country, state or city</p>
    <p><b>Try it:</b> Close this window and click "England", then to return to viewing all posts click "All".</p>
    <p><b><a href="/Login">Login</a></b> now or <b><a href="/Join">create a Climbfind account</a></b>
    to start using the feed for areas other than "England".</p>
</div> 
<%--<div id="ClimbersExp" class="hExp">
    <p>The <i>climbers channel</i> tells you where friends and famous climbers are climbing.</p>
    <p>To start adding climbers to your personal climbers channel 
    <b><a href="/Login">login</a></b> or <b><a href="/Join">create a Climbfind account</a></b>.</p>
</div> --%>
<div id="PlaceExp" class="hExp">
    <p>The <i>place channel</i> lets you filter the climbing feed to any indoor or outdoor place on our 
    <a href="/world-climbing-map" target="_blank">world climbing map</a>.</p>
    <p>If you want to filter the feed by place you need to 
    <b><a href="/Login">login</a></b> or <b><a href="/Join">create a Climbfind account</a></b>.</p>
</div> 
