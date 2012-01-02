<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

<style type="text/css">
    h4 { font-weight:bold;display:block;margin:10px 0px 10px 0px }
    h3 { margin-left:0 }
    ul li { margin:5px 0px 5px 10px } 
    em { color:Red;font-weight:bold }
    #Index { margin:0;padding:0 }
    #Index a { font-weight:bold }
</style>

<div style="width:27%;float:right">
    <h1>Index</h1>

    <ul id="Index">
        <li><a href="#Intro">0) Intro</a></li>
        <li>&nbsp 0.1 Welcome</li>
        <li>&nbsp 0.2 Getting in touch</li>
        <li><a href="#Accounts">1) User Accounts</a></li>
        <li>&nbsp 1.1 Verifying your email address</li>
        <li>&nbsp 1.2 Forgotten password</li>
        <li><a href="#Contacting">2) Contacting other users</a></li>
        <li>&nbsp 2.1 Preferred contact</li>
        <li>&nbsp 2.2 Using the feed to communicate</li>
        <li>&nbsp 2.3 Private messages</li>
        <li><a href="#Places">3) Finding climbing locations</a></li>
        <li>&nbsp 3.1 Browsing by world map</li>
        <li>&nbsp 3.2 Browsing by area</li>
        <li>&nbsp 3.2.1 Why place isn't showing</li>
        <li>&nbsp 3.3 Using the search box</li>
        <li><a href="#ManagingPosts">4) Managing posts & partner calls</a></li>
        <li>&nbsp 4.1 Viewing</li>
        <li>&nbsp 4.2 Deleting</li>
    </ul>
</div>

<div style="width:71%;float:left">

<h1>Help / FAQ</h1>

<i>Document created <%= new DateTime(2009, 9, 15).ToLongDateString() %></i>
<br /><i>Last updated <%= new DateTime(2009, 9, 19).ToLongDateString() %></i>

<h3 id="Intro">0) Intro</h3>

<h4>0.1 Welcome</h4>

<p>Thanks for looking at Climbfind's help page. 
This site was built and is maintained by a single programmer who now also works full time, so thank you in advance 
for your patience with any problems you may encounter while using this continually evolving site. Also apologies if 
there is delay in replying to your emails. Regardless of any technical issues that you may experience, I 
sincerely hope you get a chance to meet some incredible people through the site and experience some life changing 
adventures. I know I have :)</p>

<h4>0.2 Getting in touch</h4>

<p>Please read through this document before contacting us
about an issue you are experiencing. Once you have reviewed all the sections that 
may contain an answer to your issue, if your question is still unanswered, 
the best way to get our attention is to leave feedback on our <a href="/Feedback">feedback page</a>. Alternatively
if you need to attach a screen shot or write more than 1000 characters you may 
<a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">email us</a> directly.
</p>

<h3 id="Accounts">1) User accounts</h3>

<h4>1.1 Verifying your email address</h4>

<p>If you have sent yourself a test email and it has not shown up in your inbox, <em>please check your SPAM folder</em>. 
If you find it in your SPAM folder, mark all mail from Climbfind as "Not Spam". Also add "mailman@climbfind.com" to
your contacts / safe list. Please note that sometimes emails take a while to arrive, especially with Yahoo! where emails
can take up to 24 hours to appear in your inbox.</p>

<h4>1.2 Forgotten password</h4>

<p>If you do not remember your password, you can <a href="/Home/ForgottenPassword">reset your password</a>. 
This will send a new auto generated
 password to your email. When the new password arrives you can use it to log in and from 
 <a href="/ClimberProfiles/Me">your profile page</a> under
 "options" you
 can <a href="/Home/ChangePassword">change your password</a> to anything you like.
</p>

<h3 id="Contacting">2) Contacting other users</h3>

<h4>2.1 Preferred contact</h4>

<p>Climbfind was originally built with the intention for users to contact each other through mediums outside the
website, i.e. phone, email etc. The reason being it is quite hard for emails from a small website to always 
successfully pass through SPAM filters. Also emails can take a while to arrive which stops us from hooking you up
with a climbing buddy as short as an hour before you want to climb. For this reason every profile on Climbfind
shows a person's preferred means to be contacted. If the preferred contact method is not specified, you should 
resort to sending a message to that person.</p>

<h4>2.2 Using the feed to communicate</h4>

<p>The best way to reply to something another user has posted is to click the "Comment / Reply"
link under their post. If you don't mind that other users can see your message, this is the best way to
communicate as using the feed also allows for conversation between more than two people, thus
creating community. The feed also helps other users see that you are an active user who climbs at the
same places they climb. Everyone who has commented on a feed post will be notified by email of 
subsequent comments to the post you have commented on.</p>

<h4>2.3 Private messages</h4>

<p>If you want to contact another user and you don't want your message to be visible to any other users,
you can send messages to other users my clicking the "Msg xxx" link under that persons post in the feed or
the "Send message" link in the options on the right of their profile page.</p>

<p><i>We apologise and are aware that the messaging system is not the most user friendly system. There
is unfortunately a lot of work to be done on the site before we get around to rebuilding it. We suggest you
communicate using the feed unless you really need the message to be private.</i></p>

<h3 id="Places">3) Finding climbing locations</h3>

<h4>3.1 Browsing by world map</h4>

<p>The easiest way to see all climbing locations around you that have been added to Climbfind by other users is to
zoom in on the <a href="/Places/Indoor">World Indoor Climbing</a> and 
<a href="/Places/Outdoor">World Outdoor Climbing</a> maps. From there just scroll over the icons and click on the
name of the place to open up its profile page.</p>

<h4>3.2 Browsing by area</h4>

<p>If you find the world maps overwhelming an alternative is to drill down to places via the 'area pages'. Start on the 
<a title="Find indoor climbing gyms, outdoor climbing locations by area" href="/Places">Climbing areas</a>
page and click on the one you are interested. You will then be shown a map of that area and when you scroll down
you will also see all the places listed with address, contact details and directions.
</p><p>
Unfortunately the list of places in each area is not exhaustive. Rather they are a reflection
of the work that has been done by the Climbfind and moderators team. We are always looking for people to help us
work on improving the content on our areas and places. Send us an email if you would like to help.</p>

<h4>3.2.1 Why place isn't showing</h4>

<p>If you are searching for a place by area, it may not be showing for one of two reasons. 

<ul style="margin:0px 0px 0px 20px;padding:0">
    <li>1) It may not have been added to Climbfind. In this case you should go ahead and add it. </li>
    <li>2) It is already on our system, but it has not been categorised under the correct set of areas. For example, <a href="/places/outdoor-rock-climbing/united-states/mickeys-beach">Mickey's Beach</a> belongs is "USA", "California" and "San Francisco",
but someone may have only categorised it under "USA" and "California" by accident. To add a place under all the
appropriate areas click the link that says "Edit details" next to the "Info" heading a place's profile page. 
On the edit page move to the section that says "Area tags" and type the name of the area in the text box.</li>
</ul>
</p>

<h4>3.3 Using the search box</h4>

<p>The quickest way to navigate to an area or a specific place is by typing its name into the search box up on the top right 
side of the site. If it doesn't come up on the search results page it is not in our database and you should add it.</p>

<h3 id="ManagingPosts">4 Managing posts & partner calls</h3>


<h4>4.1 Viewing</h4>

<p>All of your posts are displayed on your <a href="ClimberProfiles/Me">profile page</a> which you can access
from the top navigation menu by going "ME" => "Profile".</p>

<h4>4.2 Deleting</h4>

<p>In each post/partner call that belongs to you, you will see a small 'Delete' link.</p>

</div>




    
</asp:Content>
