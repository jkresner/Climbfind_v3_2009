<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClimbFind.Web.Mvc.Login" MasterPageFile="~/Views/Shared/cf.master" %>
<%@ Register TagName="SiteAffiliates" TagPrefix="cf" Src="~/Views/Home/IndexSiteAffiliates.ascx" %>


<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<div style="width:70%;float:left">

    <h1>Log in</h1>

    <% if (!String.IsNullOrEmpty(LoginReason)) { %><p><b><%= Html.Encode(LoginReason) %></b></p><% } %>

    <form runat="server">
      
        <cf:LoginOrRegister ID="LoginOrRegisterUC" runat="server" />

    </form>

</div>

<div style="width:25%;float:right">

    <h1>New to Climbfind?</h1>

    <p>Not yet a member?</p>
    <p style="font-size:16px"><b>> <a href="/Join">Join climbfind</a></b> now</p>

</div>


<div style="clear:both;padding-top:30px">
<cf:SiteAffiliates id="Affiliates" runat="server" /> 
</div>

</asp:Content>