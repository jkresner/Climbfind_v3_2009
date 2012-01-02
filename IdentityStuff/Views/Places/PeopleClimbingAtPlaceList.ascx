<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PeopleClimbingAtPlaceList.ascx.cs" Inherits="IdentityStuff.Views.Places.PeopleClimbingAtPlaceList" %>


    <% if (PartnerCalls.Count == 0)
       { %><b>Partners:</b> No one is looking for partners at this location right now.<% } else { %>


        <p>
            Displaying <b><%= PartnerCallsToDisplay.Count %></b> of <b><%= DistinctUserPartnerCalls.Count %> </b> 
            climbers looking for partners. See
            
            <b></b>
        </p>        

    

<table style="width:100%;font-size:10px;padding:1px">
<% int i = 0; foreach (PartnerCall call in PartnerCallsToDisplay)
   {
       i++; %>
    <tr>
        <td><%= i %></td>
        <td><%= CFControls.ClimberProfileLink((ViewPage)this.Page, call.ClimberProfileID, call.CreatorFullName) %>
        
            wants to climb at <%= call.MeetUpDateTime.ToCFDateAndTimeString() %></td>
        <td>
          <%= Html.ActionLink<PartnerCallsController>(c => c.Reply(call.ID), "Climb with " + call.CreatorFullName)%>                    
        </td>
    </tr>

<% } %>
</table>

<% } %>

<div class="attentionDIV" style="padding:6px">
    To to find people to climb with at this location, <b><%= Html.ActionLink<PartnerCallsController>(c=>c.New(), string.Format("post a call for partners at {0}",  PlaceName)) %>.</b>
</div>