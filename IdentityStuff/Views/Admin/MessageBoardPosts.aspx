<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MessageBoardPosts.aspx.cs" Inherits="IdentityStuff.Views.Admin.MessageBoardPosts" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<style type="text/css">

img.mbIMG 
{
  margin: 5px 15px 5px 0px;
  float:left;
  border:none;
  padding:0px;
}

.messagePost
{
  margin:5px 0px 2px 0px;
  borde.r-top: solid 1px #F3F3F3;
  padding:5px 0px 0px 0px; 
}

</style>

<form runat="server">

<asp:ScriptManager ID="ScriptManagerUC" runat="server" />
<asp:UpdatePanel ID="UpdatePN" runat="server">
    <ContentTemplate>
    

<asp:DataPager ID="MessagesDP" runat="server" PageSize="10" PagedControlID="MessagesLV">
    <Fields>
        <asp:NumericPagerField NextPageText="Next" PreviousPageText="Previous" ButtonType="Link" />
        <asp:NextPreviousPagerField ButtonType="Link" FirstPageText="First" LastPageText="Last"  />
    </Fields>
</asp:DataPager>

<asp:ListView ID="MessagesLV" runat="server" ItemPlaceholderID="MessagesPH">
    <LayoutTemplate>
       
                <asp:PlaceHolder ID="MessagesPH" runat="server" />         
        
    </LayoutTemplate>
    <ItemTemplate>
    
        <div class="messagePost">

            <img id="Img1" src='<%# Eval("ProfilePictureUrl") %>' alt="profile pic" class="mbIMG" style="width:50px" />                                    

            <div style="margin-left:75px;font-size:12px">
                <b><%# CFControls.ClimberProfileLink((ViewPage)this.Page, (Guid)Eval("PosterUserID"), (string)Eval("PostersName"))%></b> 
                - 
                <%# ((DateTime)Eval("PostedDateTime")).ToCFDateAndTimeString()%>
                                          
                <div style="min-height:50px;margin:15px 0px 0px 0px"><%# Eval("Message")%></div>                
            </div>
        
        </div>   
             
    </ItemTemplate>
</asp:ListView>

</ContentTemplate>
</asp:UpdatePanel>
</form>

</asp:Content>
