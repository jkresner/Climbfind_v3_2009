<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="DetailCrag.aspx.cs" Inherits="IdentityStuff.Views.Places.DetailCrag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
   
 <%--
    <%= CFControls.BreadCrumbTrail(new IdentityStuff.UI.Controls.IBreadCrumb[]    
        {
            Crumb<PlacesController>(place.Name, c=>c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName)), 
            Crumb<PlacesController>(Crag.Name, c=>c.DetailCrag(place.FriendlyUrlLocation, place.FriendlyUrlName, Crag.CragTypeString, Crag.FriendlyUrlName))
        } ) %> --%>     
    
    <h1><%= Crag.Name %>                      
        <% if (UserLoggedIn)
           { %>   
            <span style="font-size:14px">&nbsp<%= Html.ActionLink<MediaController>(c => c.EditOutdoorCragPictures(Crag.ID), "Change pictures")%>
        <%  if (Crag.CreatedByUserID == UserID)
            { %>

             &nbsp -&nbsp<%= Html.ActionLink<ModerateController>(c => c.OwnerEditOutdoorCrag(Crag.ID), "Edit details")%>
        
        <% }
            else if (UserIsModerator)
            { %>
            
             &nbsp -&nbsp<%= Html.ActionLink<ModerateController>(c => c.EditOutdoorCrag(Crag.ID), "Edit details")%>
            
        <% }
           } %></span>          
     &nbsp 
     <%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), "Climbfind outdoor climbing - " + place.Name) %>

    </h1>

    <style type="text/css"> #PlaceImages img { border:none;padding:0px; } </style>

   <div id="PlaceImages" style="margin:0px 20px 0px 0px;float:left;width:225px">
        
        <%= GetPhotoHtml(Crag.DescriptionImage1Url, descriptionImageFile1ByUser, "Outdoor rock climbing at " + Crag.Name)%>   
           
        <%= GetPhotoHtml(Crag.DescriptionImage2Url, descriptionImageFile2ByUser, "Climbing around " + Crag.Name)%>   

        <%= GetPhotoHtml(Crag.DescriptionImage3Url, descriptionImageFile3ByUser, "Rock climbing " + Crag.Name )%>   

    </div>

    <div style="float:left;width:415px">    

        <p style="margin-top:-3px;text-align:justify"><b>Part of:</b> Climbing at <b><%= Html.ActionLink<PlacesController>(c=>c.DetailOutdoor(place.FriendlyUrlLocation, place.FriendlyUrlName), place.Name) %></b></p>

        <p style="margin-top:-3px;text-align:justify"><b>About:</b> <%= GetParagraphIfNoInfo(Crag.Description) %></p>

        <p style="margin-top:-3px;text-align:justify"><b>Access:</b> <%= GetParagraphIfNoInfo(Crag.Access) %></p>

        <p style="margin-top:-3px;text-align:justify"><b>Approach:</b> <%= GetParagraphIfNoInfo(Crag.Approach) %></p>

        <p style="margin-top:-3px;text-align:justify"><b>History:</b> <%= GetParagraphIfNoInfo(Crag.History) %></p>

<%--        <p style="margin-top:-3px;text-align:justify"><b>Bugs: </b> <%= Crag.Mosquitoes.ToYesNo() %></p>
--%>
        <p style="margin-top:-3px;text-align:justify"><b>Climbing types:</b> 
        
        <% if (Crag.HasAlpine) { %><br />Alpine climbing<% } %>
        <% if (Crag.HasBoulder) { %><br />Bouldering<% } %>
        <% if (Crag.HasBuildering) { %><br />Buildering<% } %>
        <% if (Crag.HasDWS) { %><br />Deep Water Soloing<% } %>
        <% if (Crag.HasIce) { %><br />Ice climbing<% } %>
        <% if (Crag.HasLead) { %><br />Lead climbing<% } %>
        <% if (Crag.HasMultipitch) { %><br />Multipitch climbing<% } %>
        <% if (Crag.HasSolo) { %><br />Soloing<% } %>
        <% if (Crag.HasSport) { %><br />Sport climbing<% } %>
        <% if (Crag.HasTopRope) { %><br />Top rope<% } %>
        <% if (Crag.HasTrad) { %><br />Trad climbing (gear placement)<% } %>
        
         </p>


<%--        <p style="margin-top:-3px;text-align:justify">
            <b>Climbing summer:</b> AM - <%= Crag.ClimbingSummerAM.ToYesNo() %>, PM - <%= Crag.ClimbingSummerPM.ToYesNo() %>
            <br /><b>Climbing winter:</b> AM - <%= Crag.ClimbingWinterAM.ToYesNo() %>, PM - <%= Crag.ClimbingWinterPM.ToYesNo() %></p>
--%>
    </div>
</div>   

<%--<div class="vPageSection">
    <h1>Routes / problems</h1>

    <p>The adding routes / problems feature is coming next week :).</p>

</div>--%>

<div class="vPageSection">
    <h1>Media <%= Html.ActionLink<MediaController>(c=>c.AddCragYouTube(Crag.ID), "Add YouTube Movie") %></h1>

    <%= CFControls.MediaList(this, Media) %></div>



<div class="vPageSection">
    <h1>Other crags around <%= place.Name %></h1>

    <% if (OtherCrags.Count == 0)
       { %>
            <p>Climbfind does not have information on other crags in  <%= place.Name%>. If know of some please
            <%= Html.ActionLink<ModerateController>(c => c.AddOutdoorCrag(place.ID), "Add more climbing")%> to  <%= place.Name%> now.</p>
    <% }
       else
       { %>
              <%= Html.RenderUserControl("~/Views/Places/CragsList.ascx", OtherCrags, new { place = place })%>    
    <% } %>

</div>

<div class="vPageSection">
    <form id="Form1" runat="server">

    <asp:ScriptManager ID="ScripManagerUD" runat="server" />
    <cf:MessageBoard ID="MessageBoardUC" runat="server" />

    </form>
</div>

</asp:Content>
