<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="FindClimbersForWatchList.aspx.cs" Inherits="IdentityStuff.Views.CFFeed.FindClimbersForWatchList" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
<h1>Find climbers for your <i>Climbers Channel</i></h1>

<b>There are 3 methods for finding climbers:</b>

<p>1) Type the name of the person you are looking for in the search bar up the top right of the site. 

<span style="display:block;padding:5px 0px 0px 10px;font-size:10px">On a side note, make sure that your full name is
spelt correctly on your own profile so people can find you.
<%= Html.ActionLink<ClimberProfilesController>(c=>c.Edit(), "Edit your profile now") %> if it isn't.
</span></p>

<p>2) Use different channels on your homepage feed to get familiar with climbers who climb where you climb, then add them to your <i>Climbers channel</i>.</p>

<p>3) Add some of our suggested climbers from the list of suggested climbers below</p>
</div>


<div class="vPageSection">

    <h1 style="margin-bottom:10px">Suggested climbers</h1>

    <div style="width:48%;clear:both;padding:10px 0px 0px 0px">
        <img src="/thumb.ashx?o=a07&p=a9459aea.jpg&t=CPinMB" style="float:left;margin:2px 6px 0px 0px;width:80px" />
        <p style="float:left;margin:0px 0px 0px 6px;padding-top:0;width:300px">

            <b><a href="/climber-profile/a071283a-7625-4d73-9bf6-8e95d534e78c" rel="nofollow" >The Climbfind Team</a></b>
            <span style="font-size:10px;display:block">See where Jon & Kev are gallivanting around the world promoting Climbfind and climbing with lots of randomns.</span>
            > <a href="/CFFeed/RequestToWatchClimber/a071283a-7625-4d73-9bf6-8e95d534e78c" >Add Climbfind to my channel</a>
        </p>
    </div>

    <div style="width:48%;clear:both;padding:10px 0px 0px 0px">
        <img src="/thumb.ashx?o=a96&p=a89230e3.JPG&t=CPinMB" style="float:left;margin:2px 6px 0px 0px;width:80px" />
        <p style="float:left;margin:0px 0px 0px 6px;padding-top:0;width:300px">
            <b><a href="/climber-profile/a9646cc3-18cb-4a62-8402-5263ba8b3476" rel="nofollow" >Jonathon Kresner</a></b>

            <span style="font-size:10px;display:block">Founder of Climbfind.</span>
            > <a href="/CFFeed/RequestToWatchClimber/a9646cc3-18cb-4a62-8402-5263ba8b3476" >Add Krez to my channel</a>
        </p>
    </div>





<%--<% foreach (ClimberProfile p in SuggestedClimbersToWatch)
   { %>
    <div style="width:48%;clear:both;padding:10px 0px 0px 0px">
        <img src="<%= p.ProfilePictureUrlMini %>" style="float:left;margin:2px 6px 0px 0px;width:80px" />
        <p style="float:left;margin:0px 0px 0px 6px;padding-top:0;width:300px">
            <b><%= CFControls.ClimberProfileLink(this, p) %></b>
            <span style="font-size:10px;display:block">A blub about the person and why you might want to follow them goes here...</span>
            > <%= Html.ActionLink<CFFeedController>(c=>c.RequestToWatchClimber(p.ID), string.Format("Add {0} to my channel", p.NickName)) %>
        </p>
    </div>
<% } %>
--%>



</div>



</asp:Content>
