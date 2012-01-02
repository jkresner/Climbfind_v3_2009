<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" 
    CodeBehind="VerifyEmailAddress.aspx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.VerifyEmailAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<h1>Verify your email before sending & receiving mail</h1>

<form runat="server">

<asp:MultiView ID="VerifyEmailMV" runat="server">

<asp:View ID="VIEWWhyVerify" runat="server">

<p><b>Why is Climbfind asking me to verify my email address?</b></p>

<p>Climbfind uses email to forward you messages and replies to your partner calls from other users. You can also get Climbfind to 
alert you about partner calls by email. We need to know that the messages being sent to you are arriving in your email inbox.</p>

<p><b>What do I have to do to verify my email?</b></p>

<p>If <b style="color:blue"><%= cp.Email %></b> is your correct email address:</p>

<p style="margin:0px 0px 0px 40px;font-size:14px"><b>> <asp:LinkButton ID="SendVerifyEmailBtN" runat="server" OnClick="SendVerifyEmail_Click" Text="Send a test email" /></b> now</p>

<br /><br />
<p>If <b style="color:Red"><%= cp.Email %></b> is NOT your correct address or you are having problems verifying your email:</p>
<p style="margin:0px 0px 0px 40px">Contact us at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">contact@climbfind.com</a> for help with changing you address.</p>

</asp:View>

<asp:View ID="VIEWVerifySuccess" runat="server">

<p class="successMSG"><b>Email verification complete, you may now send messages to other users and subscribe to partner calls.</b></p>

    <cf:SubscribeToPartnerCallsWhereIClimb ID="SubscribeUC" runat="server" />

</asp:View>


<asp:View ID="VIEWVeifyEmailSent" runat="server">

<p>A test email has been sent to <b style="color:blue"><%= cp.Email %></b>. Emails can take a few minutes to arrive. Please click the link inside the email to complete the verification process.</p>

</asp:View>

</asp:MultiView>  
  
  
</form>



</asp:Content>