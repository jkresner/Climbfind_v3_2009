<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullName.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.Validators.FullName" %>

<VAM:RegexValidator ID="FullNameRegExVAM" runat="server" 
    ErrorFormatterSkinID="Default" 
    ErrorMessage="Only alphabetic characters (A-Z) are allowed"
    Expression="^([A-Za-z]|-|\s)+$" />

<VAM:TextLengthValidator ID="FullNameLengthVAM" ErrorFormatterSkinID="Length" runat="server" />

