<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginOrRegister.ascx.cs" Inherits="ClimbFind.Web.Mvc.Controls.LoginOrRegister" %>

<div style="height:160px;margin-bottom:20px">
    
<img src="/images/ui/climbing-photos/log-in-to-climbfindl.jpg" class="float-left" alt="Log in to www.climbfind.com" />

<asp:Login ID="LoginUC" runat="server" OnLoggedIn="LogLogin">
    <LayoutTemplate>
        <table style="width:350px;margin:0px 0px 10px 0px">
            <tr>
                <th colspan="2">Log in details</th>
            </tr>
            <tr>
                <td style="width:70px">E-mail:</td>
                <td>
                    <VAM:TextBox ID="UserName" runat="server" Width="230" />
                    <VAL:Email ID="UserNameVAL" runat="server" TargetID="UserName" Group="Login" FieldName="E-mail" />
                </td>
            </tr>
            <tr>
                <td style="width:70px">Password:</td>
                <td>
                    <VAM:TextBox ID="Password" runat="server" TextMode="Password" Width="230" />
                    <VAL:Password ID="PasswordVAL" runat="server" TargetID="Password" Group="Login" FieldName="Password" />
                </td>
            </tr>
            <tr>
                <td style="width:70px"></td>
                <td>
                    <asp:CheckBox ID="RemmemberMe" runat="server" /> <span style="font-size:9px">Keep me logged in</span>
                </td>
            </tr>
            <tr>
                <td style="width:70px"></td>
                <td>
                    <div style="float:left">
                        <VAM:LinkButton id="LoginButton" runat="server" CommandName="Login" Text="Log in" Group="Login" CssClass="button" />
                    </div>
                    <a href="/Home/ForgottenPassword" style="float:right;font-size:10px">Forgot password?</a>
                    <div style="color:red;font-weight:bold;clear:both;font-size:10px"><asp:Literal ID="FailureText" runat="server" /></div>
                </td>  
            </tr>                                                
        </table>
    </LayoutTemplate>
</asp:Login>        


</div>

