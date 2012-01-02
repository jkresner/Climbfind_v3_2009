<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" AutoEventWireup="true" CodeBehind="EditOutdoorAuthoritySites.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditOutdoorAuthoritySites" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">

<div class="vPageSecionTop">
<h1>Edit outdoor authority sites</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: Edits are logged.
</div>

<asp:ListView ID="AuthoritySitesLV" runat="server" ItemPlaceholderID="SitesPH">
    <EmptyDataTemplate><p><%= place.Name %> does not yet have any authority sites.</p></EmptyDataTemplate>
    <LayoutTemplate><table>
    <tr>
        <th>Site</th>
        <th>Url</th>
        <th>Options</th>
    </tr><asp:PlaceHolder ID="SitesPH" runat="server" /></table></LayoutTemplate>
    <ItemTemplate>
         <tr>
            <td><a href="http://<%# Eval("Url") %>"><%# Eval("Name") %></a></td>
            <td><%# Eval("Url") %></td>
            <td><asp:LinkButton ID="DelLkb" runat="server" OnCommand="RemoveOutdoorAuthoritySite_Click" CommandArgument=<%# Eval("ID") %> Text="Delete" /></td>
        </tr>   
    </ItemTemplate>
</asp:ListView>

</div>

<div class="vPageSection">
<h1>Add a new authority sites</h1>

<p><b>Note</b> before adding an Authority site, please review the latest guidelines on using / adding authority sites on the
CF Moderators forum.</p>

<table>
    <tr>
        <th colspan="2">Site details</th>
    </tr>
    <tr>
        <td>Name</td>
        <td>
            <VAM:TextBox ID="NameTxB" runat="server" Width="300" />
            <VAL:Length ID="NameVAL" runat="server" Minimum="2" Maximum="255" FieldName="Site name" TargetID="NameTxB" />
        </td>
    </tr>
    <tr>
        <td>Address / Url</td>
        <td>            
            <VAM:TextBox ID="UrlTxB" runat="server" Width="400" />
            <VAL:Length ID="UtlVal" runat="server" Minimum="8" Maximum="255" FieldName="Url" TargetID="UrlTxB" /> 
            <br /><b>Note format:</b> "www.sitename.com/" (i.e. no 'http://')
        </td>
    </tr>
    <tr>
        <td></td>
        <td><VAM:LinkButton ID="AddSiteLkB" OnClick="AddOutdoorAuthoritySite_Click" CssClass="button" Text="Save" runat="server" /></td>
    </tr>
</table>
</div>

</form>

</asp:Content>
