<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="2008-FeatureArticle.aspx.cs" Inherits="IdentityStuff.Views.News.FeatureArticle2008" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1><%= Article.ArticleHeading %> &nbsp
    <%= CFControls.AddThisBookmark(this, this.Request.RawUrl.ToString(), "Climbfind feature articles" + Article.ArticleHeading)%>
</h1>

<p style="font-size:14px">Reported by <%= Article.ReportedBy %> on <%= Article.Date.ToString("dd MMM yyyy") %></p>

<%= Article.ArticleHtml %>


<p style="margin-top:20px;font-size:14px">By <%= Article.ReportedBy %></p>
<script type="text/javascript">    var addthis_pub = "jkresner"; </script>
<a href="http://www.addthis.com/bookmark.php?v=20" onmouseover="return addthis_open(this, '', 'http://cf3.climbfind.com<%= this.Request.RawUrl.ToString() %>', 'Climbfind feature articles - <%= Article.ArticleHeading  %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="http://s7.addthis.com/static/btn/lg-share-en.gif" width="125" height="16" alt="Bookmark and Share" style="border:0;padding:0px 10px 0px 0px"/></a><script type="text/javascript" src="http://s7.addthis.com/js/200/addthis_widget.js"></script>


<style type="text/css">

.AllBestPhotos td { padding:10px 20px 0px 0px }
#AboutCompetition td { padding:10px 20px 0px 0px }

</style>

</div>
 

<% foreach (PhotoSet set in ArticlePhotoSets)
   { %>

<div class="vPageSection">

    <h1><%= set.Title %></h1>
    <p><b>Scroll over the thumbnails to see larger versions of the photos.</b></p>


   <table class="NoStylesTable AllBestPhotos" style="width:100%">
        <% int i = 0; foreach (string fileName in set.PhotoImageNames)
           {
               i++; %>
            <tr>
                <td>
                    <%= Html.ImagePreview(
                        string.Format(@"{0}/Thumb/{1}", set.PhotoWebDirectory, fileName),
                          string.Format("{0}/{1}", set.PhotoWebDirectory, fileName), 
                            fileName ) %>                
                </td>
            </tr>
        <% } %>
    </table>
    
</div>

<% } %>

<div class="vPageSection"><br />

    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManagerUC" runat="server" />
        <cf:MessageBoard ID="MessageBoardUC" runat="server" />  
    </form>    
    
 </div>   


<div class="vPageSection">
    <h1>Other indoor climbing articles</h1>

    <table class="NoStylesTable">  
        <% foreach (FeatureArticle article in Articles)
           { %>                   
                <tr>
                    <td style="padding:4px 7px 4px 10px"><%= article.Date.ToString("dd MMM yyyy")%></td>
                    <td style="padding:4px">
                         <b><%= Html.ActionLink<NewsController>(c => c.FeatureArticle(article.Date.ToString("yyyy-MM-dd"), article.FriendlyUrl), article.ArticleHeading, new { title = article.MetaDescription })%></b>
                        by <%= article.ReportedBy %>            
                    </td>
                </tr>
        <% } %>
    
    </table>

</div>



</asp:Content>
