<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="ConfirmDelete.aspx.cs" Inherits="IdentityStuff.Views.PartnerCalls.ConfirmDelete" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<h1>Delete partner call</h1>

<h3>We like to know how we're going, fill out this survey to delete your partner call</h3>

<form runat="server">

<div class="inputForm">

<p class="formTip">You are about to delete your call <b>Posted <%= Current.PostedDateTime.ToCFDateString()%></b>                
  for  <%= Current.PlacesClimbfindUrls%>
<span style="display:block;color:Gray"><i>You said:</i> <%= Current.Message %></span></p>

<label>Reason you want to delete your call</label>
<input id="ReasonNoLongerRB" runat="server" type="radio" name="Reason" /> No longer need partners for the place(s) I posted my call

<VAM:MultiConditionValidator ID="ReasonVall" runat="server" Operator="OR"
     ErrorFormatterSkinID="Selection"  ErrorMessage="Please select a reason">
    <Conditions>
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ReasonNoLongerRB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ReasonNotClimbingRB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ReasonWantToRepostRB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ReasonCreepyPersonRB"  />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="ReasonOtherRB" />
    </Conditions>
</VAM:MultiConditionValidator>                                      


<br /><input id="ReasonNotClimbingRB" runat="server" type="radio" name="Reason" /> I'm not really climbing anymore
<br /><input id="ReasonWantToRepostRB" runat="server" type="radio" name="Reason" /> Want to repost with different details
<br /><input id="ReasonCreepyPersonRB" runat="server" type="radio" name="Reason" /> Contacted by someone creepy (<i>you should <a href="mailto:contact@climbfind.com">let us know by email</a></i>)
<br /><input id="ReasonOtherRB" runat="server" type="radio" name="Reason" /> Other (<i>please tell us why on the <a href="/Feedback" target="_blank">feedback page</a></i>)



<label>Number of people who contacted you to climb <i>(type '0' if none)</i></label>
<VAM:IntegerTextBox ID="NumberOfPeopleTxB" runat="server" Width="40" AllowNegatives="false" />

<VAM:RequiredTextValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter a number"
     ErrorFormatterSkinID="Default" ControlIDToEvaluate="NumberOfPeopleTxB" />
<VAM:RangeValidator ID="NumberOfPeopleVAL" runat="server" ErrorMessage="Enter a number"
     ErrorFormatterSkinID="Default" ControlIDToEvaluate="NumberOfPeopleTxB" Minimum="0" Maximum="100" />

<hr />

<VAM:LinkButton ID="DeleteLkb" runat="server" OnClick="Delete_Click" Text="Delete" CssClass="superButton" />

<a href="/ClimberProfiles/Me" class="button" style="margin:26px 0px 0px 8px">Cancel</a>

<hr />

</div>


</form>


</asp:Content>
