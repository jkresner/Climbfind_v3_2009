<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditIndoorPlaces.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.EditIndoorPlaces" %>



<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1>Edit indoor places where I climb</h1>

            
<div class="attentionDIV">
    = > Did you mean to 
    <%= Html.ActionLink<ClimberProfilesController>(c => c.EditOutdoorPlaces(), "edit outdoor locations where you climb")%> instead?
</div>

<form id="Form1" runat="server">


                
<style type="text/css">
    #ClimberProfileEditTable tbody tr td div img { border:none;padding:0px;margin:0px }
</style>


<table id="ClimberProfileEditTable" style="width:100%">
    <tbody>
        <tr>
            <th colspan="2">Profile details</th>
        </tr>
        <tr>
            <td style="width:120px">Indoor places where you climb 
            
            <div class="attentionDIV"><span style="color:Red"><b>New!</b></span> If we don't have where you climb listed, please  
    <b><%= Html.ActionLink<ModerateController>(c=>c.AddIndoorPlace(), "add your indoor gym") %></b> to Climbfind's list.</div>

            
            
             </td>
            <td id="PlacesListTD">
    
                <asp:ListView ID="IndoorPlacesUserClimbsLV" runat="server" ItemPlaceholderID="IndoorPlaceItemPH">
                    <LayoutTemplate><div style="padding:5px 0px 0px 5px"><asp:PlaceHolder ID="IndoorPlaceItemPH" runat="server" /></div></LayoutTemplate>
                    <ItemTemplate>
                        <div>
                            <input ID="PID" value='<%# Eval("ID") %>' runat="server" type="checkbox" checked=<%# CheckIfUserAlreadyClimbsAt((int)Eval("ID")) %>  /> 
                        
                            <img id="Img1" src='<%# Eval("FlagImageUrl") %>' runat="server" />
                        
                            <a href='<%# Eval("ClimbfindUrl") %>' target="_blank"><%# Eval("Name") %></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>      
            
                                   
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


            
<div class="attentionDIV"><span style="color:Red"><b>New!</b></span> If we don't have where you climb listed, please  
    <b><%= Html.ActionLink<ModerateController>(c=>c.AddIndoorPlace(), "add your indoor gym") %></b> to Climbfind's list.</div>



</div>

</asp:Content>
