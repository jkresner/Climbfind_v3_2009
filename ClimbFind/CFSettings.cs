using System.Configuration;
using System.Net.Mail;

namespace ClimbFind.Controller
{
    public static class CFSettings
    {
        /// <summary>
        /// Private members
        /// </summary>
        private static SmtpClient _mailServer;
        private static MailAddress _mailMan, _appAdmin, _kev, _james;
        private static string _osRootDir, _osTempImgDir, _osClimberProfilePicImgDir, _osIndoorPlaceLogoImgDir,
                            _osGroupProfilePicImgDir, _osOutdoorPlaceProfilePicImgDir, _osClubLogoLogoImgDir,
                            _osOutdoorCragProfilePicImgDir;
        private static string _webAddress;

        /// <summary>
        /// Public properties
        /// </summary>
        public static SmtpClient MailServer { get { return _mailServer; } }
        public static MailAddress MailMan { get { return _mailMan; } }
        public static MailAddress AppAdmin { get { return _appAdmin; } }
        public static MailAddress Kev { get { return _kev; } }
        public static MailAddress James { get { return _james; } }

        public static string OSRootDir { get { return _osRootDir; } }
        public static string OSTempImgDir { get { return _osTempImgDir; } }
        public static string OSClimberProfilePicImgDir { get { return _osClimberProfilePicImgDir; } }
        public static string OSGroupProfilePicImgDir { get { return _osGroupProfilePicImgDir; } }
        public static string OSOutdoorPlaceProfilePicImgDir { get { return _osOutdoorPlaceProfilePicImgDir; } }
        public static string OSOutdoorCragProfilePicImgDir { get { return _osOutdoorCragProfilePicImgDir; } }
     
        
        public static string OSIndoorPlaceLogoImgDir { get { return _osIndoorPlaceLogoImgDir; } }
        public static string OSClubLogoLogoImgDir { get { return _osClubLogoLogoImgDir; } }       
        public static string WebAddress { get { return _webAddress; } }

        public static string WebRootImageDirectory { get { return _webAddress + "images/"; } }
        public static string WebClimberProfilePicImgDir { get { return WebRootImageDirectory + "users/profiles/main/"; } }
       
        public static bool IsDevelopmentEnvironment { get { return System.Environment.MachineName == "JONATHON-PC"; } }

        /// <summary>
        /// Constructor to initialise the values of all the properties.
        /// </summary>
        static CFSettings()
        {
            _mailServer = new SmtpClient();
            _mailMan = new MailAddress(
                ConfigurationManager.AppSettings["MailManAddress"],
                ConfigurationManager.AppSettings["MailManName"]);

            _appAdmin = new MailAddress("jkresner@yahoo.com.au", "Jonathon Kresner");

            _osRootDir = ConfigurationManager.AppSettings["OSRootDirectory"];
            _osTempImgDir = _osRootDir + ConfigurationManager.AppSettings["OSTemporaryImageDirectory"];
            _osClimberProfilePicImgDir = _osRootDir + @"images\users\profiles\main\";
            _osOutdoorPlaceProfilePicImgDir = _osRootDir + @"images\places\outdoor-rock-climbing\main\";
            _osOutdoorCragProfilePicImgDir = _osRootDir + @"images\places\outdoor-rock-climbing\crags\";
            _osIndoorPlaceLogoImgDir = _osRootDir + @"images\places\indoor-rock-climbing\logos\";
            _osClubLogoLogoImgDir = _osRootDir + @"images\clubs\logos\";

            _webAddress = ConfigurationManager.AppSettings["WebAddress"]; 
        }


        /// <summary>
        /// GetConfig is a returns a configuration value for a specified config element key.
        /// </summary>
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
