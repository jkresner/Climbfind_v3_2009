<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBoard.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.MessageBoard" %>


<div id="MessageBoardDIV" runat="server" visible="false">

        <h1><%= Heading %></h1>
        
        <table class="NoStylesTable" style="margin:0px;width:98%">
            <tr><td style="width:170px"><%= CFAdControls.Ad("Messageboard", 7) %>
                <% if (MessageCount > 2) { %><%= CFAdControls.Ad("Messageboard2", 9) %><% } %>
            </td>
                <td>
                

        
        <asp:UpdatePanel ID="MessageBoardUP" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

<asp:HiddenField ID="MessageBoardIDHD" runat="server" Visible="false" EnableViewState="true" />
<asp:HiddenField ID="OwnersUserIDHD" runat="server" Visible="false" EnableViewState="true" />


  <table id="PostMessageTAB" style="width:100%;border-bottom:solid 0.5px gray" runat="server">
    <tr>
        <th colspan="2">Post a message:</th>
    </tr>
    <tr>
        <td colspan="2">
            <VAM:TextBox ID="MessageBoardMessageTxB" runat="server" TextMode="MultiLine" style="width:98%;height:50px" />
            
            <VAL:Message ID="MessageBoardMessageVAL" TargetID="MessageBoardMessageTxB" runat="server" Group="MessageBoard" FieldName="Message" Maximum="1024" />

            <div style="margin:4px 0px 6px 0px;height:26px">                   
                <VAM:LinkButton ID="CreateMessageBtn" runat="server" Text="Post" OnClick="CreateMessage_Click" Group="MessageBoard" CssClass="button" />
            </div>
        </td>
    </tr>       
</table>   

        
    <div id="SignInDIV" runat="server" visible="false" class="attentionDIV">
        Please <b><a href="/Login" rel="nofollow">sign in</a></b> to leave a message on this message board.
    </div>    
        

<asp:ListView ID="MessagesLV" runat="server" ItemPlaceholderID="MessagesPH">
    <EmptyDataTemplate>
        <p><b>This message board is lonely, it has no messages...</b></p>
    </EmptyDataTemplate>
    <LayoutTemplate>
       
                <asp:PlaceHolder ID="MessagesPH" runat="server" />         
        
    </LayoutTemplate>
    <ItemTemplate>
    
        <div class="messagePost">

            <img id="Img1" src='<%# Eval("ProfilePictureUrl") %>' alt="profile pic" class="mbIMG" />                                    

            <div style="margin-left:125px">
                <b><%# CFControls.ClimberProfileLink((ViewPage)this.Page, (Guid)Eval("PosterUserID"), (string)Eval("PostersName"))%></b> 
                - 
                <%# ((DateTime)Eval("PostedDateTime")).ToCFDateAndTimeString()%>
                                          
                <asp:LinkButton id="DeleteLkB" runat="server" OnCommand="DeleteMessage_Click" CommandArgument='<%# Eval("ID") %>' Visible='<%# ShowDeleteMessageLinkButton((Guid)Eval("PosterUserID")) %>' Text="Delete message" /> 
                     
                <div style="min-height:80px;margin:15px 0px 0px 0px"><%# Eval("Message").ToString().GetHtmlParagraph() %></div>                
            </div>
        
        </div>          
                        
    </ItemTemplate>
</asp:ListView>



            </ContentTemplate>
        </asp:UpdatePanel>

                </td>
            </tr>
        </table>


</div>
