<%@ Page Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="True" CodeBehind="IndexAuthenticated.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Home.IndexAuthenticated" %>
<%@ Register TagName="PlaceGoingClimbingTxB" TagPrefix="cf" Src="~/Views/CFFeed/PlaceGoingClimbingTxB.ascx" %>
<%@ Register TagName="IndexSiteAffiliates" TagPrefix="cf" Src="~/Views/Home/IndexSiteAffiliates.ascx" %>
<%@ Register TagName="CFFeed" TagPrefix="cf" Src="~/Views/CFFeed/Feed.ascx" %>
<%@ Register TagName="IndexBlogFeed" TagPrefix="cf" Src="~/Views/Home/IndexBlogFeed.ascx" %>
<%@ Register TagName="CF3Homepage160x600Banner" TagPrefix="cf" Src="~/Controls/AdUnits/CF3Homepage160x600Banner.ascx" %>
<%@ Register TagName="Tooos" TagPrefix="cf" Src="~/Views/Home/IndexToDo.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div id="Feed">

    <h1>Climbing feed</h1>    

    <cf:CFFeed id="FeedUC" runat="server" />        
           
</div>    

<div style="width:326px;float:right">  
    
    <div>
        <h1>Post to the feed</h1>
        <cf:PlaceGoingClimbingTxB ID="PostToFeedTxB" runat="server" />
        
    </div>
    
    <div id="NextItems">
        <cf:Tooos ID="TodosUC" runat="server" />         
    </div>
    
    <div style="clear:both;padding:5px 0px 0px 0px">
        <cf:CF3Homepage160x600Banner id="Banner160x600UC" runat="server" />                                                
    </div>

    <hr />

    <div id="FeaturedProducts">
 
        <h1>Featured content</h1> 
                
        <div style="margin:20px 0px 15px 0px">
            <%= CFAdControls.Ad("Home.UnderPartnerFeed", 3) %>
        </div>

    </div>

    <div id="Blogs">
        <cf:IndexBlogFeed ID="IndexBlogFeedUC" runat="server" NumberPerUser="1" />         
    </div>

   <cf:IndexSiteAffiliates id="IndexSiteAffiliatesUC" runat="server" />           


</div>             



                    

</asp:Content>



