<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="CommentOnPost.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.CommentOnPost" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<div style="float:right;width:160px">
    <Ad:InputFormRight160x600  id="AdUnit160x600UC" runat="server" />                           
    <% if (post.Comments.Count > 4) { %>
        <br /><br /><Ad:Google160x600 ID="GoogleAds" runat="server" />
    <% } %>
</div>  

<style type="text/css">
     #Thread { float:left;width:700px }
     #ThreadPost { margin:0px 0px 10px 0px }
     .ThreadReply img { border:none;padding:0;margin:5px 0px 0px 0px }
     .ThreadReply { clear:both }
     .ThreadReply dt { clear:left;float:left;margin:15px 10px 0px 0px;border-top:solid 1px #D3D3D3;width:100px}
     .ThreadReply dd { float:left;margin:15px 0px 0px 0px;border-top:solid 1px  #D3D3D3;width:550px }
     .ThreadReply span { float:right; }
     #ThreadComment {  height:136px;width:650px;border-top:solid 1px gray;background:#FAFAD2 }
</style>

<div style="float:left;width:690px">

<h1>Comments on <%= post.User.FullName %>'s post</h1>


<form runat="server">

<asp:ScriptManager ID="ScriptManager" runat="server" />

<asp:UpdatePanel ID="UP" runat="server">
    <ContentTemplate>
    
    
<div class="vPageSecionTop" style="width:99%">
    

<div id="Thread">

<div id="TheadPost">
    <%= Html.ImagePreview(post.User.ProfilePictureUrlMini, post.User.ProfilePictureUrlFull, post.User.FullName)%>
    <div style="width:550px;float:left">
        <b><%= CFControls.ClimberProfileLink(this, post.User) %></b>
        <span><%= post.PostedDateTime.GetAgoString()%></span>
        <label><%= GetTagsString(post.TagID) %>, <%= post.ClimbingDateTime.ToString("ddd dd MMM")%></i> @ <%= GetPlaceLink(post.PlaceID)%></label>
        <p><%= post.Message.GetHtmlParagraph() %></p>
    </div>
</div>

<% foreach (FeedPostComment c in post.Comments){ %>
<div class="ThreadReply">    
    <dt><%= Html.ImagePreview(GetProfile(c.UserID).ProfilePictureUrlMini, GetProfile(c.UserID).ProfilePictureUrlFull, GetProfile(c.UserID).FullName)%></dt>
    <dd>    <% if (c.UserID == UserID) { %><span><a href="/CFFeed/DeletePostComment/<%= c.ID %>">delete</a></span><% } %>
    <a rel="nofollow" href="/climber-profile/<%= c.UserID %>">
    <%= GetProfile(c.UserID).FullName %></a> <i><%= c.PostedDateTime.GetAgoString() %></i>
    <p> <%= c.Message.GetHtmlParagraph() %></p></dd>
</div><% } %>

<hr />
<div class="inputForm" style="width:93%">

    <label>Leave your comment</label>

    <hr />
    <img src="<%= GetProfile(UserID).ProfilePictureUrlMini %>" style="margin:5px 5px 0px 0px;float:left" />

    <div style="float:left;margin:5px 0px 0px 0px;width:400px">

    <VAM:TextBox id="MessageTxB" runat="server" TextMode="MultiLine" style="width:98%;height:90px;clear:both" />
    <div style="float:left;width:2px">
        <VAL:Message ID="MessageVAL" TargetID="MessageTxB" FieldName="Reply message" runat="server" />                             
    </div>
     
    <hr />

        <VAM:LinkButton ID="CommentBtn" runat="server" Text="Comment" style="margin:3px 0px 0px 0px"
            CssClass="superButton" OnClick="Comment_Click" />

     </div>   
        
    <hr /> 
</div>

</div>


</div>

</ContentTemplate>
</asp:UpdatePanel>

</form>

</div>

</asp:Content>
