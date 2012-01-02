using System;
using ClimbFind.Controller;
using ClimbFind.Model.Enum;

namespace ClimbFind.Content
{
    public static class CFImageInfo
    {
        public static string DefaultClimberProfilePicUrl { get { return "/images/users/profiles/main/Default.jpg"; } }
        
        //-- TODO: revise there methods and use a Hashtable instead of if statements.

        public static int GetImageMaxXAxisSize(ImageType type)
        {
            if (type == ImageType.CP) { return 480; }
            if (type == ImageType.CPinPF) { return 220; }
            if (type == ImageType.CPinPS) { return 130; }
            if (type == ImageType.CPinMB) { return 100; }
            if (type == ImageType.GP) { return 480; }
            if (type == ImageType.GPinGD) { return 220; }

            return 20;
        }

        public static int GetImageMaxYAxisSize(ImageType type)
        {
            if (type == ImageType.CP) { return 480; }         
            if (type == ImageType.CPinPF) { return 175; }
            if (type == ImageType.CPinPS) { return 120; }
            if (type == ImageType.CPinMB) { return 100; }
            if (type == ImageType.GP) { return 480; }
            if (type == ImageType.GPinGD) { return 180; }

            return 20;
        }

        public static string GetRootWebDirectory(ImageType type)
        {
            if (type == ImageType.CP) { return CFSettings.WebClimberProfilePicImgDir; }
            if (type == ImageType.CPinPF) { return CFSettings.WebClimberProfilePicImgDir; }
            if (type == ImageType.CPinPS) { return CFSettings.WebClimberProfilePicImgDir; }
            if (type == ImageType.CPinMB) { return CFSettings.WebClimberProfilePicImgDir; }
            else
            {
                throw new Exception(string.Format("Image type [{0}] not supported in GetWebDirecotry", type.ToString()));
            }
        }


        public static string GetRootOSDirectory(ImageType type)
        {
            if (type == ImageType.CP) { return CFSettings.OSClimberProfilePicImgDir; }
            if (type == ImageType.CPinPF) { return CFSettings.OSClimberProfilePicImgDir; }
            if (type == ImageType.CPinPS) { return CFSettings.OSClimberProfilePicImgDir; }
            if (type == ImageType.CPinMB) { return CFSettings.OSClimberProfilePicImgDir; }
            if (type == ImageType.GP) { return CFSettings.OSGroupProfilePicImgDir; }
            if (type == ImageType.GPinGD) { return CFSettings.OSGroupProfilePicImgDir; }
            if (type == ImageType.OPP) { return CFSettings.OSOutdoorPlaceProfilePicImgDir; }
            if (type == ImageType.IPL) { return CFSettings.OSIndoorPlaceLogoImgDir; }
            if (type == ImageType.CL) { return CFSettings.OSClubLogoLogoImgDir; }
            if (type == ImageType.OCP) { return CFSettings.OSOutdoorCragProfilePicImgDir; }
            else
            {
                throw new Exception(string.Format("Image type [{0}] not supported in GetOSDirecotry", type.ToString()));
            }

        }
    }
}
