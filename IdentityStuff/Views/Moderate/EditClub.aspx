<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EditClub.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditClub" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">


<h1>Edit club details</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>


<table style="width:95%">
    <tr>
        <th colspan="2">Enter place details</th>
    </tr>
    <tr>
        <td style="width:110px">Name </td>
        <td>
            <asp:Label ID="NameLb" runat="server"/>
         </td>
    </tr> 
    <tr>
        <td style="width:120px">Description</td>
        <td><VAM:TextBox ID="DescriptionTxB" runat="server" TextMode="MultiLine" Width="95%" /></td>
    </tr>   
    <tr>
        <td style="width:120px">Area Tags</td>
        <td>
            <asp:ScriptManager ID="ScriptManger" runat="server" />
            <asp:UpdatePanel ID="UP" runat="server">
               <ContentTemplate>
               
               <asp:DataList ID="AreaTagsLV" runat="server">
                <ItemTemplate>
                    <asp:Literal id="NameLtr" Text='<%# Bind("Name") %>' runat="server" /> (<asp:Literal id="Literal1" Text='<%# Bind("FriendlyUrlName") %>' runat="server" />)
                    <asp:LinkButton ID="DelLkB" runat="server" Text="Del" OnClick="RemoveAreaTag_Click" />
                    <asp:Literal id="AreaTagIDLtr" Text='<%# Bind("ID") %>' Visible="false" runat="server" />
                    <br />
                </ItemTemplate>    
            </asp:DataList>
        
               <DDL:AreaTagDDL id="AreaTagDDLUC" runat="server" Width="250" />
                <asp:LinkButton ID="AddAreaLkB" runat="server" Text="Add area tag" OnClick="AddAreaTag_Click" />
               
               </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>    
    <tr>
        <td style="width:120px"></td>
        <td style="padding:6px 0px 6px 10px">
            <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Save" OnClick="UpdateClub_Click" CssClass="button" />
            <%= CFControls.Button<ClubsController>(c=>c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName),"Cancel", this) %>
        </td>
    </tr>           
</table>


</form>

</asp:Content>
