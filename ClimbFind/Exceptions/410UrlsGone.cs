using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ClimbFind.Exceptions
{
    public sealed class SpecialUrls
    {
        //-- Singleton Stuff
        private static readonly SpecialUrls instance = new SpecialUrls();
        public static SpecialUrls Instance { 
            get { return instance; } }

        public List<string> UrlsGone;
        public Dictionary<string,string> PermanentlyMoved = new Dictionary<string,string>();
               
        private SpecialUrls()
        {
            //-- Every 3 months clear out these links and start again..?
            UrlsGone = new List<string>()
            {
                "/Calendar",
                "/Clubs/About",
                "/Climbers-Noticeboard",
                "/climbing-jobs",
                "/css/cf.css",
                "/css/cf2.56.css",
                "/css/cf3.0a.css",
                "/css/cf3.0b.css",
                "/css/cf3.01.css",
                "/css/cf3.01.css",
                "/css/cf3.02.css",
                "/Groups",
                "/Groups/About",
                "/Groups/New",
                "/Groups/Search",
                "/Home/CF3BetaBrief",
                "/Home/Preferences",
                "/Home/IndexExperimental",
                "/js/CF3b.js",
                "/js/CF3a.js",
                "/js/CF3.5.js",
                "/js/CF3.1Home.js",
                "/js/CF3.5Home.js",
                "/js/ClimbFind.js",
                "/js/jquery-1.2.6.js",
                "/js/jquery.cluetip.js",
                "/js/jquery-droppy-menu.js",
                "/js/jquery.dimensions.js",
                "/js/jquery.hoverIntent.js",
                "/News/Castle_2008_Xmas_Party",
                "/News/The_Castle_Presents_Niel_Gresham_Kitty_Wallace_Jack_Griffiths_2008_12_13",
                "/News/SIBL_2008_Indoor_Bouldering_Competition",
                "/News/East_Meets_West_Bouldering_Competition_London_2008_Round_1",
                "/PartnerCalls/MyCalls",
                "/PartnerCalls/Search",
                "/Places/RegularNights",
                "/Places/AllPlaceRegulars",
                "/post-a-climbing-club-trip-meet",
                "/Products",
                "/Products/",
                "/Products/Guided_Outdoor_Rock_Climbing",
                "/Products/Books",
                "/Products/DVDs",
                "/Products/Private_Climbing_Instruction",
                "/Products/BooktopiaAdClick?bookName=Advanced%20Rock%20Climbing%20:%20A%20Step-By-Step%20Guide%20to%20Improving%20Skills&isbn=1844765369",
                "/Products/BooktopiaAdClick?bookName=Bouldering%20Colorado&isbn=0762736380",
                "/Products/BooktopiaAdClick?bookName=Crack%20Climbing!&isbn=0762745916",
                "/Products/BooktopiaAdClick?bookName=Climber's%20Guide%20to%20Devil's%20Lake&isbn=0299228541",
                "/Products/BooktopiaAdClick?bookName=Everyday%20Masculinities%20and%20Extreme%20Sport%20:%20Male%20Identity%20and%20Rock%20Climbing&isbn=184520137X",
                "/Products/BooktopiaAdClick?bookName=First%20Ascent&isbn=1844035964",
                "/Products/BooktopiaAdClick?bookName=Girl%20on%20the%20Rocks&isbn=0762745185",
                "/Products/BooktopiaAdClick?bookName=Mountaineering&isbn=0713686928",
                "/Products/BooktopiaAdClick?bookName=The%20Complete%20Guide%20to%20Climbing%20and%20Mountaineering&isbn=0715328441",
                "/Products/BooktopiaAdClick?bookName=Rock%20Climbing%20Calendar&isbn=1595437584",
                "/PopCalendar2008/CSS/Classic.css",
                "/PopCalendar2008/PopCalendarFunctionsAjaxNet.js",
                "/post-an-add-for-rock-climbing-partners",
                "/RoadTrip/Sponsors",
                "/Trips",
            };                     

            PermanentlyMoved.Add("/Glossary/GradeConverter", "/Climbing-Grade-Comparison-Chart-Converter");
            PermanentlyMoved.Add("/pagead/atf.js", "http://googleads.g.doubleclick.net/pagead/atf.js");
            PermanentlyMoved.Add("/pagead/osd.js", "http://googleads.g.doubleclick.net/pagead/osd.js");
            PermanentlyMoved.Add("/pagead/render_ads.js", "http://pagead2.googlesyndication.com/pagead/render_ads.js");
            PermanentlyMoved.Add("/pagead/test_domain.js", "http://googleads.g.doubleclick.net/pagead/test_domain.js");
            PermanentlyMoved.Add("/pagead/expansion_embed.js", "http://pagead2.googlesyndication.com/pagead/expansion_embed.js");

            PermanentlyMoved.Add("/__utm.gif", "http://pagead2.googlesyndication.com/pagead/expansion_embed.js");            
            
        }
    }
    

}
