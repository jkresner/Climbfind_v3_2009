<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewStateFriendly.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.PartnerCalls.New" EnableEventValidation="false" EnableViewState="true" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<div style="width:640px;float:left">

<h1>Post a call for partners</h1>

<form runat="server" enableviewstate="true">

<asp:MultiView ID="NewPartnerCallMV" runat="server" EnableViewState="true" ActiveViewIndex="1">


<asp:View ID="VIEWCompleteClimberProfile" runat="server">
    
    <div class="attentionDIV">
        => Please <b><%= Html.ActionLink<ClimberProfilesController>(c=>c.EditPicture(), "upload a photo of youself") %></b> before posting a partner call. That way people will be able to recognise who is making the partner call more easily.
    </div>
    
</asp:View>


<asp:View ID="VIEWDoCorrectPost" runat="server">

<div class="attentionDIV" style="border:solid 1px brown;padding:10px">
    <b style="color:brown">We've made changes to the partner call</b>
  
   <p><b>Partner calls</b> now are general ads for partners at the places where you would like to meet people.
    They do not include a date you want to climb and once you post a call, 
    people will continue to reply until you decide to take it down. </p>
  
    <p>If you want to climb at a specific date and place, for example tonight at your climbing gym
        <b><a href="/CFFeed/NewPost">post to the homepage feed</a></b> and select the tag #NeedPartner.</p>
        
    <p>If you are generally seeking more climbing buddies 
    <b><asp:LinkButton ID="ContineBtn" runat="server" OnClick="ContinueToPostCall_Click" Text="continue posting a partner call" /></b>.</p>
         
         
</div>

    

</asp:View>

<asp:View ID="VIEWNewPartnerCall" runat="server">

<script type="text/javascript" src="/js/jquery.autocomplete.min.js"></script>
<script type='text/javascript' src='/js/jquery.ajaxQueue.js'></script>
<script type="text/javascript">

    $().ready(function() {
    var txb = $("#cf_m_AreaTxB");
        AddWaterMark(txb, "Type city/state/country", "FilterTxBWaterMark");

        txb.autocomplete("/Places/FilterAreaSearch", { scroll: false, minChars: 2, width: 300, selectFirst: false,
            formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1]; },
            formatResult: function(data, value) { return value.split(",")[1]; }
        });

        txb.result(function(event, data, formatted) {
            if (data) {
                if (data[0].split(",")[2] != '-1') {
                    $("#cf_m_AreaID").val(data[0].split(",")[2]);
                    __doPostBack('cf$m$ChangeAreaLkB', '');
                }
            }
        });
    });

