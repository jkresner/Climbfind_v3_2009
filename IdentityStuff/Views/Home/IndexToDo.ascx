<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexToDo.ascx.cs" Inherits="IdentityStuff.Views.Home.IndexToDo" %>

<% if (ItemStack.Count > 0)
   { %>

<script type="text/javascript">
    $().ready(function() {
        $('#NextItems > div').mouseenter(function() {
            $(this).toggleClass("nextitemhighlight"); $(this).find("div").show();
        }).mouseleave(function() { $(this).toggleClass("nextitemhighlight"); $(this).find("div").hide(); });
        $('#NextItems > div > div > a ').click(function() { alert('Oooops this feature will be built tomorrow (or the day after).') });
    });
</script>


<h1>Next moves</h1>

<% foreach (string html in ItemStack)
   { %>

<div>> <%= html%></div> 

<% }
   } %>
   
   <%--<div><a href="#">done</a> | <a href="#">hide</a></div>--%>