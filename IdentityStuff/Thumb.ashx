<%@ WebHandler Language="C#" Class="ClimbFind.Content.Handlers.ImageThumbnailHandler" %>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections.Generic;
using ClimbFind.Model.Enum;
using ClimbFind.Controller;

namespace ClimbFind.Content.Handlers
{


public class ImageThumbnailHandler : IHttpHandler
{       
    private Regex _nameValidationExpression = new Regex(@"[^\w/]");   
    
    /// <summary>
    /// IsReusable is a propery of IHttpHandler
    /// </summary>
    public bool IsReusable { get { return true; } }
    
    protected HttpContext httpCtx { get; set; }
    protected ImageType imageType { get; set; }
    protected string fullWebPath { get; set; }
    protected string objectDir { get; set; }
    protected string imageName { get; set; }
    protected int thumbnailSize { get; set; }
    protected int width { get; set; }
    protected int height { get; set; }
    protected string imageFileName;
    protected string fileWebPath;
    protected string cachedFileWebPath;

    
    /// <summary>
    /// ProcessRequest is the method we have to implement for IHttpHandler
    /// </summary>
    public void ProcessRequest(HttpContext context)
    {
        httpCtx = context;
        
        imageType = GetImageType();              
        imageFileName = GetImageFileName();
       
        fullWebPath = GetWebDirectory();

        fileWebPath = string.Format(@"{0}\{1}", fullWebPath, imageFileName);
        cachedFileWebPath = string.Format(@"{0}\{1}{2}.png", fullWebPath, Path.GetFileNameWithoutExtension(imageFileName), imageType);

        if (!File.Exists(cachedFileWebPath)) 
        {
            ImageManager.SaveResizedThumbnailToDisk(imageFileName, objectDir, imageType); 
        }

        ReturnCachedImageToResponse(cachedFileWebPath);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cachedFilePath"></param>
    private void ReturnCachedImageToResponse(string cachedFilePath)
    {
        //-- Set our cache policy
        OutputCacheResponse(httpCtx, File.GetLastWriteTime(cachedFilePath));

        httpCtx.Response.ContentType = "image/jpeg";
        
        //-- Return our file as the response.
        httpCtx.Response.WriteFile(cachedFilePath);
    }

         
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="lastModified"></param>
    private static void OutputCacheResponse(HttpContext context, DateTime lastModified)
    {
        HttpCachePolicy cachePolicy = context.Response.Cache;
        cachePolicy.SetCacheability(HttpCacheability.Public);
        cachePolicy.VaryByParams["p"] = true;
        cachePolicy.VaryByParams["o"] = true;
        cachePolicy.VaryByParams["t"] = true;
        cachePolicy.SetOmitVaryStar(true);
        cachePolicy.SetExpires(DateTime.Now.AddHours(4));
        cachePolicy.SetValidUntilExpires(true);
        cachePolicy.SetLastModified(lastModified);
    }

    
    
    /// <summary>
    /// 
    /// </summary>
    private ImageType GetImageType()
    {
        ImageType imgType;
        string imageTypeString = httpCtx.Request.QueryString["t"];

        try { imgType = (ImageType)System.Enum.Parse(typeof(ImageType), imageTypeString); }
        catch { throw new HttpException(404, "Photo not found."); }

        return imgType;
    }

    
    private string GetImageFileName()
    {
        //-- TODO: consider alternative safe file name validation.
        
        string imageFilename = httpCtx.Request.QueryString["p"];
        //if (!_nameValidationExpression.IsMatch(imageFilename)) { return imageFilename; }
        //else { throw new HttpException(404, "Invalid photo name."); } 

        if (String.IsNullOrEmpty(imageFilename)) { throw new HttpException(404, "Invalid photo name."); }
        
        return imageFilename;
    }

    
    private string GetWebDirectory()
    {
        try { objectDir = httpCtx.Request.QueryString["o"].ToString(); }
        catch { throw new HttpException(404, "Photo not found."); }

        return string.Format("{0}{1}", CFImageInfo.GetRootOSDirectory(imageType), objectDir);
    }
    
    
}

}