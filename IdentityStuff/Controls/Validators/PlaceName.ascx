<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlaceName.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.Validators.PlaceName" %>

<VAM:RegexValidator ID="PlaceNameRegExVAM" runat="server" 
    ErrorFormatterSkinID="Default" 
    ErrorMessage="Only alphabetic characters (A-Z) are allowed"
    Expression="^([A-Za-z0-9]|\(|\)|é|-|'|’|\.|\s)+$" />

<VAM:TextLengthValidator ID="PlaceNameLengthVAM" ErrorFormatterSkinID="Length" runat="server" />

