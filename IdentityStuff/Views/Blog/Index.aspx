<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Blogs.Index" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<iframe id="CFBlogFrame" src="http://cf3.climbfind.com/Blogfiles/blog.html" 
    width="100%" frameborder="0" scrolling="no" style="margin-top:-20px;height:12000px">
</iframe>

</asp:Content>


<%-- NOTE THIS FUNCTION ONLY WORKS ON THE ACTUAL DOMAIN www.climbfind.com --%>