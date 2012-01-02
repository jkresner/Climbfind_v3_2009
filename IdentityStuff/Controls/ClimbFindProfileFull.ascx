<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClimbFindProfileFull.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.ClimbFindProfileFull" %>

<div id="ClimberProfileDetailsDIV">

    <table class="NoStylesTable">
        <tr>
            <td><%= Html.ProfileImagePreview(climberProfile.ProfilePictureUrl, climberProfile.ProfilePictureUrlFull, Html.Encode(climberProfile.FullName)) %></td>
            <td style="padding-left:20px">

                <div><b>Full name:</b> <%= Html.Encode(climberProfile.FullName) %></div>
                <div><b>Nick name:</b> <%=  Html.Encode(climberProfile.NickName) %></div>
                <div><b>Nationality: </b>
                        <img src="<%= climberProfile.FlagImageUrl_Absolute %>" alt="Flag of " class="flag" />
                         <%= climberProfile.NationalityString %></div>
                <div><b>Sex: </b><%= climberProfile.Sex %></div>
                <div><b>Contact number: </b><%= Html.Encode(climberProfile.ContactNumber) %></div>
                <div><b>Climbing ability: </b><%= Html.Encode(climberProfile.ClimbingLevel) %></div> 
                <div><b>Partner status: </b><%= ClimbFind.Model.DataAccess.CFDataCache.GetPartnerStatusName(climberProfile.PartnerStatusID) %></div> 
 
            </td>
        </tr>
    </table>
</div>



