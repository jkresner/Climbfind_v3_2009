<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" AutoEventWireup="true" CodeBehind="EditPicture.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.EditPicture" %>

<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

    <h1>Upload a profile picture</h1>

    <form runat="server">

        <div class="inputForm">

            <label>Your profile photo</label>

            <% if (profile.ImageNotUploaded) { %><p>First step in building your profile is uploading a profile photo so other users can recognize you.</p><% } %>

            <p>Browse your computer for a picture & click <b>Upload</b> when you're done</p>

            <p><b style="color:Red">Note</b> Pictures must be valid .jpg files & less than 4mb.</p>

            <asp:FileUpload ID="ProfileImageUploadUC" runat="server" />

            <hr />

            <asp:LinkButton ID="ChangePictureBtN" runat="server" Text="Upload" 
                OnClick="UploadImage_Click" CssClass="superButton" />  
            
            <% if (!profile.ImageNotUploaded) { %>
            <%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Cancel", new { _class = "button", style="margin:26px 0px 0px 3px" })%>
            <% } %>
            
            <hr />
        
        </div>
    
    
    </form>
    

</asp:Content>
