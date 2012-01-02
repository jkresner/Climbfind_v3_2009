using System;
using System.IO;
using ClimbFind.Controller;

namespace ClimbFind.Content
{
    public static partial class ImageManager
    {     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalImage"></param>
        /// <returns></returns>
        private static string GenerateRandomImgName(string originalImage)
        {
            string fileExtension = Path.GetExtension(originalImage);
            string randomFileName = (Guid.NewGuid()).ToString().Substring(0, 8);

            return (randomFileName + fileExtension);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalImgName"></param>
        /// <param name="fileBytes"></param>
        /// <param name="newImgDest"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
        /// <returns></returns>
        private static float SaveCorrectlySizedImageUpload(string originalImgName,
                   byte[] fileBytes, string newImgDest, int desiredWidth, int desiredHeight)
        {
            string tempImgSrc = CFSettings.OSTempImgDir + Path.GetFileName(originalImgName);
           
            try
            {
                //-- 1) First saves the image in memory (from the file upload) to disk so we can use it.
                File.WriteAllBytes(tempImgSrc, fileBytes);

                //-- 2) Create the destination directory if it does not exist
                CreateDestinationDirectoryIfNotExists(newImgDest);

                //-- 3) Let's go ahead and do the resize
                return ImageResizer.SaveCorrectlySizedImage(tempImgSrc, newImgDest, desiredWidth, desiredHeight);
            }
            finally
            {
                File.Delete(tempImgSrc);
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newImgDest"></param>
        private static void CreateDestinationDirectoryIfNotExists(string newImgDest)
        {           
            string destinationDir = newImgDest.Replace(Path.GetFileName(newImgDest), "");
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
        }

    }
    
}
