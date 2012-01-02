<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" AutoEventWireup="true" CodeBehind="Join.aspx.cs" Inherits="IdentityStuff.Views.Home.Join" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">


<div id="RegisterDIV" runat="server">


<h1>Create your profile and connect with other climbers. It's easy :)</h1>


<div style="height:800px;float:left;width:380px">

<p style="margin-top:5px"><b>If you are going to look for people to climb with, they need to know who you are when you contact them.</b></p>

<p>On the right is an example <i>Climbfind profile</i>. It contains your basic details, places where you climb and extra info like types of climbing you enjoy.</p>

<p>It's important to spend a few minutes filling out your profile, <b>and upload a good picture</b> because the more personal and informative your profile is, the more likely someone will be willing to consider climbing with you.</p>

<form runat="server">

<asp:CreateUserWizard ID="RegisterUserUC" runat="server"     
    DuplicateUserNameErrorMessage="The supplied email address already has an account." 
    OnCreatingUser="SetUserNameToEmailAddres"
    OnCreatedUser="RedirectToProfilePage">
    <WizardSteps>
        
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            <ContentTemplate>
                <table style="width:380px;margin-top:6px">
                    <tr>
                        <th colspan="2">Create a new profile and login</th>
                    </tr>
                    <tr>
                        <td style="width:110px">E-mail:</td>
                        <td>
                            <VAM:TextBox ID="UserName" runat="server"  Width="210" />
                            <VAL:Email ID="UserNameVAL" runat="server" TargetID="UserName" Group="Register" FieldName="E-mail" />

                            <asp:TextBox ID="Email" runat="server" style="width:1px;visibility:hidden;display:none" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:110px">Password:</td>
                        <td>
                            <VAM:TextBox ID="Password" runat="server" TextMode="Password" Width="210" />
                            <VAL:Password ID="PasswordVAL" runat="server" TargetID="Password" Group="Register" FieldName="Password" />

                        </td>
                    </tr>
                    <tr>
                        <td style="width:110px">Confirm Password:</td>
                        <td>
                            <VAM:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="210" />
                            <VAL:Password ID="ConfirmPasswordVAL" runat="server" TargetID="ConfirmPassword" Group="Register" FieldName="Confirm Password" /> 
                            <VAM:CompareTwoFieldsValidator ControlIDToEvaluate="Password" runat="server" SecondControlIDToEvaluate="ConfirmPassword" ErrorFormatterSkinID="Default" ErrorMessage="Passwords do not match" />                                           
                        </td>
                    </tr> 
                    <tr>
                        <td style="width:110px">Full name:</td>
                        <td>
                            <VAM:TextBox ID="FullNameTxB" runat="server" Width="210" />
                            <VAL:FullName ID="FullNameVAL" runat="server" TargetID="FullNameTxB" FieldName="Full name" Group="Register" />
                        </td>
                    </tr>        
                    <tr>
                        <td style="width:110px">Nick name:</td>
                        <td>
                            <VAM:TextBox ID="NickNameTxB" runat="server" Width="210" />
                            <VAL:FullName ID="NickNameVAL" runat="server" TargetID="NickNameTxB" FieldName="Nick name" Group="Register" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:110px">Nationality: </td>
                        <td id="NationalityTD" runat="server">
                            

                            <DDL:NationalityDDL ID="NationalityDDLUC" runat="server" Width="215" />           
                        </td>
                    </tr>
                    <tr>
                        <td style="width:110px">Sex: </td>
                        <td>
                            Male <asp:RadioButton ID="IsMaleRB" runat="server" GroupName="Sex" />, 
                            Female <asp:RadioButton ID="IsFemaleRB" runat="server" GroupName="Sex" />
                            
                            <VAM:MultiConditionValidator ID="SexSelectedVAL" runat="server" Operator="OR" Group="Register"
                                 ErrorFormatterSkinID="Default"  ErrorMessage="You must select Male or Female as your sex.">
                                <Conditions>
                                    <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsMaleRB" />
                                    <VAM:CheckStateCondition Checked="true" ControlIDToEvaluate="IsFemaleRB" />
                                </Conditions>
                            </VAM:MultiConditionValidator>
                            
                        </td>
                    </tr>   
                                                    
                    <tr>
                        <td style="width:70px"></td>
                        <td>           
                            <VAM:LinkButton ID="CreateUserButton" Text="Create profile" Group="Register" CommandName="MoveNext" runat="server" CssClass="button" />                          
                        </td>
                    </tr>                         
                </table>         

                <span style="color:red"><asp:Literal ID="ErrorMessage" runat="server" /></span>                 
            </ContentTemplate>
            <CustomNavigationTemplate></CustomNavigationTemplate>
        </asp:CreateUserWizardStep>
    </WizardSteps>
</asp:CreateUserWizard>        

</form>


</div>

<div>    
    <div style="float:right"><i>An example Climbfind profile</i></div>
    <img src="/images/specialpages/joinprofileexample402.png" class="imgGrayBorder" style="float:right;margin:5px 15px 0px 0px" />
</div>
    


</div>








</asp:Content>

<%--                    <tr>
                        <td style="width:110px">Level: </td>
                        <td>
                            <asp:DropDownList ID="ClimbingLevelDDL" runat="server" Width="170">
                                <asp:ListItem value="Beginner" />
                                <asp:ListItem value="Intermediate" />
                                <asp:ListItem value="Confident" />                    
                                <asp:ListItem value="Advanced" />                   
                            </asp:DropDownList>       
                        </td>
                    </tr> --%>  