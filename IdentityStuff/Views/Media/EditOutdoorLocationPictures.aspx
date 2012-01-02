<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" AutoEventWireup="true" CodeBehind="EditOutdoorLocationPictures.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Media.EditOutdoorLocationPictures" %>

<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

    <h1>Change pictures for <%= place.Name %></h1>

    <p><b>Note:</b> Uploaded pictures must be less than 4mb.</p>
    <br />
    
    <form runat="server">

        <div class="vPageSectioTop">
    
            <img src="<%= place.DescriptionImageUrl %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />
     
            <b>Picture 1</b>

            <p>To change Picture 1, browse your computer for a picture and click the 'Change pic 1'.</p>

            <asp:FileUpload ID="Image1UploadUC" runat="server" />

            <br /><br />

            <asp:LinkButton ID="ChangePictureBtN" runat="server" Text="Change pic 1" 
                OnClick="UploadImage_Click" CssClass="button" />  
        
            <%= CFControls.Button<PlacesController>(c=>c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName),"Cancel", this) %>
        </div>


        <div class="vPageSection">

            <img src="<%= place.DescriptionImageUrl2 %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />

            <b>Picture 2</b>

            <p>To change Picture 2, browse your computer for a picture and click the 'Change pic 2'.</p>


            <asp:FileUpload ID="Image2UploadUC" runat="server" />
            <br /><br />

            <asp:LinkButton ID="LinkButton1" runat="server" Text="Change pic 2" 
                OnClick="UploadImage2_Click" CssClass="button" />  
            <%= CFControls.Button<PlacesController>(c=>c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName),"Cancel", this) %>
    
        </div>

        <div class="vPageSection">

            <img src="<%= place.DescriptionImageUrl3 %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />
            <b>Picture 3</b>

            <p>To change Picture 3, browse your computer for a picture and click the 'Change pic 3'.</p>

            <asp:FileUpload ID="Image3UploadUC" runat="server" />
            <br /><br />

            <asp:LinkButton ID="LinkButton2" runat="server" Text="Change pic 3" 
                OnClick="UploadImage3_Click" CssClass="button" />  
            <%= CFControls.Button<PlacesController>(c=>c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName),"Cancel", this) %>

        </div>
    
    </form>
    

</asp:Content>
