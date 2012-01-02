<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Contribute.aspx.cs" Inherits="IdentityStuff.Views.Home.Contribute" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<h1>Contribute to Climbfind
    &nbsp
    <%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), "Contribute to Climbfind")  %>    
</h1>
     
<%= BodyHTML %>


</asp:Content>
