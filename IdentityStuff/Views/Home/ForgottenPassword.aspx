<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="ForgottenPassword.aspx.cs" Inherits="IdentityStuff.Views.Home.ForgottenPassword" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Reset your ClimbFind password:</h1>

<form runat="server">

    <div style="height:200px">

        <img id="Img3" src="~/images/ui/climbing-photos/forgot-your-climfind-passwordl.jpg" class="float-left" runat="server" alt="Ger your rock climbing password" />

    <b>Reset your password and send to your email:</b>


    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
          <UserNameTemplate>
     
                <table style="width:310px;margin-top:16px">
                    <tr>
                        <th colspan="2">Enter your account details</th>
                    </tr>
                    <tr>        
                        <td>E-mail:</td>
                        <td> 
                            <asp:TextBox id="UserName" runat="server" Width="200" />
                            <asp:requiredfieldvalidator id="UserNameRequired" runat="server" CssClass="errorBox" ControlToValidate="UserName" Text="Email required<br /><br />" ValidationGroup="PasswordRecovery" />
                        </td>
                    </tr>
                    <tr>
                        <td style="color:#F3F3F3">Password: </td>
                        <td>
                            <asp:linkbutton runat="server" commandname="Submit" text="Send" id="Button" ValidationGroup="PasswordRecovery" CssClass="button" />           
                            <asp:literal runat="server" id="FailureText"></asp:literal>
                        </td>
                    </tr>
                </table>
            
             </UserNameTemplate>
             <SuccessTemplate>
                <p>Your password has been sent</p>
             </SuccessTemplate>
    </asp:PasswordRecovery>

    </div>

</form>

</asp:Content>
