using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ClimbFind.Controller;

namespace ClimbFind.Content
{
    internal static class ImageResizer
    {
        private static object syncLock = new object();

        //--------------------------------------------------------------------------------//
        /// <summary>
        /// Takes in a temporary image and width and height dimensions. If the temp image
        /// exceeds either the width or height, then the method rescales the image and
        /// saves a new copy into saveTo
        /// </summary>
        /// <param name="originalImgName">Name of the image that the user supplied
        /// i.e. the one that has not been re-sized</param>
        /// <param name="newImgDest">The new img dest.</param>
        /// <param name="desiredWidth">Width of the desired.</param>
        /// <param name="desiredHeight">Height of the desired.</param>
        /// <returns>Float which represents the resizing</returns>
        /// <note>* Firefox takes just the name of the image where as IE takes the whole path</note>
        //--------------------------------------------------------------------------------//

        public static float SaveCorrectlySizedImage(string originalImgSrc,
                                string newImgDest, int desiredWidth, int desiredHeight)
        {
            float wPercent = 0, hPercent = 0, resize = 1;

            lock (syncLock)
            {
                using (Bitmap originalBitmap = new Bitmap(originalImgSrc))
                {
                    float imgWidth = originalBitmap.Width, imgHeight = originalBitmap.Height;

                    //If width needs to be scales down, get scaling percentage
                    if (imgWidth > desiredWidth) { wPercent = desiredWidth / imgWidth; }

                    //If height needs to be scales down, get scaling percentage
                    if (imgHeight > desiredHeight) { hPercent = desiredHeight / imgHeight; }

                    //Get the smaller scale down percentage of the two
                    if (wPercent != 0) { resize = wPercent; }
                    if (hPercent != 0)
                    {
                        if (wPercent == 0) { resize = hPercent; }
                        else if (hPercent < wPercent) { resize = hPercent; }
                    }

                    //If no need to resize just copy the original image    
                    if (resize == 1) { File.Copy(originalImgSrc, newImgDest, true); }

                    //Else resize and save the new image
                    else { SaveResizedImage(originalBitmap, newImgDest, resize); }

                    //-- Attempt to Stop generic GDI+ exception
                    GC.Collect();
                }    
            }

            return (resize);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalBitmap"></param>
        /// <param name="imgDest"></param>
        /// <param name="resize"></param>
        /// <returns></returns>
        private static float SaveResizedImage(Bitmap originalBitmap, string imgDest, float resize)
        {
            string tempSrc = "";

            int newWidth = (int)(originalBitmap.Width * resize);
            int newHeight = (int)(originalBitmap.Height * resize);

            tempSrc = CFSettings.OSTempImgDir + "scale" + (new Guid()).ToString();

            //Use low quality for large images
            if (newWidth > 250 || newHeight > 250)
            {
                using (Bitmap resizedBitmap = new Bitmap(originalBitmap, newWidth, newHeight))
                {
                    resizedBitmap.Save(tempSrc, ImageFormat.Jpeg);
                }
            }
            else
            {
                using (Bitmap resizedBitmap = new Bitmap(newWidth, newHeight))
                {
                    //Image thumbnail = resizedBitmap;
                    using (Graphics graphic = Graphics.FromImage(resizedBitmap))
                    {
                        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphic.SmoothingMode = SmoothingMode.HighQuality;
                        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphic.CompositingQuality = CompositingQuality.HighQuality;

                        graphic.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);

                        //Use hight quality for small images
                        ImageCodecInfo[] Info = ImageCodecInfo.GetImageEncoders();
                        using (EncoderParameters Params = new EncoderParameters(1))
                        {
                            Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                            resizedBitmap.Save(tempSrc, Info[1], Params);
                        }
                    }
                }
            }


            //File.Copy is used on top of Bitmap.Save to ensure if the old file was
            //of the same name and exception doesn't occur.

            //Perhaps there is a better way of doing this all since this approach is
            //quite bad for performance...

            File.Copy(tempSrc, imgDest, true); //Always overwrites old file
            File.Delete(tempSrc);

            return (resize);
        }
    }
    
}
