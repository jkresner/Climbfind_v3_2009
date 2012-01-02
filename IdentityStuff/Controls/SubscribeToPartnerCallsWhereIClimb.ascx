<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubscribeToPartnerCallsWhereIClimb.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.SubscribeToPartnerCallsWhereIClimb" %>


<h1>Why get partner notifications straight to my inbox?</h1>


<p><b>Answer 1:</b> 'Put Climbfind to work for you'. Instead of having to come back and check the website regularly, 
set Climbfind to automatically tell you when someone is climbing where you want to climb.</p>
    
<p><b>Answer 2:</b> 'Help Climbfind find you last minute partners' on the same day you post.</p>


<div class="attentionDIV" style="padding:6px;margin-left:20px;font-size:10px"><b>How it works: </b> 
If there are more than 20 people subscribed to your local climbing gym, when
you post a call in the morning, 20 people get an email saying you are looking. It is very
probable at least 1/20 will be able to climb with you that evening! Pretty cool huh? Be one of those 20 people!
</div>


<div class="inputForm">
<% if (PlacesUserClimbs.Count == 0)
   { %>
    <p>Your profile doesn't say you climb anywhere :(... Better 
        <%= Html.ActionLink<ClimberProfilesController>(c=>c.EditIndoorPlaces(), "update your climbing gyms") %>
        and <%= Html.ActionLink<ClimberProfilesController>(c=>c.EditIndoorPlaces(), "say where you climb outdoors") %>.
        After that you can subscribe to partner calls for places.
    </p>
<%}
   else
   { %>
<Label>Subscribing options</label>


> <b><asp:LinkButton ID="SubscribeAllLkB" Text="Subscribe to everywhere I climb by email" OnClick="SubscribeByEmailToEverywhere_Click" runat="server" /></b>
<p style="margin:10px 0px 4px 0px;padding-bottom:0">Or if you only want to subscribe to some places, or prefer RSS to email, use the links below.</p>
<% foreach (Place place in PlacesUserClimbs)
   { %>
    > 
    <%= Html.ActionLink<PartnerCallsController>(c => c.Subscribe(place.FriendlyUrlLocation, place.FriendlyUrlName), "Subscribe to " + place.Name)%><br />
<% } %>

<% } %>
</div>