<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.PartnerCalls.ByPlace" MasterPageFile="~/Views/Shared/cf.Master" %>

<asp:Content ContentPlaceHolderID="m" ID="m" runat="server">

<h1>Post an ad for climbing partners</h1>

<p>If you are ready to find a partner, please <a href="/login"><b>sign in</b></a> or <a href="/join""><b>join</b></a> Climbfind.</p>        


<p title="How to find climbing partners">Climbfind's purpose is to help you find a climbing partner.
The way we help you find either indoor climbing partners or outdoor climbing partners is through our <b>partner call</b> mechanism. Posting
a partner call is essentially posting an ad for partners at specific indoor climbing gyms or outdoor locations where you want to climb.
</p>

<table class="NoStylesTable" style="margin-top:0px">
    <tr>
        <td>
            <p>You also tell Climbfind what types of climbing you want to do, e.g. if you want a lead climbing partner, a partner to top rope with
             or a bouldering buddy. Any other preferences, for example grades you want to climb can be mentioned in your message.
            </p>

            <p>Once your call has been posted, you can find it through the 
                <a target="_blank" href="/search-for-rock-climbing-partners">search partner calls by place</a> page.
            You can even subscribe to partner calls posted
            by others in RSS readers like iGoogle or MyYahoo!</p>

            <div style="margin: 30px 0px 10px 70px;height:25px">        
                    <%= CFControls.SuperButton<HomeController>(c => c.Join(), "Join Climbfind", this)%>
            </div>
        </td>
        <td>
            <img src="/images/specialpages/How-to-find-climbing-partners.png" style="margin:10px 20px 0px 10px" />                      
        </td>
    </tr>
</table>
               


</asp:Content>