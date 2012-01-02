<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="AddAreaTag.aspx.cs" Inherits="IdentityStuff.Views.Moderate.AddAreaTag" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">
<h1>Add new Area Tag</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>IMPORTANT</b></span>: Please double check the complete list of area tags to make sure you are not adding a duplicate
</div>

<table style="width:90%">
    <tr>
        <th colspan="2">Enter area tag details</th>
    </tr>
    <tr>
        <td style="width:100px">Country </td>
        <td><DDL:NationalityDDL ID="NationalityDDLUC" runat="server" Width="200" AllowUK="false" /></td>
    </tr>
    <tr>
        <td style="width:100px">Name 
            <div style="font-size:9px">E.g. 'United Kingdom'</div></td>
        <td>
            <VAM:TextBox ID="NameTxB" runat="server" Width="210" />
            <VAL:FullName ID="NameVAL" runat="server" TargetID="NameTxB" FieldName="Place name" Group="AddPlace" Maximum="150" />
         </td>
    </tr> 
    <tr>
        <td style="width:100px">Paragraph name <div style="width:100px"> 
            <div style="font-size:9px">E.g. 'The United Kingdom'</div></td>
        <td>
            <VAM:TextBox ID="ParagraphNameTxB" runat="server" Width="210" />
            <VAL:FullName ID="ParagraphNameVAL" runat="server" TargetID="ParagraphNameTxB" FieldName="Short name" Group="AddPlace" Maximum="150" />
        </td>  
    </tr>

        <tr>
            <td style="width:120px"></td> 
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="CreateAreaTag_Click" Group="AddPlace" CssClass="button" />
                <%= Html.ActionLink<ModerateController>(c => c.Index(), "Cancel", new { _class = "button" })%>
            </td>
        </tr>           
</table>

</form>

</asp:Content>
