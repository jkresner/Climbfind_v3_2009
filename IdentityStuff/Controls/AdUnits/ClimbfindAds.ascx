<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClimbfindAds.ascx.cs" Inherits="IdentityStuff.Controls.AdUnits.ClimbfindAds" %>

 
<% if (DateTime.Now.Millisecond % 5 == 0)
   {
 %>


<div class="SponsorAdDIV">

     <div class="SponsorAdProductType">Climbing resource</div>    

        <a href="http://www.wikitopo.com/" class="SponsorAdProductDescription" target="_blank">
            Wikitopo - The first place on the web where you can create, edit and share climbing topos
        </a>

    
    <p>
        <a href="http://www.wikitopo.com/" target="_blank">
            <img style="display:block;border:none" alt="book cover" src="/images/ads/wikitopo.gif" />
        </a>
    </p>
</div>

<% } %>