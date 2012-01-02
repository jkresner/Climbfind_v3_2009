<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Email.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.Validators.Email" %>

<VAM:EmailAddressValidator id="EmailVAM" 
    ErrorMessage="Email must have the form individual@host.domain" 
    ErrorFormatterSkinID="Default" runat="server" />
 
<VAM:TextLengthValidator ID="LengthVAM" ErrorFormatterSkinID="Length" runat="server" />