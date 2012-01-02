<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="ClimbFind.Web.Mvc.Notifications" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<form runat="server">

<div class="vPageSectionTop">
<h1>Partner notifications</h1>

<% if (ActivePartnerCallSubscriptions.Count == 0)
   { %> 
    <p style="margin-bottom:15px"><img src="/images/UI/icons/Warning.png" style="padding:0;margin:0;border:none" /> You are not subscribed to receive notifications on partner calls anywhere.</p>
       
<% } else { %>
   <table style="width:600px;margin-bottom:20px;font-size:10px;line-height:0.95em">
    <tr>
        <th>Place </th>
        <th>By email</th>
        <th>By RSS</th>
        <th></th>
    </tr>
<%foreach (PartnerCallSubscription pcs in ActivePartnerCallSubscriptions)
  { %>  
    <tr>
        <td><%= GetPlaceLink(pcs.PlaceID) %></td>
        <td><%= pcs.Email.ToYesNo() %></td>
        <td><%= pcs.RSS.ToYesNo()%></td>
        <td><%=
                Html.ActionLink<PartnerCallsController>(c=>c.Subscribe(
                    ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(f => f.FriendlyUrlLocation, pcs.PlaceID),
                    ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(f => f.FriendlyUrlName, pcs.PlaceID)), 
                    "Edit subscription")
        %></td>
    </tr>   
<% } } %>

   </table> 
</div>

<div class="vPageSecion">    
    <cf:SubscribeToPartnerCallsWhereIClimb ID="SubscribeUC" runat="server" />
</div>
    
</form>    

 
    
</asp:Content>
