<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="SubmitMovie.aspx.cs" Inherits="IdentityStuff.Views.Media.SubmitMovie" %>
<%@ Register Src="~/Controls/PlacePicker.ascx" TagName="PlacePicker" TagPrefix="cf" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />
<script type="text/javascript"> $(document).ready(function() { $('#AddLink').boxy();}) </script> 


<div class="vPageSectionTop">
<h1>Submit a climbing movie</h1>

<b>Step 1: </b>Upload your movie to YouTube and find the YouTube movie ID.
<br /><br />
<table class="NoStylesTable">
    <tr>
        <td>
            <p>You can find the id at the end of the URL for the movie = > 
                <br /><br />An example of an ID is:
                <br /><b>U2YpYn6PAoM</b> <br /><br />Which is at the end of: 
                <br /><a href="http://www.youtube.com/watch?v=U2YpYn6PAoM" target="_blank">http://www.youtube.com/watch?v=U2YpYn6PAoM</a>
                which you can copy for the grey box we highlighted with a red circle.
            </p>
        </td>
        <td>
            <img src="/images/specialpages/YouTubeInstructions.png" class="imgGrayBorder" />        
        </td>
    </tr>
</table>

<form runat="server">

<div class="inputForm">

   <label>Place <i>(If the place is not coming up => <a id="AddLink" href="#AddPlaceModal" title="Add a place to Climbfind">add it to Climbfind</a>)</i></label>
   <cf:PlacePicker id="PlacePickerUC" runat="server" ValidationGroup="AddMovie" />
                
    <label>Movie title</label>
    <VAM:TextBox ID="YouTubeTitleTxB" runat="server" Width="320" />
    <div style="width:2px;float:left"><VAL:Length ID="YouTubeTitleVAL" IgnoreBlankText="false" Group="AddMovie" TargetID="YouTubeTitleTxB" FieldName="Title" runat="server" Minimum="3" Maximum="255" /></div>
    
    <label>Description</label>
    <asp:TextBox id="YouTubeDescriptionTxB" runat="server" TextMode="MultiLine" Width="56%" Height="60" /></td>

    <label>YouTube ID <i>(e.g. http://www.youtube.com/watch?v=<span style="color:Red"><b>7FpOFhZX48w</b></span> )</i></label>
    <div style="float:left">www.youtube.com/watch?v=</div><VAM:TextBox ID="YouTubeUrlTxB" runat="server" Width="130" /> 
    <div style="width:2px;float:left"><VAL:Length ID="YouTubeUrlVAL" IgnoreBlankText="false" Group="AddMovie" TargetID="YouTubeUrlTxB" FieldName="YouTube ID" runat="server" Minimum="11" Maximum="11" /></div>            
    
    <hr />
    <VAM:LinkButton ID="SavePlaceBtN" runat="server" Text="Submit" CausesValidation="true" Group="AddMovie" OnClick="SubmitMovie_Click" CssClass="superButton" />
    <hr />

</div>




</form>

</div>


<script type='text/javascript' src='/js/jquery.boxy.js'></script>

<div id="AddPlaceModal" style="display:none">
<p>What type of place do you want to add?</p>
<p>> <a href='/Moderate/AddOutdoorLocation'>Add outdoor climbing</a></p>
<p>> <a href='/Moderate/AddIndoorPlace'>Add indoor climbing</a></p>
</div>

</asp:Content>
