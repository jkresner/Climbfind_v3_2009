<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ByPlaceCache.ascx.cs" Inherits="IdentityStuff.Views.PartnerCalls.ByPlaceCache" %>
<%@ OutputCache Duration="6300" VaryByParam="None" %>


<div class="vPageSectionTop divWithFlags">

    <h1>Places where people are looking for climbing partners</h1>

    <p>If you can't see where you want to climb below, <b><a href="/post-an-ad-for-rock-climbing-partners">post your own call for partners</a></b>.</p>

    <p><b>Indoor</b></p>

    <% foreach (Place p in IndoorWithCalls) { %>
        
        <img src="<%=  p.FlagImageUrl2 %>" />
        <%= Html.ActionLink<PlacesController>(c => c.SeekingPartners(p.FriendlyUrlLocation, p.FriendlyUrlName), p.ShortName,
            new { title = string.Format("Find an indoor climbing partner at {0}", p.Name) } )%> &nbsp
       &nbsp
    <% } %>


    <p><b>Outdoor</b></p>

    <% foreach (Place p in OutdoorWithCalls) { %>
        
        <img src="<%=  p.FlagImageUrl2 %>" />
        <%= Html.ActionLink<PlacesController>(c=>c.SeekingPartners(p.FriendlyUrlLocation, p.FriendlyUrlName), p.ShortName,
            new { title = string.Format("Find an outdoor rock climbing partner at {0}", p.Name) } )%> &nbsp
       &nbsp
    <% } %>


    <div class="attentionDIV" style="padding:5px">If you can't see the place where you want to climb,  
    <b><a href="/post-an-ad-for-rock-climbing-partners">posting your own partner call</a></b> will automatically add it to the list for the next person to find.</div>


</div>


<div class="vPageSectionTop divWithFlags">

<h1 title="People wanting indoor climbing partners">Lastest indoor partner calls</h1>

    <ul id="Climbing-Partners" style="font-size:9px"> 
        <% foreach (PartnerCall call in LastestIndoorPartnerCalls)
           { %>
                <li>Posted <%= call.PostedDateTime.ToCFDateString() %>
                    <b><%= Html.ActionLink<PartnerCallsController>(c=>c.Reply(call.ID), call.CreatorFullName) %></b>            
                    wants an indoor climbing partner
                    @ <img src="<%= call.FlagImageUrl %>" /> <%= call.PlacesClimbfindUrls %>                   
                </li>
        <% } %>
    </ul>

</div>

<div class="vPageSection">

<h1 title="People searching for an outdoor climbing partner">Lastest outdoor partner calls</h1>

    <ul id="Climbing-Partners" style="font-size:9px"> 
        <% foreach (PartnerCall call in LastestOutdoorPartnerCalls)
           { %>
                <li>Posted <%= call.PostedDateTime.ToCFDateString() %>
                    <b><%= Html.ActionLink<PartnerCallsController>(c=>c.Reply(call.ID), call.CreatorFullName) %></b>            
                    wants an outdoor climbing partner
                    @ <img src="<%= call.FlagImageUrl %>" />  <%= call.PlacesClimbfindUrls %> 
                </li>
        <% } %>
    </ul>

</div>



  
