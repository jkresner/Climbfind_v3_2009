<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="IdentityStuff.Views.Home.ChangePassword" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:640px;float:left">

<h1>Change your password</h1>

<form runat="server">

<div class="inputForm" style="width:580px">

    <asp:ChangePassword ID="ChangePasswordUC" runat="server">
        <ChangePasswordTemplate>

            <label>Old password</label>
            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" />
            
            <label>New password</label>
            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                ErrorMessage="New Password is required." ToolTip="New Password is required."
                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
            
            <label>Repeat new password</label>
            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="'Repeat password' must match 'New password'"
                ValidationGroup="ChangePassword1"></asp:CompareValidator>
             
             <hr /><br />
             
            <asp:LinkButton ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Save password" ValidationGroup="ChangePassword1" CssClass="superButton" />
            <a href="/ClimberProfiles/Me" class="button" style="margin:26px 0px 0px 8px">Cancel</a>
            
                <hr /><b style="color:Red"><asp:Literal ID="FailureText" runat="server" /></b>
                <hr />
            </ChangePasswordTemplate>
            <SuccessTemplate>
                
                <p class="successMSG">Your password has been saved.</p>
                <hr />
                <a href="/ClimberProfiles/Me" class="superButton" style="margin:26px 0px 0px 8px">Back to profile</a>
                <hr />
          
            </SuccessTemplate>

    </asp:ChangePassword>

    </div>
    
</form>

</div>

<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
</div>

</asp:Content>
