<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Register TagName="IndexBlogFeed" TagPrefix="cf" Src="~/Views/Home/IndexBlogFeed.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:660px;float:left">
    <cf:IndexBlogFeed ID="BlogFeedUC" runat="Server" NumberPerUser="4" />
</div>     

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <%= CFAdControls.Ad("Home.TopRight", 31)%>
    <br />
    <%= CFAdControls.Ad("PublicHome.ClimbingDeals", 26)%>
    <br />
    <%= CFAdControls.Ad("AreaMap.Right", 25)%>
</div>

</asp:Content>
