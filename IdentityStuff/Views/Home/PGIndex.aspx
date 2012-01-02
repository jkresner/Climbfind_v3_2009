<%@ Page Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="True" CodeBehind="IndexAuthenticated.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Home.IndexAuthenticated" %>
<%@ Register TagName="PlaceGoingClimbingTxB" TagPrefix="cf" Src="~/Views/CFFeed/PlaceGoingClimbingTxB.ascx" %>
<%@ Register TagName="CFFeed" TagPrefix="cf" Src="~/Views/CFFeed/Feed.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div id="Feed">

    <h1>Climbing feed</h1>    

    <cf:CFFeed id="FeedUC" runat="server" />        
           
</div>    

<div>
    <h1>Post to the feed</h1>
    <cf:PlaceGoingClimbingTxB ID="PostToFeedTxB" runat="server" />    
</div>

                    

</asp:Content>



