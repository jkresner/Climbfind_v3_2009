<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="IdentityStuff.Views.Admin.Feedback" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">

<asp:ListView ID="FeedbackLV" runat="server" ItemPlaceholderID="FeedbackPL" EnableViewState="true">
    <LayoutTemplate>
        
        <table style="font-size:10px;text-align:left;vertical-align:top">
            <tr>
                <th style="width:30px"></th>
                <th style="width:70px">Published</th>                 
                <th style="width:70px">Posted</th>                
                <th style="width:70px">FirstReplied</th>                
                <th style="width:70px">LastReviewed</th>                
                <th style="width:160px">User</th>  
                <th style="width:260px">Feedback</th>  
                <th style="width:260px">Response</th>
                <th></th>
            </tr>
            <asp:PlaceHolder id="FeedbackPL" runat="server"></asp:PlaceHolder>

        </table>
  
   
    </LayoutTemplate>
    <ItemTemplate>
        
        <tr>
            <td><%= i++ %></td>
            <td><asp:CheckBox ID="PublishedCB" runat="server" Checked='<%# Eval("Published")%>' /></td>            
            <td><%# Eval("DateTimePosted", "{0:hh:mm dd/MM}")%></td>            
            <td><%# Eval("DateTimeFirstReplied", "{0:hh:mm dd/MM}")%></td>            
            <td><%# Eval("DateTimeLastReviewed", "{0:hh:mm dd/MM}")%></td>            
            <td><%# Eval("FeedbackName") + "<br />" + Eval("FeedbackEmail") + ""%></td>            
            <td><%# Eval("FeedbackFromUser")%></td>
            <td><asp:TextBox ID="ResponseFromAdminTxB" runat="server" TextMode="MultiLine" Text='<%# Eval("ResponseFromAdmin")%>' /></td>
            <td>
            
                <asp:LinkButton ID="UpdateFeedbackLkB" runat="server" CommandArgument=<%# Eval("ID")%> OnCommand="UpdateFeedback_Click" Text="Update" />
                <a href="DeleteFeedback/<%# Eval("ID") %>" style="color:Red">delete</a>    
            </td>
        </tr>  
                  
    </ItemTemplate>
</asp:ListView>

</form>
    
    
</asp:Content>
