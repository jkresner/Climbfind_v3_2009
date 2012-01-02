<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditAreaTags.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditAreaTags" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Edit place area tags</h1>


<form runat="server">


<table style="width:95%">
    <tr>
        <th colspan="2">Place area tags</th>
    </tr>
    <tr>
        <td style="width:110px">Name </td>
        <td>
            <asp:Label ID="NameLb" runat="server"/>
         </td>
    </tr> 
    <tr>
        <td style="width:120px">Tags</td>
        <td>
            <asp:ListView ID="AreaTagsLV" runat="server" ItemPlaceholderID="AreaPH">
                <LayoutTemplate><asp:PlaceHolder ID="AreaPH" runat="server" /></LayoutTemplate>
                <ItemTemplate>
                    <%# Eval("Name") %>
<%--                [<asp:LinkButton ID="DeleteLkB" runat="server" OnCommand="DeletePlaceArea_Click" CommandArgument='<%# Bind("ID") %>' Text="X" />]
--%>                <br />
                </ItemTemplate>    
            </asp:ListView>
      
        </td>
    </tr>  
    <tr>
        <td style="width:120px">Add
        </td>
        <td>
            <asp:DropDownList id="AreaDDLUC" runat="server" Width="250" />        
            <asp:LinkButton ID="AddAreaLkB" runat="server" Text="Add" OnClick="AddPlaceArea_Click"  />
        </td>
    </tr>
    <tr>
        <td style="width:120px"></td>
        <td style="padding:6px 0px 6px 10px">
<%--            <%= Html.ActionLink<ModerateController>(c => c.Index(), "Finish", new { _class = "button" })%>
--%>        </td>
    </tr>           
</table>

</form>

</asp:Content>
