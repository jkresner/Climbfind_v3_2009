<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="2008-CompetitionTemplate.aspx.cs" Inherits="IdentityStuff.Views.News._2008_12_Alien_Bouldering_Competition" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1><%= Comp.ArticleHeading %> &nbsp
<%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), "Climbfind competition news " + Comp.ArticleHeading)  %>
</h1>

<table class="NoStylesTable">
    <tr>
        <td>
             <img src="<%= ArticleMainPhoto1Url %>" />                
        
        </td>
        <td rowspan="3" style="padding:0px 0px 0px 20px">
            <%= Comp.ArticleTextHtml %>
            <p style="margin-top:20px;font-size:14px">By <%= Comp.ReportedBy %></p>
        </td>
    </tr>
    <tr><td style="padding-top:20px"><img src="<%= ArticleMainPhoto2Url %>" /></td></tr>    
    <tr><td style="padding-top:20px"><img src="<%= ArticleMainPhoto3Url %>" /></td></tr>
</table>

</div>   
    

</asp:Content>
