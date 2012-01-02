<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="EditClubLogo.aspx.cs" Inherits="IdentityStuff.Views.Moderate.EditClubLogo" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">


<h1>Change club logo</h1>

<div class="attentionDIV">
    <span style="color:Red"><b>Note</b></span>: This edit will be logged.
</div>


<p>Browse your computer for a picture and click the 'Upload' button when you are done.</p>

<asp:FileUpload ID="ImageUploadUC" runat="server" />


<br /><br />

<asp:LinkButton ID="ChangePictureBtN" runat="server" Text="Upload Picture" 
    OnClick="UploadImage_Click" CssClass="button" />  

<%= CFControls.Button<ClubsController>(c=>c.Detail(club.FriendlyCountryUrl, club.FriendlyUrlName),"Cancel", this) %>


</form>

</asp:Content>
