<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="IdentityStuff.Views.Clubs.Detail" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">


<h1><%= club.Name %>

    <% if (UserIsModerator) { %>
            <span style="font-size:14px">
                &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditClub(club.ID), "Edit details")%>
                &nbsp - &nbsp<%= Html.ActionLink<ModerateController>(c => c.EditClubLogo(club.ID), "Change logo")%>


            </span>
    <% } %>

</h1>

<table class="NoStylesTable">
        <tr>
            <td>
                <img src="<%= club.LogoImageUrl %>" alt="<%= club.Name %>" />     
           </td>
            <td style="padding-left:10px">
                <b>Website: </b> <%= club.Website %>
                <br /><b>Contact: </b> <%= club.ContactEmail %>
                <br /><b>Postcode: </b> <%= club.AreaCode %>

                <p><%= club.Description.GetHtmlParagraph() %>  </p>
            </td>
        </tr>
    </table>
</div>


<%--<div class="vPageSection">
    <h1>When <%= club.ShortName %> is climbing</h1>

    <% if (ClubCalls.Count == 0)
       { %>   
       
        <p>Climbfind does not have any information on when <%= club.ShortName%> is meeting next.</p>
    
        <p><b>Posting club meets on Climbfind helps clubs to attrack more attendees and new memebers.</b></p>
    
        <div class="attentionDIV">If you are invovled in running <%= club.Name%>, 
            <b><%= Html.ActionLink<ClubsController>(c => c.PostMeet(), "post your next meet")%></b> now.
        </div>
    
    <% }
       else
       { %>

          
            <div id="SearchResults" style="margin-top:-15px;padding:0px 0px 20px 0px">
                <% foreach (PartnerCall call in ClubCalls)
                   { %>
                     <table style="width:100%;height:26px;margin:20px 0px 10px 0px">
                            <tr>
                                <td>
                                    <b>
                                    <%= call.CallTypeString %>
                                    <%= string.Format("{0:hh:mm tt ddd dd MMM}", call.MeetUpDateTime)%>                            
                                    @ <img style="padding:0;border:none" src="<%= call.FlagImageUrl %>" />  <%= call.PlacesClimbfindUrls%>
                                </td>
                                <td style="text-align:right;font-weight:bold">                       
                                    <%= Html.ActionLink<PartnerCallsController>(c => c.Reply(call.ID), "Get in touch", new { _class = "partnerCallReply" })%>                    
                                </td>
                            </tr>
                        </table>            
                        <div style="margin-left:10px">                    
                                <b><%= call.CreatorFullName%></b> wrote:
                                <div style="width:390px;margin:15px 0px 0px 0px"><%= call.Message%></div>             
                          
                        </div>
                <% } %>
            </div>

        <% } %>
    

</div>

--%>

<div class="vPageSection">
    <h1>Members</h1>


<div class="attentionDIV">
    <% if (!UserLoggedIn)
       { %>
          <b>Please <%= Html.ActionLink<HomeController>(c => c.Login("", this.Request.RawUrl.ToString()), "login")%> to participate in this club.</b>
   
    <% } else if (!UserIsInClub)
       { %>
        <b><%= Html.ActionLink<ClubsController>(c => c.JoinClub(club.ID, UserID), "Join this club")%></b>
    <% }
       else
       { %>
<%= Html.ActionLink<ClubsController>(c => c.LeaveClub(club.ID, UserID), "Leave this club")%>
    <% }
        %>
</div>


    <% if (Members.Count == 0) { %><p>No one has said they are a member of this club yet :(</p> <% }
       else { %>
       
        <p>Displaying <%= Members.Count%> members</p>
 
        <%= Html.RenderUserControl("~/Views/ClimberProfiles/ProfileLinkWithPictureList.ascx", Members)%>

    <% } %>

</div>


<div style="clear:both;height:10px"></div>




</asp:Content>
