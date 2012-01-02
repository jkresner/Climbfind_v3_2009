<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AmazonProductLink.ascx.cs" Inherits="IdentityStuff.Controls.AdUnits.AmazonProductLink" %>


<% if (DateTime.Now.Millisecond % 6 == 0)
       {  %>      
        <iframe src="http://rcm-uk.amazon.co.uk/e/cm?t=climbfind-21&o=2&p=8&l=as1&asins=B0009U7AF4&fc1=000000&IS2=1&lt1=_blank&m=amazon&lc1=CB4721&bc1=FFFFFF&bg1=FFFFFF&f=ifr" style="width:120px;height:240px;" scrolling="no" marginwidth="0" marginheight="0" frameborder="0"></iframe>
    <% }
       else if (DateTime.Now.Millisecond % 5 == 0)
       { %>
        <iframe src="http://rcm-uk.amazon.co.uk/e/cm?t=climbfind-21&o=2&p=8&l=as1&asins=B00131VTGO&fc1=000000&IS2=1&lt1=_blank&m=amazon&lc1=CB4721&bc1=FFFFFF&bg1=FFFFFF&f=ifr&nou=1" style="width:120px;height:240px;" scrolling="no" marginwidth="0" marginheight="0" frameborder="0"></iframe>
    <% }   else if (DateTime.Now.Millisecond % 4 == 0) { %>

        <iframe src="http://rcm-uk.amazon.co.uk/e/cm?t=climbfind-21&o=2&p=8&l=as1&asins=B000VWAKRU&fc1=000000&IS2=1&lt1=_blank&m=amazon&lc1=CB4721&bc1=FFFFFF&bg1=FFFFFF&f=ifr&nou=1" style="width:120px;height:240px;" scrolling="no" marginwidth="0" marginheight="0" frameborder="0"></iframe>
    <% }   else if (DateTime.Now.Millisecond % 3 == 0) { %>

        <iframe src="http://rcm-uk.amazon.co.uk/e/cm?t=climbfind-21&o=2&p=8&l=as1&asins=B000X2ZOMY&fc1=000000&IS2=1&lt1=_blank&m=amazon&lc1=CB4721&bc1=FFFFFF&bg1=FFFFFF&f=ifr&nou=1" style="width:120px;height:240px;" scrolling="no" marginwidth="0" marginheight="0" frameborder="0"></iframe>

    <% } else { %>
    <iframe src="http://rcm-uk.amazon.co.uk/e/cm?t=climbfind-21&o=2&p=8&l=as1&asins=B0013LR198&fc1=000000&IS2=1&lt1=_blank&m=amazon&lc1=CB4721&bc1=FFFFFF&bg1=FFFFFF&f=ifr&nou=1" style="width:120px;height:240px;" scrolling="no" marginwidth="0" marginheight="0" frameborder="0"></iframe>
    
    <% } %>