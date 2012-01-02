<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PartnerCustomWidget.aspx.cs" Inherits="IdentityStuff.Views.PartnerCalls.PartnerCustomWidget" %>
<head><title><%= ViewData["PageTitle"] %></title>
<meta name="robots" content="noindex, nofollow" /></head>
 
   
<style type="text/css">
                    
    <%= Styles.CSS %>
       
</style>

<div class="cssBody">

<h1>People looking for partners</h1>

            
<h2>To add yourself to this list,
<a href="http://cf3.climbfind.com/post-an-ad-for-rock-climbing-partners" target="_blank">post a call for partners</a> on</h2>        
       
<a href="http://cf3.climbfind.com/" target="_blank"><img src="http://cf3.climbfind.com/images/site-partners/climbfind-logo-135x50.png" alt="Climbfind.com logo" class="CFLogo" /></a>


<% foreach (PartnerCall call in Calls)
{ %>

      <table> 
            <tr>
                <td class="ColOne"><%= i++ %>) 
                    <a href="http://cf3.climbfind.com/climber-profile/<%= call.CreatorUserID %>" target="_blank" rel="nofollow"><%= call.CreatorFullName %></a>   
                </td>
                <td class="PostedTxT">For <%= call.PlacesClimbfindUrls %>                                         

                </td><% if (ShowClimbingTypes)
                        { %>    
                <td>
                     <%= call.CreatorFullName%> wants to
                </td><% } %>
            </tr>
            <tr>
                <td>
                    <%= string.Format(@"<img src='{0}' />", call.ProfilePictureFileUrl) %>                
                </td>
                <td>                    
                    <p><% if (!String.IsNullOrEmpty(call.Message)) { %><%= call.Message%><% } else { %>No message left...<% } %></p>
                </td><% if (ShowClimbingTypes)
                        { %>               
                <td rowspan="2">                       
                    <%= ShowClimbingTypeDIVHtml("TopRope", call.ToTopRope)%>
                    <%= ShowClimbingTypeDIVHtml("Lead", call.ToLeadClimb)%>
                    <%= ShowClimbingTypeDIVHtml("Boulder", call.ToBoulder)%>
                </td><% } %>
            </tr>
        </table>

<% } %>

      <% if (!ClimbFind.Controller.CFSettings.IsDevelopmentEnvironment)
       { %>
    <script src="http://www.google-analytics.com/urchin.js" type="text/javascript"></script>           
    <script type="text/javascript">
        _uacct = "UA-1693127-4";
        urchinTracker();
    </script>
    <% } %>  
    
</div>



    