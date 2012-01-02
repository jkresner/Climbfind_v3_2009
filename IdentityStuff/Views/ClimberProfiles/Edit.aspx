<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.Edit" %>



<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<div style="width:660px;float:left">

<h1>Update profile</h1>

<div class="inputForm">
<form id="Form1" runat="server">

<label>Full name</label>
<VAM:TextBox ID="FullNameTxB" runat="server" Width="170" />
<VAL:FullName ID="FullNameVAL" runat="server" TargetID="FullNameTxB" FieldName="Full name" Group="EditProfile" />

<label>Nick name</label>
<VAM:TextBox ID="NickNameTxB" runat="server" Width="170" />

<label>Nationality</label>
<DDL:NationalityDDL ID="NationalityDDLUC" runat="server" Width="170" />           

<label>Sex</label>
Male <asp:RadioButton ID="IsMaleRB" runat="server" GroupName="Sex" /> 
<br />Female <asp:RadioButton ID="IsFemaleRB" runat="server" GroupName="Sex" />

<VAM:MultiConditionValidator ID="SexSelectedVAL" runat="server" Operator="OR" Group="EditProfile"
     ErrorFormatterSkinID="Default"  ErrorMessage="You must select Male or Female as your sex.">
    <Conditions>
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsMaleRB" />
        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsFemaleRB" />
    </Conditions>
</VAM:MultiConditionValidator>
                
<label>Level</label>
<asp:DropDownList ID="ClimbingLevelDDL" runat="server" Width="170">
    <asp:ListItem value="Beginner" />
    <asp:ListItem value="Intermediate" />
    <asp:ListItem value="Confident" />                    
    <asp:ListItem value="Advanced" />                   
</asp:DropDownList>       

<label>Contact <i>preferred way to be contacted, i.e. put your mobile / email or "via Climbfind"</i> </label>
<VAM:TextBox ID="ContactNumberTxB" runat="server" Width="170" />
<VAL:Length ID="ContactNumberVAl" runat="server" Maximum="25" Minimum="1" TargetID="ContactNumberTxB" FieldName="Contact number" Group="EditProfile" />       

<label>Show my message board</label>
<asp:RadioButton ID="ShowMessageBoardRB" runat="server" GroupName="ShowMessageBoard" />  Yes
<br /><asp:RadioButton ID="HideMessageBoardRB" runat="server" GroupName="ShowMessageBoard" />  No

<hr />    
                                              
<VAM:LinkButton ID="UpdateClimberBtN" runat="server" Text="Save" OnClick="UpdateClimberProfile_Click" Group="EditProfile" CssClass="superButton" />
<%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Cancel", new { _class = "button", style="margin:26px 0px 0px 8px" })%>

<hr />

</form>
</div>

</div>



<div style="width:165px;float:right;margin:0px 20px 0px 0px">
    <Ad:InputFormRight160x600 id="Ad" runat="server" />
</div>

</div>

</asp:Content>
