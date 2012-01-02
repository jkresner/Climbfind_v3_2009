<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Subscribe.aspx.cs" Inherits="IdentityStuff.Views.PartnerCalls.Subscribe" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">
       
    <h1>Subscribe to partner calls for <%= place.Name %></h1>
    
    <img src="<%= place.PrimaryImageUrl %>" class="float-left imgGrayBorder" style="max-width:140px" />
    
    <p>
    The best way to keep up to speed with people climbing at <a href="<%= place.ClimbfindUrl %>"><%= place.Name %></a> is to get Climbfind to send
    you updates. Otherwise you would need to come back regularly and check the website manually.</p>
    
    <p>There are two ways you can receieve notifications about other climbing enthusiasts and climbing partners at <a href="<%= place.ClimbfindUrl %>"><%= place.Name %></a>:</p> 
   
    <div style="height:20px;clear:both"></div>
   
    <% if (UserLoggedIn)
       { %>
   
   
    <form runat="server">    
    
     <asp:ScriptManager ID="ScriptManagerUC" runat="server" />
    
    <asp:UpdatePanel ID="UpdatePN" runat="server">
        <ContentTemplate>
    
            <table class="NoStylesTable" style="width:100%">
                <tr>
                    <td>
          
                        <img src="/images/UI/icons/Mail.png" style="padding: 1px 4px 2px 5px;float:left;margin:0px 10px 0px 0px" />

                        <asp:MultiView ID="SubcsribeEmailMV" runat="server" ActiveViewIndex="0">
                            <asp:View ID="VIEWSubscribeToEmail" runat="server">                        
                                <div><b>Method 1: <asp:LinkButton ID="SubscribeToEmailLkB" Text="Subscribe using Email" OnClick="SubscribeToEmail_Click" runat="server" /></b><br />Receive an email each time someone posts a partner call for <%= place.ShortName %></div>                    
                            </asp:View>
                            <asp:View ID="VIEWSubscribedToEmail" runat="server">
                                <div class="successMSG" style="margin-left:70px">You are subscribed to partner calls at <%= place.ShortName %> by Email</div>
                                <div style="margin:2px 0px 0px 80px">If you no longer wish to receive emails for partner calls at <%= place.ShortName %>, you can 
                                <asp:LinkButton ID="UnSubscribeToEmailLkB" Text="Unsubscribe" OnClick="UnSubscribeToEmail_Click" runat="server" />.
                                </div>                   
                            </asp:View> 
                        </asp:MultiView> 
                                     
                        <br /><br />

                        <img src="/images/UI/icons/rss.png" style="padding:5px 13px 5px 11px;float:left;margin:0px 10px 0px 0px"  />
             
                        <asp:MultiView ID="SubcsribeRSSMV" runat="server" ActiveViewIndex="0">
                            <asp:View ID="VIEWSubscribeToRSS" runat="server">                        
                                <div><b>Method 2: <asp:LinkButton ID="SubscribeToRSSLkB" Text="Subscribe using RSS" OnClick="SubscribeToRSS_Click" runat="server" /></b></div>                    
                                <div>Receive updates to an RSS reader like iGoogle, MS Outlook, MyYahoo and others.</div>
                            </asp:View>
                            <asp:View ID="VIEWSubscribedToRSS" runat="server">
                                <div class="successMSG" style="margin-left:70px">You are subscribed to partner calls at <%= place.ShortName %> by RSS</div>
                                <div style="margin:2px 0px 0px 80px">Import the feed to your RSS reader using this link below, or you can 
                                <asp:LinkButton ID="UnSubscribeToRSSLkB" Text="Unsubscribe" OnClick="UnSubscribeToRSS_Click" runat="server" />. 
                                <br />> <b><a style="font-style:italic;font-size:10px" href="<%= Html.BuildUrlFromExpression<PlacesController>(c=>c.SeekingPartnersRSS(place.FriendlyUrlLocation, place.FriendlyUrlName)) %>">www.climbfind.com<%= Html.BuildUrlFromExpression<PlacesController>(c=>c.SeekingPartnersRSS(place.FriendlyUrlLocation, place.FriendlyUrlName)) %></a></b></div>
                            </asp:View> 
                        </asp:MultiView> 
                                            
                                
                    </td>
                </tr>
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>            
  
  <div class="vPageSecion"> 
    <br />   
        <cf:SubscribeToPartnerCallsWhereIClimb ID="SubscribeUC" runat="server" />
  </div>  
            
   </form>
   
   

   
   
    <% }
       else
       { %>
            
            <div class="attentionDIV"><b style="color:Red">Note: </b> You must <b><a href="/login">sign in</a></b> to subscribe</div>
            <img src="/images/UI/icons/Mail.png" style="padding: 1px 4px 2px 5px;float:left;margin:0px 10px 0px 0px" />

            <div><b>Method 1: <a href="/login/To to subscribe to partner calls?returnUrl=<%= Html.Encode(this.Request.Url.ToString()) %>"> Subscribe using Email</a></b><br />Receive an email each time someone posts a partner call for <%= place.ShortName %></div>
           
            <br /><br />

            <img src="/images/UI/icons/rss.png" style="padding:5px 13px 5px 11px;float:left;margin:0px 10px 0px 0px"  />
            
            <div><b>Method 2: <a href="/login/To to subscribe to partner calls?returnUrl=<%= Html.Encode(this.Request.Url.ToString()) %>"> Subscribe using RSS</a></b><br />Use an RSS reader like iGoogle, MS Outlook or Yahoo to recieve updates</div>
             
    <% } %>
       
</div>

</asp:Content>
