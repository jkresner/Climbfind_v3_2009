<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" AutoEventWireup="true" CodeBehind="EditOutdoorCragPictures.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Media.EditOutdoorCragPicture" %>

<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

    <h1>Change pictures for <%= crag.Name %></h1>

    <form runat="server">

        <div class="vPageSectioTop">
    
            <img src="<%= crag.DescriptionImage1Url %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />
     
            <b>Picture 1</b>

            <p>To change Picture 1, browse your computer for a picture and click 'Change pic 1'.</p>

            <asp:FileUpload ID="Image1UploadUC" runat="server" />

            <br /><br />

            <asp:LinkButton ID="ChangePictureBtN" runat="server" Text="Change pic 1" 
                OnClick="UploadImage_Click" CssClass="button" />  
        
            <%= CFControls.Button<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, crag.FriendlyUrlName), "Cancel", this)%>
        </div>


        <div class="vPageSection">

            <img src="<%= crag.DescriptionImage2Url %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />

            <b>Picture 2</b>

            <p>To change Picture 2, browse your computer for a picture and click 'Change pic 2'.</p>


            <asp:FileUpload ID="Image2UploadUC" runat="server" />
            <br /><br />

            <asp:LinkButton ID="LinkButton1" runat="server" Text="Change pic 2" 
                OnClick="UploadImage2_Click" CssClass="button" />  
            <%= CFControls.Button<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, crag.FriendlyUrlName), "Cancel", this)%>
    
        </div>

        <div class="vPageSection">

            <img src="<%= crag.DescriptionImage3Url %>" class="float-left" style="border:none;padding:0px;margin-top:0px" />
            <b>Picture 3</b>

            <p>To change Picture 3, browse your computer for a picture and click 'Change pic 3'.</p>

            <asp:FileUpload ID="Image3UploadUC" runat="server" />
            <br /><br />

            <asp:LinkButton ID="LinkButton2" runat="server" Text="Change pic 3" 
                OnClick="UploadImage3_Click" CssClass="button" />  
            <%= CFControls.Button<PlacesController>(c => c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, crag.FriendlyUrlName), "Cancel", this)%>

        </div>
    
    </form>
    

</asp:Content>
