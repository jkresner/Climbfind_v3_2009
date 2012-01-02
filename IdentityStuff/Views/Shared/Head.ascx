<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Head.ascx.cs" Inherits="IdentityStuff.Views.Shared.Head" %>
<%--<% if (this.Request.Url.ToString().Substring(0, 20) == "http://climbfind.com")
   {
        Response.Status = "301 Moved Permanently";
        Response.AddHeader("Location", this.Request.Url.ToString().Replace("http://climbfind.com", "http://www.climbfind.com"));
        Response.End();
} %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%= ViewData["PageTitle"] %></title>
    <meta name="description" content="<%= ViewData["PageDescription"] %>" />
    <meta name="keywords" content="<%= ViewData["PageKeywords"] %>" />
    <meta name="robots" content="noindex,nofollow" />    
    <link rel="stylesheet" type="text/css" href="/css/cf3.53.css" />  
    <link rel="icon" href="/favicon.ico" />
</head>