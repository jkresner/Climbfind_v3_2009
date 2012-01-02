<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Admin.LogList" EnableEventValidation="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<form runat="server">

<table style="font-size:10px">
    <tr>
        <td><b>User</b></td>
        <td><b>Event type</b></td>
        <td><b>Options</b></td>
    </tr>
    <tr>
        <td><asp:DropDownList id="UsersDDL" runat="server" /></td>
        <td><asp:DropDownList id="EventTypeDDL" runat="server" /></td>
        <td>
            <asp:Button ID="FilterLogsLkB" runat="server" OnClick="FilterLogList_Click" Text="Filter" />
            - <asp:Button ID="DeleteLkB" runat="server" OnClick="DelteLogs_Click" Text="Delete" />
            - <asp:Button ID="ArchiveLkB" runat="server" OnClick="ArchiveLogs_Click" Text="Archive" />                
            - <asp:Button ID="TimeDifferneceLkB" runat="server" OnClick="ShowTimeSpan_Click" Text="Show time difference" />                
        </td>
    </tr>
</table>

<div style="margin:10px 0px 10px 10px;background:#FAFAD2;padding:3px">
    <b>Last Event:</b> <asp:Label ID="EventDescriptionLb" runat="server" ForeColor="Navy" />
</div>

<asp:ListView ID="LogLV" runat="server" ItemPlaceholderID="LogPL">
    <LayoutTemplate>

        <script type="text/javascript">

            function selectAll() 
            {
                var selected = document.getElementById('SelectAllCB').checked;
                var CDL = document.getElementById('LogTAB');
                var inputCBs = CDL.getElementsByTagName('input');

                for (i = 0; i < inputCBs.length; i++) {
                    inputCBs[i].checked = selected;
                }  
            }  
        
        </script>
        
        <table id="LogTAB" style="font-size:10px;text-align:left">
            <tr>
                <th style="width:50px"><input type="checkbox" id="SelectAllCB" onclick="selectAll()" /></th>
                <th style="width:70px">DateTime</th>                
                <th style="width:60px">User</th>  
                <th style="width:80px">Event Type</th>  
                <th>Event</th>
            </tr>
            <asp:PlaceHolder id="LogPL" runat="server"></asp:PlaceHolder>

        </table>
  
    </LayoutTemplate>
    <ItemTemplate>
           
        <tr <%# ColorIfSpecialEvent(((CFLogEventType)Eval("EventType"))) %>>
            <td><%= i++ %> <asp:Literal ID="eID" runat="server" Text='<%# Eval("ID") %>' Visible="false" /> <asp:CheckBox ID="DelCB" runat="server" />
            </td>
            <td><%# Eval("EventDateTime", "{0:HH:mm dd/MM}") %></td>            
            <td><%# Eval("UserID").ToString().Substring(0,8) %></td>            
            <td><%# ((ClimbFind.Model.Enum.CFLogEventType)Eval("EventType")).ToString()%></td>
            <td><%# Eval("Name") %></td>
        </tr>  
                  
    </ItemTemplate>
</asp:ListView>

</form>

</asp:Content>
