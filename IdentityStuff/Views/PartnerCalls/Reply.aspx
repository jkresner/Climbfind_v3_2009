<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="IdentityStuff.Views.PartnerCalls.Reply" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1><%= GetHeading() %></h1>


<asp:MultiView ID="ReplyToPartnerCallMV" runat="server" ActiveViewIndex="0">

<asp:View ID="VIEWReply" runat="server">

        <%= CFControls.ClimberProfileFull(this, PartnerCallPoster) %>

    
    <div class="vPageSection" style="margin-top:0px;padding:20px 0px 0px 0px">

    <table class="NoStylesTable">
        <tr>
            <td style="width:160px;height:220px;overflow:hidden;padding:2px 5px 0px 0px">
                <div>

                    <div style="margin-top:-30px">
                        <p style="height:10px;color:White">Indoor rock climbing, mountaineering equiptment, camping gear, rock climbing shoes, 
                        Rock climbing dating, mountain climbing, moutain walking, climb everest, hiking, climbing rope, outdoor climbing courses.
                        </p>
                        <script type="text/javascript"><!--
                            google_ad_client = "pub-8929518485692248";
                            /* 120x240 2 ads sq */
                            google_ad_slot = "0401766929";
                            google_ad_width = 120;
                            google_ad_height = 240;
                        //-->
                        </script>
                        <script type="text/javascript"
                        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                        </script>
                    </div>

                </div>
            
            </td>
            <td style="width:430px">
                     <div>

                <b><%= Html.Encode(Current.CreatorFullName)%> wants to:</b>                        
               <div>
                    <% if (Current.ToTopRope) { %><div id="TopRopeDIV" runat="server" style="float:left;text-align:center;padding:10px">
                        <div>Top rope</div>
                        <img id="TopRopeImg" runat="server" src="~/images/ui/cf/TopRope.bmp" alt="Top rope" />
                    </div><% } %>
                    <% if (Current.ToLeadClimb) { %><div id="ToLeadClimbDIV" runat="server" style="float:left;text-align:center;padding:10px">
                        <div>Lead climb</div>
                        <img id="LeadImg" runat="server" src="~/images/ui/cf/Lead.bmp" alt="Lead" />
                    </div><% } %>
                    <% if (Current.ToBoulder) { %><div id="ToBoulderDIV" runat="server" style="float:left;text-align:center;padding:10px">
                        <div>Boulder</div>
                        <img id="BoulderImg" runat="server" src="~/images/ui/cf/Boulder.bmp" alt="Boulder" />
                    </div><% } %>                    
                </div>
                                
                <div style="clear:both">
                    <b>Place(s): </b>
                    
                        <%= Current.PlacesClimbfindUrls %>
             
                     <br /><b><%= Html.Encode(Current.CreatorFullName)%> wrote:</b>
                        <p><%= Html.Encode(Current.Message) %></p>             
                </div>
                
                </div>
            </td>
        </tr>
    </table>

    
       
        
    </div>

    <div class="vPageSection" style="margin-bottom:60px">
    
    <h1>Your reply</h1>

    <form id="Form1" runat="server">
    
        <div class="inputForm" style="width:710px">
        
            <label>Reply message to <%= Html.Encode(Current.CreatorFullName)%>'s partner call</label>
        
            <div style="width:76%;float:left">
                <cf:CharacterCount ID="MessageCount" runat="server" TargetID="MessageTxB" CharacterLimit="1024" />
                <VAM:TextBox id="MessageTxB" runat="server" TextMode="MultiLine" style="width:99%;height:75px" />
            </div>
            <VAL:Message ID="MessageVAL" TargetID="MessageTxB" FieldName="Reply message" runat="server" Maximum="1024" />                             
 
            <hr />
                <VAM:LinkButton ID="PartnerCallReplyBtn" runat="server" Text="Send" 
                    CssClass="superButton" OnClick="ReplyToPartnerCall_Click" />
            <hr />
            
        </div>

    </form>
    </div>




</asp:View>

<asp:View ID="VIEWSentReply" runat="server">

<div class="successMSG">Thank you, your reply to <%= PartnerCallPoster.NickName %> has been sent.</div>

<div style="margin:15px 0px 20px -20px;overflow:hidden;height:60px">
<script type="text/javascript"><!--
    google_ad_client = "pub-8929518485692248";
    /* 728x90, horzontal banner */
    google_ad_slot = "3142647751";
    google_ad_width = 728;
    google_ad_height = 90;
//-->
</script>
<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
</div>

<div class="vPageSecion" style="font-size:12px">
<h1>Options</h1>

> <%= Html.ActionLink<PartnerCallsController>(c=>c.PostACall(), "Post a call for partners") %>
<% foreach (int placeID in Current.PlaceIDs)
   { %>
<br />> <%= Html.ActionLink<PlacesController>(c => c.SeekingPartners(
                ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.FriendlyUrlLocation, placeID),
                ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.FriendlyUrlName, placeID)
                ), "See people looking for partners at " + ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.Name, placeID))%>
<br />> <%= Html.ActionLink<PartnerCallsController>(c => c.Subscribe(
                ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.FriendlyUrlLocation, placeID),
                ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.FriendlyUrlName, placeID)
                ), "Subscribe to partner calls for " + ClimbFind.Model.DataAccess.CFDataCache.GetPlaceProp<string>(p => p.Name, placeID))%>

<% } %> 
</div>

</asp:View>

<asp:View ID="VIEWDeleted" runat="server">

    <p>This partner call was deleted by its creator.</p>

</asp:View>

</asp:MultiView>


</asp:Content>
