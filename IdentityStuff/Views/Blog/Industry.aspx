<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

    <style type="text/css">        
        #content { width:960px;!important }
        .post p { margin-left:0px;font-size:12px } 
        #SubscribeForm label { padding:10px 0px 0px 0px } 
        #SubscribeForm superButton { margin-bottom:0px }
        #SubscribeForm input[type=text] { width:176px } 
        #checklist { margin:0px;border-top:1px dashed #E1E1E1;margin:5px 0 15px;padding:0 }
        #checklist li { margin:5px 0px 0px 0px;border-bottom:1px dashed #E1E1E1;list-style:none outside none; }
        #checklist li a { padding:0.3em 0 0.3em 10px;color:#666666;width:94%;display:block }
        #checklist li a:hover { background:none repeat scroll 0 0 #FFFFFF;color:#CB4721 }
        #MainBlogContent { width:70%;float:left;padding:7px }
        #BlogSidebar { background:#FCFCF9;width:24%;float:right;padding:7px 8px 7px 8px }
        h4 { color:#6C6E3A;font:2.2em Georgia,"Times New Roman",Times,serif;letter-spacing:-1px;margin:0 0 10px 5px;padding:0 }
        .post-footer { background:none repeat scroll 0 0 #F8F8F8;border:1px solid #EFEFEF;font-size:95%;margin:20px 15px 35px 15px;padding:3px 10px }
        .date { background:url('/images/UI/elite/clock.gif') no-repeat;padding:0px 0px 0px 22px }
    </style>    

    <div id="MainBlogContent" >

    <h2>Climbfind Climbing Industry Blog</h2>

    <div id="Post02Welcome" class="post">
        <h3>How does Climbfind help?</h3>

        <p>You may be thinking "I've already got a facebook group, a twitter page and there are local forums out there that already help people find partners..."</p>

        <p>True. Those mediums are great...</p>
        
        <p><b>Climbfind is a next generation solution, faciliating faster and more targeted geographical connections.</b></p>

        <p><i>Scenario: Sally's regular climbing partner at
         <a href="/places/indoor-rock-climbing-gyms/united-states/planet-granite-san-francisco" target="_blank">Planet Granite San Francisco</a> 
        has called her at 3PM to let her know that she won't be able to top rope with her tonight because she's got the flu.</i></p>

        <p>Until now, Sally would go onto Facebook, post in the dicussion board and possibly someone will get back to her a few days later.</p>

        <p>Enter climbfind:</p>

        <% IndoorPlace pgSF = new ClimbFind.Controller.CFController().GetIndoorPlace(380);  %>
        <style type="text/css"> #blog02RegularsList h2 { font-size:16px;background:none } </style>
        <div id="blog02RegularsList">
            <%= Html.RenderUserControl("~/Views/Places/DetailPlaceRegularsSampleCache.ascx", pgSF, new { NumberOfRegularsToShow = 3, LogoImageFileUrl=pgSF.LogoHalfSizeImageUrl })%>
        </div>


        <p>Of these climbers, <b style="color:Red"><%= new ClimbFind.Controller.CFController().GetSubscriptionCountForPlace(380) %> have elected to be notified by
        email</b> when someone else is looking for a partner at Planet Granite San Fransico.</p>

        <p class="post-footer align-right"><span class="date">May 13, 2010</span></p>
    </div>

    <div id="Post01Welcome" class="post">

    <h3>Welcome! Here's some background on why you're here</h3>
    
    <p>My name is Jonathon Kresner. In March 2008, I moved from my hometown <img src="/images/ui/flags/au.png">
    <a href="/climbing-around/australia/sydney" target="_blank">Sydney, Australia</a> to 
    <br /><img src="/images/ui/flags/england.png"> <a href="/climbing-around/england/london" target="_blank">London, England</a>.
    Because all my climbing friends were back at home, I had to begin the process of finding new people to climb with.</p>
    
    
    <p>One day on the tube (that's UK speak for 'Subway') I had an 'entrepreneurial seizure', I decided it was time to begin my mission  
    of helping people find climbing partners so that they can climb WHENEVER they want, no matter WHERE EVER they are on the entire planet. <%---
    from <img src="/images/ui/flags/ca.png"> <a href="/places/outdoor-rock-climbing/canada/squamish" target="_blank">Squamish</a> to
    <br /><img src="/images/ui/flags/us.png"> <a href="/places/outdoor-rock-climbing/united-states/yosemite" target="_blank">Yosemite</a>,
    <img src="/images/ui/flags/england.png"> <a href="/places/indoor-rock-climbing-gyms/london-united-kingdom/the-castle-climbing-centre" target="_blank">The Castle Climbing Centre</a>
    to  <img src="/images/ui/flags/au.png"> <a href="/places/indoor-rock-climbing-gyms/sydney-australia/sydney-indoor-climbing-gym" target="_blank">Sydney Indoor Climbing Gym</a>, you name it! <br />--%>
     <b>Enter Climbfind</b>:</p>
    
    <img src="/images/specialpages/industryblog/paintedlogo.JPG" class="imgGrayBorder" style="margin:10px 0px 10px 0px" alt="Climbfind Logo Painted on a Wall" />
    
   <p> After 5 months of programming on the bus to and from work (my day job is a website consultant), 
   I released the first version of Climbfind, a website dedicated to helping climbers find partners. We took the UK by storm by
   <a title="Climbfind visits 30 indoor climbing walls around England, Scotland &amp; Wales in 7 days" href="/2008-UK-Roadtrip" target="_blank">visiting 30 climbing gyms in
    England, Soctland and Wales in 7 days</a> to initially get the word out. 
    In July 2009, we decided to spread the climbing love down the West Coast of North America on a
    
    <a title="Climbfind drives from Vancouver, Canada to Los Angeles, USA in 9 weeks" href="/2009-Climbfind-USA-Canada-Road-Trip">2 month a road 
    trip from Vancouver, Canada to Los Angeles</a>. Now in 2010, the goal is to spread it to the rest of the USA.</p>

    <p>Until now, Climbfind has enjoyed steady linear growth. <%--per day and 3000 members subscribed to receive
    an email notification when someone is looking for a friend at their local rock spot.--%></p>

    <img src="/images/specialpages/industryblog/2010.04.28ClimbfindHistory.png" class="imgGrayBorder" style="margin:10px 0px 10px 0px" alt="Climbfind Traffic Pattern" />

    <p>This blog is about how you, The Climbing Industry can contribute to solving the climbing partner challenge, so that climbers will
    have the ability to grow their social circles at will, have a richer experience and stay climbing for the rest of their lives.</p>

    <p style="font-size:14px">First thing you can do is <a href="#SubscribeDetail" title="Subscribe to our blog" class="boxy">Subscribe to our Climbing Industry Blog</a></p>

    <p class="post-footer align-right"><span class="date">May 11, 2010</span></p>

    </div>

    </div>

    <div id="BlogSidebar">
    
    <h4>About</h4>
    
    <p style="margin:2px;text-align:justify">
        <b style="font-size:12px">More people climbing means a healthier climbing community & industry.</b>
        Learn how to help climbers connect with each other,  
        stay motivated & climb more often in the gym.       
    </p>

    <h4 style="margin-top:15px" id="subscribe">Subscribe</h4>

    <p style="margin:2px;text-align:justify">If you work in a climbing gym, in the climbing industry, or are interested in promoting social climbing, subscribe:</p>

        <div id="SubscribeForm" class="inputForm">
   <form name="ccoptin" action="http://visitor.constantcontact.com/d.jsp" target="_blank" method="post" style="margin-bottom:3;">

            <label>Email</label>
            <input type="text" name="ea" value="" />

            <input type="submit" name="go" value="Subscribe" class="superButton" />
            <input type="hidden" name="m" value="1103350875862">
            <input type="hidden" name="p" value="oi">
    </form>
    <hr />

        </div>



    <h4 style="margin-top:20px">Checklist</h4>

        <ul id="checklist" class="sidemenu">
            <li><a href="#SubscribeDetail" class="boxy" title="Subscribe to our blog">Subscribe to this blog</a></li>
            <li><a href="#IntroduceDetail" class="boxy" title="Say hello!">Introduce yourself</a></li>
            <li><a href="#SubscribeStaffDetail" class="boxy" title="Subscribe your staff to this blog">Subscribe your staff / co-workers</a></li>
            <li><a href="#ClimbfindRepDetail" class="boxy" title="Assign a Climbfind Rep">Assign a Climbfind Rep</a></li>
            <li><a href="#LinkToClimbfindDetail" class="boxy" title="Link to Climbfind">Link to Climbfind</a></li>
            <li><a href="#ShowOurLogoDetail" class="boxy" title="Show our logo on your site">Show our logo on your site</a></li>
            <li><a href="#PartnerPageDetail" class="boxy" title="Set up a Partner Page">Set up a Partner Page</a></li>            
            <%-- <li><a href="#">Host Climbfind Partner Nights</a></li>
            <li><a href="#">Displayed Cards</a></li>
            <li><a href="#">Display Posters</a></li>--%>
            <li><a href="#FacebookTwitterDetail" class="boxy" title="Set up a Partner Page">Expose Data to facebook/twitter</a></li>
        </ul>

        <link rel="Stylesheet" href="/css/cf.boxy.css" type="text/css" />
        <script type='text/javascript' src='/js/jquery.boxy.js'></script>
        <script type="text/javascript">
            $().ready(function () {
                $(".hBoxy").hide();
                $(".boxy").boxy({ modal: true });

            });

        </script>   

        <div id="IntroduceDetail" class="hBoxy">
            <p>Send us at email at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a> 
            and let us know who you are, what you do and what's important to you.</p>
        </div> 

        <div id="SubscribeDetail" class="hBoxy">
             
             
             <form name="ccoptin" action="http://visitor.constantcontact.com/d.jsp" target="_blank" method="post" style="margin-bottom:3">
            
                <div class="inputForm" style="margin:20px;text-align:left;padding:0px 15px 10px 15px">
            
                <label>Email</label>
                <input type="text" name="ea" value="" style="width:180px" />
                
                <hr />
                <input type="submit" name="go" value="Subscribe" class="superButton" />
                <input type="hidden" name="m" value="1103350875862">
                <input type="hidden" name="p" value="oi">
            
                <hr />
                </div>
            </form>
        </div>

        <div id="SubscribeStaffDetail" class="hBoxy" style="width:600px">
            <p>The most likely way that your customers are going to find out about Climbfind is through your staff.</p>
            <p>How often do people come up to your front desk and ask "where can I find someone to climb with".</p>
            <p>Make sure you subscribe ALL your staff to this blog so that they know where to send them!</p>
        </div>
        
        <div id="ClimbfindRepDetail" class="hBoxy" style="width:600px">
            <p>Getting any message to your customers requires time and effort.</p>
            
            <p>We're here to help you help your members and attain the best results with retaining your membership. 
            Assign a staff member (or youself) to be our point of contact and the
            person responsible with promoting our shared mission on your end.</p>

            <p>Once you have got the right person, make sure they get in touch with us at 
            <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>
             and introduce themselve as your CF Rep.</p>
        </div>
        
        <div id="LinkToClimbfindDetail" class="hBoxy" style="width:500px">
            <p>Linking to Climbfind makes our service more visible to climbers browsing the internet. The more people on our site, the more chance your
            customers will find their next climbing partner.</p>

            <p>Include this html snippets on your website:</p>
            <code style="font-size:14px;padding:5px;font-weight:bold">
                <%= Html.Encode("<p>We support the <a href='http://cf3.climbfind.com/' title='Indoor Climbing, Climbing Gym'>Rock Climbing</a> social network www.climbfind.com</p>") %>
            </code>
        </div>

        
        <div id="ShowOurLogoDetail" class="hBoxy" style="width:500px">
            <a href='http://cf3.climbfind.com' title='Rock Climbing'><img title='Find a climbing partner' alt='Climbfind logo' src='/images/ui/logo/climbfind-find-climbing-partner.png' /></a>
            
            <p>Include this html snippets on your website:</p>
            <code style="font-size:14px;padding:5px;font-weight:bold">
                <%= Html.Encode("<a href='http://cf3.climbfind.com' title='Rock Climbing'><img title='Find a climbing partner' alt='Climbfind logo' src='http://cf3.climbfind.com/images/ui/logo/climbfind-find-climbing-partner.png' /></a>") %>
            </code>
        </div>

        <div id="PartnerPageDetail" class="hBoxy" style="width:500px">
            
            <p>The Climbfind <b><a href="/partner-page" target="_blank">Partner Page</a></b> is a way of exporting our live data directly onto your website.</p>

            <p>It dramatically increased the awareness of our service to your customers and makes it directly accessible from your website.</p>
            
            <p>Contact us to get one up and running at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>. </p>
            
        </div>
   
   
        <div id="FacebookTwitterDetail" class="hBoxy" style="width:500px">         
            <p>Give your customers the most visibility possible. We can send partner posts directly to your facebook & twitter pages significantly increasing the chance or helping your customers find partners fast.</p>
            <p>Contact us to set up facebook & twitter integration at <a href="mailto:%63%6F%6E%74%61%63%74%40%63%6C%69%6D%62%66%69%6E%64%2E%63%6F%6D">&#99;&#111;&#110;&#116;&#97;&#99;&#116;&#64;&#99;&#108;&#105;&#109;&#98;&#102;&#105;&#110;&#100;&#46;&#99;&#111;&#109;</a>.</p>
        </div>     

    </div>

</asp:Content>
