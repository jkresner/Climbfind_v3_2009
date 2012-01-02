<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PartnerWidget.aspx.cs" Inherits="IdentityStuff.Views.Places.PartnerWidget" %>

<head><title><%= ViewData["PageTitle"] %></title>
<meta name="robots" content="noindex, nofollow" /></head>  
<style type="text/css">
    
   <% if (Styles == null) { %>

    .cssBody { font-size:13px;width:620px;font-size:10px }     
    .cssBody a { text-decoration:none;color:Blue } 
    .cssBody a:visited { color:Blue } 
    .cssBody a:hover { text-decoration:underline } 
    .cssBody h1 { } 
    .cssBody h2 { font-style:italic;color:Gray;font-size:14px } 
    .cssBody table {  font-size:13px;clear:both;margin:5px 0px 10px 0px } 
    .cssBody table td { vertical-align:top } 
    .cssBody table img { margin:3px 20px 0px 3px } 
    .cssBody table p { width:280px;padding:0px 20px 0px 0px;text-align:justify } 
    .ColOne { width:155px;font-weight:bold;font-size:14px }
    .ReplyLink { padding-left:20px;margin:0 10px 0 2px;background:url(http://cf3.climbfind.com/images/ui/elite/comment.gif) no-repeat scroll left center } 
    .ClimbingType { margin:0 0 1px 1px;padding:0px 0 6px;text-align:center;width:44px;float:left } 
    .ClimbingType div { margin:2px auto 4px;font-size:9px }
    .ClimbingTypeImg { padding:5px 5px 0px 5px;border:1px solid #DADADA; }
    .CFLogo { border:none;margin-top:10px;float:left;padding:10px 0px 0px 20px }

    <% } else { %><%= Styles.CSS %><% } %>     
</style> 

<div class="cssBody">

<h1>People looking for partners at <%= place.Name %></h1>

            
<h2>To add yourself to this list,
<a href="http://cf3.climbfind.com/post-an-ad-for-rock-climbing-partners" target="_blank">post a call for partners</a> on</h2>        
       
<a href="http://cf3.climbfind.com/" target="_blank"><img src="http://cf3.climbfind.com/images/site-partners/climbfind-logo-135x50.png" alt="Climbfind.com logo" class="CFLogo" /></a>


<% foreach (PartnerCall call in CallForPlace)
{ %>

      <table> 
            <tr>
                <td class="ColOne"><%= i++ %>) 
                    <a href="http://cf3.climbfind.com/climber-profile/<%= call.CreatorUserID %>" target="_blank" rel="nofollow"><%= call.CreatorFullName %></a>   
                </td>
                <td>                                          
                    <a class="ReplyLink" href="http://cf3.climbfind.com/PartnerCalls/Reply/<%= call.ID %>" target="_blank" rel="nofollow">Contact <%= call.CreatorFullName %></a>                  
                </td><% if (ShowClimbingTypes)
                        { %>    
                <td>
                     <%= call.CreatorFullName%> wants to
                </td><% } %>
            </tr>
            <tr>
                <td class="ColOne">
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



    