<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="AllWhatILike.aspx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.AllWhatILike" %>
<%@ Register TagPrefix="cf" TagName="AllProfiles" Src="~/Views/ClimberProfiles/AllCache.ascx" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">
  
<% int i = 0; foreach (ClimberProfileExtended ep in AllLikeExtendedProfiles)
   { %>
    <div><%= i++ %>) <a href="/climber-profile/<%= ep.ID %>">XX</a>: <%= ep.LikeAboutClimbfind%></div>
<% } %>

</asp:Content>
