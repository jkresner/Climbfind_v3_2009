<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="IdentityStuff.Views.Home.Feedback" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


    <h1>Website feedback</h1>
    
    <p>Since we made a lot of big changes to Climbfind recently and will continue working on it a lot over the
    next few weeks, we thought now was a good time to resurrect the feedback section. 
    We know the site is far from perfect, criticism is welcome.</p>
    
    <form id="Form1" runat="server">
    
    <asp:MultiView ID="LeaveFeedbackMV" runat="server">
    
        <asp:View ID="VIEWLoginOrRegister" runat="server">
            <div class="attentionDIV">
                Please <b><%= Html.ActionLink<HomeController>(c=>c.Login("", ""), "sign in")  %></b> to leave feedback.
            </div>    
        </asp:View>
 
   
        <asp:View ID="VIEWFinishYourProfile" runat="server">
            <div class="attentionDIV">
                Please 
                <%= Html.ActionLink<ClimberProfilesController>(c=>c.Me(), "finish filling out you profile") %>    
                     and <%= Html.ActionLink<ClimberProfilesController>(c => c.EditPicture(), "upload a photo") %>,

                so that we know who it is that is leaving the feedback.
            </div>    
        </asp:View> 
   
        <asp:View ID="ViewLeaveFeedback" runat="server">
                
            <div class="inputForm" style="width:90%">
                <p class="formTip"><b>Tip</b>Please read other people's comments and what's on our todo list before you
    repeat something already said.</p>
                
                <label>Leave your comment</label>
                <VAM:TextBox ID="CommentTxB" runat="server" TextMode="MultiLine" style="width:480px;height:60px" />
                <VAL:Message ID="CommentVAL" TargetID="CommentTxB" FieldName="Feedback comment" Group="Feedback" runat="server" Maximum="1600" />
                
                <hr />
                <VAM:LinkButton ID="LeaveFeedbackBtn" runat="server" Text="Post feedback" CssClass="superButton" OnClick="PostFeedback_Click" Group="Feedback" />
                <hr />                    
                                    
            </div>
                
        </asp:View>
 
    </asp:MultiView>
    

    </form>    

    <div class="vPageSection">
    
    <div style="width:70%;float:right">
 

    <h1>Feedback left by others </h1>

  
    <% foreach (ClimbFind.Model.Objects.Feedback feedback in SiteFeedback)
       { %>

        <div class="messagePost" style="clear:both">
            
            <img src="<%= feedback.FeedbackProfileImageUrl %>" alt="profile pic" class="mbIMG" />

            <div style="margin-left:125px">
                                     
                <div style="margin:0px 0px 10px 0px"><%= String.Format("{0:dd MMM}", feedback.DateTimePosted) %>            
                - <b><%= Html.Encode(feedback.FeedbackName) %></b> wrote:</div>
                
                <%= Html.Encode(feedback.FeedbackFromUser) %>
            
                <div style="margin:15px 0px 10px 30px;color:navy">
                    <% if (String.IsNullOrEmpty(feedback.ResponseFromAdmin))
                       { %>
                         <i>This feedback has been reviewed, and a reply is being formulated.</i>
                    <% } else {%>
                        
                        <div style="margin:0px 0px 10px 0px"><%= String.Format("{0:dd MMM}", feedback.DateTimeLastReviewed) %>            
                        - <b>Jonathon Kresner</b> replied:</div>
                        
                        <%= feedback.ResponseFromAdmin%>
                    <% } %>
                </div>                
            </div>
         
        </div>

    <% } %>
    
        
    
    
    </div>

    
    <div style="width:25%;float:left">
        <h1>On our todo list</h1>
        <p>Last updated 31st July</p>
        <div style="font-size:10px">
            <div>- Make messaging people more user friendly</div>
            <div>- Fix up the Partner calls => "My call" page</div>
            <div>- Make replying to partner calls easier</div>
            <div>- Pay more attention to Crag level information</div>
        </div>
    </div>


   </div>


        <br />    
    


    
    
    

</asp:Content>
