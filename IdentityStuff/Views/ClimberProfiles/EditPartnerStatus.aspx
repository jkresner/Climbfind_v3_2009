<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditPartnerStatus.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.ClimberProfiles.EditPartnerStatus" %>



<asp:Content ID="Content2" ContentPlaceHolderID="m" runat="server">

<div class="vPageSectionTop">

<h1>Set partner status</h1>
 
 <form action="/ClimberProfiles/UpdatePartnerStatus" method="post">

        <table style="width:100%" id="ExtendedProfileTAB">
        <tr>
            <th>Name</th><th>Description</th>
        </tr>

        <% foreach (ClimberProfilePartnerStatus status in allStatus)
           { %>
                <tr>
                    <td style="width:170px"><input type="radio" id="<%= "SRB" + status.ID.ToString() %>" value='<%= status.ID %>' name="PartnerStatus" <%= SelectRB(status.ID) %> /> <%= status.Name %></td>
                    <td><%= status.Description %></td>
                </tr>          
        <% } %>
         <tr>
            <td style="width:170px"></td>

           <td style="padding:6px 0px 6px 10px">
                <a href="javascript:forceSubmit()" class="button">Save</a>
                <%= Html.ActionLink<ClimberProfilesController>(c => c.Me(), "Cancel", new { _class = "button" })%>
            </td>
        </tr>                                
   
        </table>

    <script type="text/javascript">
        function forceSubmit() 
        {
            document.forms[1].submit(); 
        }
    </script>

 </form>

</div>

</asp:Content>
