<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditFirstTime.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.EditFirstTime" %>



<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1>Create your profile</h1>


<form id="Form1" runat="server">

                
<style type="text/css">
    #ClimberProfileEditTable tbody tr td div img { border:none;padding:0px;margin:0px }
</style>

<table style="width:100%" id="ClimberProfileEditTable">
    <tbody>
        <tr>
            <th colspan="2">Profile details</th>
        </tr>
        <tr>
            <td style="width:120px">Full name</td>
            <td>
                <VAM:TextBox ID="FullNameTxB" runat="server" Width="170" />
                <VAL:FullName ID="FullNameVAL" runat="server" TargetID="FullNameTxB" FieldName="Full name" Group="EditProfile" />
            </td>
        </tr>        
        <tr>
            <td style="width:120px">Nick name</td>
            <td>
                <VAM:TextBox ID="NickNameTxB" runat="server" Width="170" />
                <VAL:FullName ID="NickNameVAL" runat="server" TargetID="NickNameTxB" FieldName="Nick name" Group="EditProfile" />
            </td>
        </tr>
        <tr>
            <td style="width:120px">Nationality</td>
            <td id="NationalityTD" runat="server">
                

                <DDL:NationalityDDL ID="NationalityDDLUC" runat="server" Width="170" />           
            </td>
        </tr>
        <tr>
            <td style="width:120px">Sex</td>
            <td>
                Male <asp:RadioButton ID="IsMaleRB" runat="server" GroupName="Sex" />, 
                Female <asp:RadioButton ID="IsFemaleRB" runat="server" GroupName="Sex" />
                
                <VAM:MultiConditionValidator ID="SexSelectedVAL" runat="server" Operator="OR" Group="EditProfile"
                     ErrorFormatterSkinID="Default"  ErrorMessage="You must select Male or Female as your sex.">
                    <Conditions>
                        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsMaleRB" />
                        <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsFemaleRB" />
                    </Conditions>
                </VAM:MultiConditionValidator>
                
            </td>
        </tr> 
        <tr>
            <td style="width:120px">Level</td>
            <td>
                <asp:DropDownList ID="ClimbingLevelDDL" runat="server" Width="170">
                    <asp:ListItem value="Beginner" />
                    <asp:ListItem value="Intermediate" />
                    <asp:ListItem value="Confident" />                    
                    <asp:ListItem value="Advanced" />                   
                </asp:DropDownList>       
            </td>
        </tr> 
        <tr>
            <td style="width:120px"> 
                Contact number
            </td>
            <td>
                <VAM:TextBox ID="ContactNumberTxB" runat="server" Width="170" />
                <VAL:Length ID="ContactNumberVAl" runat="server" Maximum="25" Minimum="1" TargetID="ContactNumberTxB" FieldName="Contact number" Group="EditProfile" />       
            </td>
        </tr>  
        <tr>
            <td style="width:120px">Show my <br />message board</td>
            <td>
                Yes: <asp:RadioButton ID="ShowMessageBoardRB" runat="server" GroupName="ShowMessageBoard" />,
                No: <asp:RadioButton ID="HideMessageBoardRB" runat="server" GroupName="ShowMessageBoard" />                                       
            </td>
        </tr>
        <tr>
            <td style="width:120px"></td>
            <td style="padding:6px 0px 6px 10px">
                <VAM:LinkButton ID="UpdateClimberBtN" runat="server" Text="Save" OnClick="UpdateClimberProfile_Click" Group="EditProfile" CssClass="button" />
                <%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Cancel", new { _class = "button" })%>
            </td>
        </tr>                                
    </tbody>
</table>


</form>

</div>

</asp:Content>
