<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/cf.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ClimbFind.Web.Mvc.Views.Home.Search" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<form runat="server">

    <div class="vPageSectionTop">

        <table style="margin-top:5px;width:99%">
            <tr><td style="height:2px;padding:3px;background:#CC6600" colspan="4"></td></tr> 
            <tr>
                <td style="width:70px">
                    <VAM:TextBox ID="NameTxB" runat="server" Width="230" />
                    <VAL:FullName ID="NameVAL" Minimum="2" Maximum="50" TargetID="NameTxB" runat="server" FieldName="Name" Group="Search" />
                </td>
                <td><VAM:LinkButton ID="PartnerSearchBtn" runat="server" CssClass="button" OnClick="Search_Click" Text="Search" Group="Search" /></td>
            </tr><%--
            <tr>
                <td colspan="2">
                        Dispalying  and 
                         for search "<%= searchString %>".
                </td>
            </tr>--%>
        </table>

    </div>




        
    <div class="vPageSection">    


    <table class="NoStylesTable" style="width:100%"> 
        <tr>
            <td id="ProfileResults" style="width:33%">
                <h1>Profiles</h1>
                <asp:Literal ID="PeopleResultCountLB" runat="server" /> profiles

                <asp:ListView ID="PeopleResultsLV" runat="server" ItemPlaceholderID="PeopleResultsPH">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                            <asp:PlaceHolder ID="PeopleResultsPH" runat="server" />                
                    </LayoutTemplate>
                      
                    <ItemTemplate>
                      
                        <div class="vPageSection">
                  
                                <b><%= i++ %>)</b> &nbsp
                                <b><%# CFControls.ClimberProfileLink(this, (Guid)Eval("ID"), (string)Eval("FullName") ) %></b>
                                
                                <div style="margin-top:5px">
                                    <img src="<%# (string)Eval("ProfilePictureUrlMini") %>" style="float:left" />
                                    
                                    
                                    
                                    <div style="margin-left:140px;padding-top:2px">
                                            
                                     
                                        <div><b>Nick name:</b> <%# Eval("NickName") %></div>
                                        <div><b>Nationality: </b>
                                                <img src="<%# Eval("FlagImageUrl_Absolute") %>" class="flag" />
                                                 <%# Eval("NationalityString") %></div>                                
    <%--                               <div><b>Sex: </b><%# Eval("Sex") %></div>--%>
                                        <div><b>Climbing ability: </b><%# Eval("ClimbingLevel") %></div> 
                                </div>
                                </div>
                            </div>   
                    </ItemTemplate>
                </asp:ListView>


            
            </td>
             

            <td style="width:36%;padding-right:10px">
                <h1>Places</h1>

                <asp:Literal ID="PlaceResultCountLB" runat="server" /> places
                <asp:ListView ID="PlaceResultsLV" runat="server" ItemPlaceholderID="PlaceResultsPH">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                        <div><asp:PlaceHolder ID="PlaceResultsPH" runat="server" /></div>
                    </LayoutTemplate>
                    <ItemTemplate>
                    
                        <div class="vPageSection">
                            
                            <b><%= j++ %>)</b> &nbsp <img src="<%# Eval("FlagImageUrl2") %>" /> <b><a href="<%# Eval("ClimbfindUrl") %>"><%# Eval("Name") %></a></b>

                            <div style="margin-top:15px">

                            
                                <img src="<%# Eval("PrimaryImageUrl") %>" style="height:90px;width:90px;float:left;margin-right:20px" />
                            
                                <p style="margin:0"><%# Eval("Description").ToString().Take(120) + " ..." %></p>
                            
                            </div>
                        </div>
                    
                    </ItemTemplate>
                </asp:ListView>
                
            </td>
            <td style="width:30%;padding-right:10px">
                <h1>Areas</h1>

                <asp:Literal ID="AreaResultCountLB" runat="server" /> areas with climbing

                <asp:ListView ID="AreaResultsLV" runat="server" ItemPlaceholderID="AreaResultsPH">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                        <div><asp:PlaceHolder ID="AreaResultsPH" runat="server" /></div>
                    </LayoutTemplate>
                    <ItemTemplate>
                    
                        <div class="vPageSection">
                            <b><%= l++ %>)</b> &nbsp <img src="<%# Eval("FlagImageUrl") %>" /> <b>
                            <a href="<%# Eval("ClimbfindUrl") %>"><%# Eval("Name") %></a></b>
                        </div>
                    
                    </ItemTemplate>
                </asp:ListView>

            </td>
        </tr>
    </table>
             
             
             
             

    </div>


</form>

</asp:Content>
 
 