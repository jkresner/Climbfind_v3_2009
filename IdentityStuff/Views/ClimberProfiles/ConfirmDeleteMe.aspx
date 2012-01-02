<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConfirmDeleteMe.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.ConfirmDeleteMe" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
    <h1>Confirm you want to delete your account</h1>
    
    <div class="inputForm">

        <label style="color:Red">All data associated with your account will be removed including posts, comments, partner calls & your profile.</label>
    
        <p>If you just want to change your account email address
        <a href="mailto:contact@climbfind.com?subject=I%20want%20my%20Climbfind%20account%20email%20changed"><b>email us</b></a> and we will change it for you. 
        </p>
    
        <p>If you're deleting your account because you're unhappy with the site, please <a href="mailto:contact@climbfind.com?subject=I%20was%20unsatisfied%20with%20Climbfind"><b>send us 
        a one sentence
             email</b></a>
                letting us know why.</p>

    
    <hr />
    <form runat="server">
    <%= CFControls.SuperButton<ClimberProfilesController>(c=>c.Me(), "Cancel", this) %>
    <asp:LinkButton ID="DeleteMeBtn" runat="server" Text="Delete account" OnClick="DeleteMe_Click" CssClass="button" style="margin:26px 0px 0px 8px" />
    </form>
    <hr />

    </div>
    
</div>


</asp:Content>
