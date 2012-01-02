<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="IdentityStuff.Views.Media.Detail" %>


<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<div class="vPageSectionTop">
    <h1><%= Media.Name %></h1>

    <dl class="Video">
        <dd><span><%= Media.Name %></span>
                <p>Submitted  <%= Media.SubmittedDateTime.ToString("dd MMM yy") %> by 
                <%= CFControls.ClimberProfileLink(this, ClimbFind.Model.DataAccess.CFDataCache.GetClimberFromCache(Media.SubmittedByUserID)) %></p>
                <p><%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), Media.Name + " - Climbfind climbing " + Media.MediaTypeString) %></p>
          <p><%= Media.Description %></p></dd>
        <dt><%= Media.RenderInBrowser() %></dt><hr />
    </dl><div class="VideosEnd"></div>

</div>


<div class="vPageSection">
    <form id="Form1" runat="server">

    <asp:ScriptManager ID="ScripManagerUD" runat="server" />
    <cf:MessageBoard ID="MessageBoardUC" runat="server" Heading="Comments" />

    </form>
</div>

</asp:Content>