</script>

    <div class="inputForm" style="width:601px">
        
        <p class="formTip"><b>Tip</b> Partner calls are great when you want partners, but not for a specific date.
         If you to climb at a specifc time, like tonight, 
         <a href="/CFFeed/NewPost">post to the homepage feed</a> using the tag #NeedPartner</p>
                
        <label>Call type</label>
        <div style="padding:0px 0px 2px 0px"><asp:RadioButton ID="IndoorRB" runat="server" OnCheckedChanged="RefreshPlaces_Click" GroupName="PlaceType" AutoPostBack="true" />Indoor</div>  
        <div><asp:RadioButton ID="OutdoorRB" runat="server" OnCheckedChanged="RefreshPlaces_Click" GroupName="PlaceType" AutoPostBack="true"  />Outdoor</div> 

        <label>City, state or country <i style="font-weight:normal"><a href="/Places">see available choices</a></i></label>
        <input id="AreaTxB" type="text" class="FilterTxBWaterMark" value="Type city/state/country" style="width:260px" runat="server" />
        <VAM:TextBox ID="AreaID" runat="server" style="display:none" /><asp:LinkButton ID="ChangeAreaLkB" runat="server" OnClick="RefreshPlaces_Click" />
        <VAM:RequiredTextValidator ID="AVAL" runat="server" ControlIDToEvaluate="AreaID"
            ErrorMessage="Please select a valid area" ErrorFormatterSkinID="Selection" />

        <div id="PlacesDIV" runat="server">
        <label>Place or places you want partners </label>
        <p id="NoResultsP" runat="server"><i><asp:Literal ID="NoResultsLtr" runat="server" /></i></p>
        
        <asp:ListView ID="PlacesLV" runat="server" ItemPlaceholderID="PlaceItemPH" EnableViewState="true">
           <EmptyDataTemplate></EmptyDataTemplate>
           <LayoutTemplate>
                <div style="margin:4px 0px 0px 0px">
                <asp:PlaceHolder id="PlaceItemPH" runat="server" EnableViewState="true" /></div>
            </LayoutTemplate>            
            <ItemTemplate>
                <div>
                    <input ID="PID" value='<%# Eval("ID") %>' runat="server" type="checkbox" enableviewstate="true" checked='<%# CheckIfUserAlreadyClimbsAt((int)Eval("ID")) %>'/> 
                    <a href='<%# Eval("ClimbfindUrl") %>' target="_blank"><%# Eval("Name") %></a>
                </div>
             </ItemTemplate>
        </asp:ListView>          
            <p id="PlacesErrorDIV" style="color:Red" runat="server" visible="false"><b>You need to chose at least one place</b></p>
        </div>
        <div id="AddPlaceDIV" runat="server" visible="false" class="attentionDIV" style="width:290px;font-size:9px;margin-bottom:0px">If the place you want is not listed 
           <asp:LinkButton ID="AddPlaceLkB" Text="add it to Climbfind" runat="server" OnClick="AddPlace_Click" /> now</div>

        
        <label>Climbing you want to do</label>

        <div class="climbingTypeDIV">
            <div>Top Rope</div>
            <img id="TopRopeImg" runat="server" src="~/images/UI/cf/TopRope.bmp" />
            <asp:CheckBox ID="ToTopRopeCB" runat="server" onclick="toggleNewPartnerCallClimbingTypeImage('TopRope')" />
        </div>
        <div class="climbingTypeDIV">
            <div>Lead Climb</div>
            <img id="LeadImg" runat="server" src="~/images/UI/cf/Lead.bmp" />
            <asp:CheckBox ID="ToLeadCB" runat="server" onclick="toggleNewPartnerCallClimbingTypeImage('Lead')" />
        </div>
        <div class="climbingTypeDIV">
            <div>Boulder</div>
            <img id="BoulderImg" runat="server" src="~/images/UI/cf/Boulder.bmp" />
            <asp:CheckBox ID="ToBoulderCB" runat="server" onclick="toggleNewPartnerCallClimbingTypeImage('Boulder')" />
        </div>
        <div id="TradDIV" class="climbingTypeDIV" runat="server" visible="false">
            <div>Trad climb</div>
            <img id="TradImg" runat="server" src="~/images/UI/cf/Trad.bmp" />
            <asp:CheckBox ID="ToTradCB" runat="server" onclick="toggleNewPartnerCallClimbingTypeImage('Trad')" />
        </div>
        <div id="AlpineDIV" class="climbingTypeDIV" runat="server" visible="false">
            <div>Alpine/Ice</div>
            <img id="AlpineImg" runat="server" src="~/images/UI/cf/Alpine.bmp" />
            <asp:CheckBox ID="ToAlpineCB" runat="server" onclick="toggleNewPartnerCallClimbingTypeImage('Alpine')" />
        </div>


        <script type="text/javascript">
            function toggleNewPartnerCallClimbingTypeImage(type) {
                var cb = document.getElementById("cf_m_To" + type + "CB");
                var img = document.getElementById("cf_m_"+type+"Img");
                if (cb.checked) { img.src = "/images/UI/cf/" + type + "Selected.bmp"; }
                else { img.src = "/images/UI/cf/" + type + ".bmp"; }
            }
        </script>

        
        <VAM:MultiConditionValidator ID="IndoorClimbingTypeVAL" runat="server" Operator="OR"
             ErrorFormatterSkinID="Selection"  ErrorMessage="Select at least one type of climbing">
            <Conditions>
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToTopRopeCB" />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToLeadCB" />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToBoulderCB" />
            </Conditions>
        </VAM:MultiConditionValidator>  

        <VAM:MultiConditionValidator ID="OutdoorClimbingTypeVAL" runat="server" Operator="OR"
             ErrorFormatterSkinID="Selection"  ErrorMessage="Select at least one type of climbing">
            <Conditions>
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToTopRopeCB" />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToLeadCB" />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToBoulderCB" />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToTradCB"  />
                <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ToAlpineCB" />
            </Conditions>
        </VAM:MultiConditionValidator>                                      

            <label>Message explaining the type of people you're after </label>
            <VAM:TextBox id="NewCallMessageTxB" runat="server" TextMode="MultiLine" Width="320px" />
            <VAL:Message ID="NewCallMessageVAL" runat="server" TargetID="NewCallMessageTxB" Maximum="255" Minimum="1" FieldName="Message" />
            <hr />                    
                    
            <VAM:LinkButton ID="NewPartnerCallBtn" runat="server" Text="Post" 
               CssClass="superButton" OnClick="CreatePartnerCall_Click" />
    
            <hr />
    </div>

</asp:View>

<asp:View ID="VIEWPartnerCallPosted" runat="server">

<div class="successMSG">Thank you, your partner call has been posted and will appear in a few minutes.</div>

<div style="height:40px;margin:15px 0px 15px 0px">
    <%= CFControls.SuperButton<ClimberProfilesController>(c => c.Me(), "Go to your profile", this) %>
</div>



</asp:View>

<asp:View ID="VIEWPartnerCallPostedNowSubscribe" runat="server">

<div class="successMSG">Thank you, your partner call has been posted and will appear in a few minutes.</div>

<p>In the meantime, to dramatically increase the chance of you finding partners, consider subscribing to receive notifications
on partners calls by other users.</p>

<cf:SubscribeToPartnerCallsWhereIClimb ID="SubscribeUC" runat="server" />

</asp:View>
<asp:View id="VIEWCantPostSamePlacesTwice" runat="server">

    <p style="font-weight:bold;color:Red">Partner call not saved</p>

    <p>Can't post more than one partner call for the same place(s).</p>
    
    <p>Sometimes this error occurs when you mistakenly click the post button twice.</p>

    <p>Please review your <%= Html.ActionLink<ClimberProfilesController>(c=>c.Me(), "profile page") %>
        page and delete one of your existing calls if you want to post another.
    </p>

</asp:View>


</asp:MultiView>

</form>

</div>

<div style="width:165px;float:right;margin:0px 20px 0px 0px">

    <Ad:InputFormRight160x600 id="Ad" runat="server" />

</div>

</asp:Content>
