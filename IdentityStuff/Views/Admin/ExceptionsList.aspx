<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ExceptionsList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Admin.ExceptionsList" EnableEventValidation="false" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<style type="text/css"> td { vertical-align:top} </style>

<script type="text/javascript">

function selectAll() {
    var selected = document.getElementById('SelectAllCB').checked;
    var CDL = document.getElementById('LogTAB');
    var inputCBs = CDL.getElementsByTagName('input');
    for (i = 0; i < inputCBs.length; i++) { inputCBs[i].checked = selected; }
}  

</script>

<form runat="server">

<asp:Button ID="DeleteLkB" runat="server" OnClick="DelteLogs_Click" Text="Delete" />
- Current Time: <%= DateTime.Now %>
<br /><br />


<asp:ListView ID="LogLV" runat="server" ItemPlaceholderID="LogPL">
    <LayoutTemplate>
        
        <table id="LogTAB" style="font-size:10px;text-align:left">
            <tr>
                <th style="width:50px">All:<input type="checkbox" id="SelectAllCB" onclick="selectAll()" /></th>
                <th style="width:55px">DateTime</th>                
                <th style="width:120px">Error</th>    
                <th>Event</th>
            </tr>
            <asp:PlaceHolder id="LogPL" runat="server"></asp:PlaceHolder>
        </table>
   
    </LayoutTemplate>
    <ItemTemplate>
        
        <tr>
            <td>
                <%= i++ %>
                <asp:Literal ID="eID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                <asp:CheckBox ID="DelCB" runat="server" />
            </td>
            <td><%# Eval("ExceptionDateTime", "{0:hh:mm<br /> dd.MM.yy}") %></td>            
            <td><b><%# Eval("UserEmail") %></b><br /><%# Eval("IP") %><br /><%# Eval("Browser") %></td>            
            <td>
                <%# Eval("Url").ToString().Replace("http://www.climbfind.com", "") %>
                <%# Eval("ID") %> <b><%# Eval("InnerMessage") %></b>
                <div style="color:Gray;font-size:8px">
                    <%# Html.Encode((string)Eval("StackTrace")) %>
                </div>
            </td>
        </tr>  
                  
    </ItemTemplate>
</asp:ListView>

</form>


</asp:Content>
