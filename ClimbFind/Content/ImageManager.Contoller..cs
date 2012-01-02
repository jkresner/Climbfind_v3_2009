using System;
using System.IO;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;

namespace ClimbFind.Content
{
    public static partial class ImageManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalImgPath"></param>
        /// <param name="resizedImgPath"></param>
        /// <param name="imageType"></param>
        public static void SaveResizedThumbnailToDisk(string imageName, string objectIDPath, ImageType imageType)
        {
            string originalImgOSPath = string.Format(@"{0}{1}\{2}",
                CFImageInfo.GetRootOSDirectory(imageType), objectIDPath, imageName);

            string resizedImgOSPath = string.Format(@"{0}{1}\{2}{3}.png",
                CFImageInfo.GetRootOSDirectory(imageType), objectIDPath, Path.GetFileNameWithoutExtension(imageName), imageType);

            ImageResizer.SaveCorrectlySizedImage(originalImgOSPath, resizedImgOSPath,
                    CFImageInfo.GetImageMaxXAxisSize(imageType), CFImageInfo.GetImageMaxYAxisSize(imageType));
            
        }        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageFileName"></param>
        /// <param name="imageBytes"></param>
        /// <param name="objectID"></param>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public static string SaveRawTypeImage(string imageFileName, byte[] imageBytes, Guid objectID, ImageType imageType)
        {
            string newImageName = ImageManager.GenerateRandomImgName(imageFileName);

            string destinationPath = string.Format("{0}{1}/{2}",
                        CFImageInfo.GetRootOSDirectory(imageType), objectID.GetGuidPathString(), newImageName);

            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, destinationPath, 
                CFImageInfo.GetImageMaxXAxisSize(imageType),
                CFImageInfo.GetImageMaxYAxisSize(imageType));

            return newImageName;
        }

        /// <returns></returns>
        public static string SaveIndoorPlaceLogo(string imageFileName, byte[] imageBytes, int placeID, string friendlyPlaceName)
        {
            string newImageName = string.Format("{0}-{1}", friendlyPlaceName, ImageManager.GenerateRandomImgName(imageFileName));
            string destinationPath = string.Format("{0}/{1}", CFImageInfo.GetRootOSDirectory(ImageType.IPL), newImageName);
            string halfSizedestinationPath = string.Format("{0}/half/{1}", CFImageInfo.GetRootOSDirectory(ImageType.IPL), newImageName);

            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, destinationPath, 230, 500);
            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, halfSizedestinationPath, 90, 80);

            return newImageName;
        }

        public static string SaveClubLogo(string imageFileName, byte[] imageBytes, int clubID, string friendlyClubName)
        {
            string newImageName = string.Format("{0}-{1}", friendlyClubName, ImageManager.GenerateRandomImgName(imageFileName));
            string destinationPath = string.Format("{0}/{1}", CFImageInfo.GetRootOSDirectory(ImageType.CL), newImageName);
            string halfSizedestinationPath = string.Format("{0}/half/{1}", CFImageInfo.GetRootOSDirectory(ImageType.CL), newImageName);

            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, destinationPath, 230, 220);
            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, halfSizedestinationPath, 90, 80);

            return newImageName;
        }

        /// <returns></returns>
        public static string SaveOutdoorPlaceImage(string imageFileName, byte[] imageBytes, int placeID, string friendlyPlaceName)
        {
            string newImageName = string.Format("{0}-{1}", friendlyPlaceName, ImageManager.GenerateRandomImgName(imageFileName));

            string destinationPath = string.Format("{0}/{1}", CFImageInfo.GetRootOSDirectory(ImageType.OPP), newImageName);

            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, destinationPath, 230, 500);

            return newImageName;
        }


        /// <returns></returns>
        public static string SaveOutdoorCragImage(string imageFileName, byte[] imageBytes, Guid cragID, string friendlyCragName)
        {
            string newImageName = string.Format("{0}-{1}", friendlyCragName, ImageManager.GenerateRandomImgName(imageFileName));

            string destinationPath = string.Format("{0}/{1}", CFImageInfo.GetRootOSDirectory(ImageType.OCP), newImageName);

            ImageManager.SaveCorrectlySizedImageUpload(imageFileName, imageBytes, destinationPath, 230, 500);

            return newImageName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="fileName"></param>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public static string GetThumnailUrl(Guid objectID, string fileName, ImageType imageType)
        {
            if (string.IsNullOrEmpty(fileName) || fileName == "Default.jpg") 
            { 
                return string.Format("/images/users/profiles/main/Default{0}.jpg", imageType); 
            }
            
            return string.Format("/thumb.ashx?o={0}&p={1}&t={2}", objectID.GetGuidPathString(), fileName, imageType); 

        }
    }
    
}
