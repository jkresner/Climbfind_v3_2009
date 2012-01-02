<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="m" runat="server">

    <h2>ClimbingTypes</h2>

    <div style="clear:both;margin:0px 0px 10px 0px">        
        <img src="/images/UI/cf/TopRope.bmp" alt="Top rope" style="float:left;margin:0px 10px 10px 0px" />
        <p style="margin:0px;padding:0px"><b>Top ropeing</b> is when you climb tied into a rope that is threaded through 
        a device at the top of the route. As you climb, your partner pulls the slack on the rope so you can't fall.
         Top ropeing is good for beginners. </p>
    </div>

    <div style="clear:both;margin:10px 0px 10px 0px">
        <img src="/images/UI/cf/Lead.bmp" alt="Lead" style="float:left;margin:0px 10px 10px 0px"  />
        <p style="margin:0px;padding:0px"><b>Lead climbing</b> is when you are tied into a rope that you take up and "clip in"
        to karabiners as you climb up the route. Lead climbing is usually for advanced climbers.</p> 
    </div>
     
    <div style="clear:both;margin:0px 0px 10px 0px">
        <img src="/images/UI/cf/Boulder.bmp" alt="Boulder" style="float:left;margin:0px 10px 10px 0px"  />
        <p style="margin:0px;padding:0px"><b>Bouldering</b> is when you climb with no ropes or equiptment. The climbs are
         much shorter and usually more difficult than full length routes. Bouldering is for climbers of all levels.</p>
    </div>

    <div style="clear:both;margin:0px 0px 10px 0px">
        <img src="/images/UI/cf/Trad.bmp" alt="Trad" style="float:left;margin:0px 10px 10px 0px"  />
        <p style="margin:0px;padding:0px"><b>Trad</b> is like lead climbing except instead of having preplace quick draws, you have to
        create your own anchor points with gear like nuts and cams.</p>
    </div>

    <div style="clear:both;margin:0px 0px 10px 0px">
        <img src="/images/UI/cf/Alpine.bmp" alt="Alpine" style="float:left;margin:0px 10px 10px 0px"  />
        <p style="margin:0px;padding:0px"><b>Alpine climbing</b> is long distance terrain climbing. It can include ice climbing and dry tooling.</p>
    </div>

</asp:Content>
