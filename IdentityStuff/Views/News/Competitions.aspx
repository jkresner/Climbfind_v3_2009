<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Competitions.aspx.cs" Inherits="IdentityStuff.Views.News.Competitions" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">



<div class="vPageSectionTop">

    <h1>Coverage from past competitions</h1>
 
    <p>Sadly we are unable to continue our competition coverage as we can't run around the UK taking photos forever. We thought we would leave these up here for good memories :)</p>
    <br />


    <% foreach (Competition comp in Comps) { %>

        <table class="NoStylesTable" style="margin-bottom:20px">
            <tr>
                <td><img class="imgGrayBorder" src="<%= string.Format("/images/news/{0}/{1}", comp.ContentDirectory, comp.ArticleMainPhoto1) %>" style="width:120px" /></td>
                <td style="padding:0px 0px 0px 20px">
                    
                    <b><%= Html.ActionLink<NewsController>(c=>c.Competitions(comp.Date.ToString("yyyy-MM-dd"), comp.FriendlyUrl), 
                        comp.ArticleHeading) %></b>
                        
                        <br /><%= comp.Date.ToLongDateString() %>
                        <br />@ <%= comp.Location %>
                        <div style="font-size:10px">Reported by <%= comp.ReportedBy %></div>
                  </td>
            </tr>
        </table>

    <% } %>

</div>

</asp:Content>

