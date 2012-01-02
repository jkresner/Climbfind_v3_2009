<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupName.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.Validators.GroupName" %>


<VAM:RegexValidator ID="GroupNameRegExVAM" runat="server" 
    ErrorFormatterSkinID="Default" 
    ErrorMessage="Only alphabetic (A-Z) and numberic (0-9) characters are allowed"
    Expression="^([A-Za-z0-9]|)|(|:|-|\s)+$" />

<VAM:TextLengthValidator ID="GroupNameLengthVAM" ErrorFormatterSkinID="Length" runat="server" />