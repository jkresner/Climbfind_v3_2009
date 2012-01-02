<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="WriteMessage.aspx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.WriteMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

 
<div style="float:right;width:160px">
    <Ad:InputFormRight160x600  id="AdUnit160x600UC" runat="server" />                           
</div>  


<div style="float:left;width:690px">

<h1>Write a message to <%= climberProfile.FullName %></h1>


<form id="Form1" runat="server">

<asp:ScriptManager ID="ScripManagerUC" runat="server" />
<asp:UpdatePanel ID="WriteMessageUP" runat="server">
    <ContentTemplate>
    
<asp:MultiView ID="WriteMessageMV" runat="server" ActiveViewIndex="0">


<asp:View ID="VIEWWriteMessage" runat="server">

<div class="inputForm">

<p class="formTip" style="width:110px"><b><%= CFControls.ClimberProfileLink(this, climberProfile) %></b>
   <%= Html.ImagePreview(climberProfile.ProfilePictureUrlMini, climberProfile.ProfilePictureUrl, Html.Encode(climberProfile.FullName))%>
</p>

<label>Subject</label>
<VAM:TextBox ID="SubjectTxB" runat="server" Width="350" />
<div style="width:2px;float:left"><VAL:Message ID="SubjectVAL" runat="server" TargetID="SubjectTxB" Maximum="200" FieldName="Subject" Group="SendMessage" /></div>                    

<label>Message</label>
<VAM:TextBox ID="MessageTxB" runat="server" Width="500" TextMode="MultiLine" />
<div style="width:2px;float:left"><VAL:Message ID="MessageVAL" runat="server" TargetID="MessageTxB" Maximum="2000" FieldName="Message" Group="SendMessage" /></div>
<hr />
    <VAM:LinkButton ID="NewPartnerCallBtn" runat="server" Text="Send" OnClick="SendMessage_Click"
        CssClass="superButton" Group="SendMessage" />
<hr />

</div>
  
</asp:View>

<asp:View ID="VIEWMessageSent" runat="server">

<div class="successMSG">Thank you, your message has been sent.</div>

<div style="height:40px;margin:15px 0px 15px 0px">
    <%= CFControls.SuperButton<ClimberProfilesController>(c => c.Detail(climberProfile.ID), 
        string.Format("Return to {0}'s profile", climberProfile.FullName), this) %>
</div>

</asp:View>

</asp:MultiView>

</ContentTemplate>
</asp:UpdatePanel>


</form>
</div>
   

</asp:Content>
