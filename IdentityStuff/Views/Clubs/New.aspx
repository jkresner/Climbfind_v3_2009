<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="IdentityStuff.Views.Clubs.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
    <h1>Add your club</h1>
    
    <form id="Form1" runat="server">
    
    <table width="98%">
        <tr>
            <th colspan="2">Club details</th>
        </tr>
        <tr>
            <td style="width:100px">Name</td>
            <td><VAM:TextBox ID="NameTxB" runat="server" Width="230" /></td>
        </tr>
        <tr>
            <td style="width:100px">Website</td>
            <td><VAM:TextBox ID="WebsiteTxB" runat="server" Width="230" /></td>
        </tr>
        <tr>
            <td style="width:100px">Contact email</td>
            <td><VAM:TextBox ID="ContactEmailTxB" runat="server" Width="230" /></td>
        </tr>
        <tr>
            <td style="width:100px">Areacode / Postcode / Zip</td>
            <td><VAM:TextBox ID="AreaCodeTxB" runat="server" Width="230" /></td>
        </tr>
        <tr>
            <td style="width:100px">Country</td>
            <td><DDL:NationalityDDL ID="CountryDDL" runat="server" AllowUK="false" /></td>
        </tr>        
        <tr>
            <td style="width:100px">Description</td>
            <td><asp:TextBox id="DescriptionTxB" runat="server" TextMode="MultiLine" Width="96%" Height="60" /></td>
        </tr>
        <tr>
            <td style="width:100px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="AddClub_Click" CssClass="button" />
            </td>
        </tr>          
    </table>

    </form>
    
</div>

</asp:Content>
