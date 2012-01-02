using System;
using ClimbFind.Model.Enum;

namespace ClimbFind.Model.Objects
{
    public class MediaShare : ClimbFind.Model.LinqToSqlMapping.MediaShare
    {
        public MediaType MType { get { return (MediaType)base.Type; } }

        public string MediaTypeString 
        { 
            get 
            {
                if (MType == MediaType.FacebookAlbum) { return "Photo album"; }
                else if (MType == MediaType.MSPhotosynth) { return "Photo collection"; }
                else if (MType == MediaType.YouTubeVideo) { return "Movie"; }
                else { return "Unknown"; }
            } 
        }


        public string RenderInBrowser()
        {
            if (MType == ClimbFind.Model.Enum.MediaType.MSPhotosynth)
            {
                return string.Format(@"<iframe frameborder=0 src=""http://{0}"" width=""640"" height=""360""></iframe>", Uri);
            }
            else if (MType == ClimbFind.Model.Enum.MediaType.YouTubeVideo)
            {
                return string.Format(@"<object height=""344""><param name=""movie"" value=""http://www.youtube.com/v/{0}&hl=en&fs=1""></param><param name=""allowFullScreen"" value=""true""></param><embed src=""http://www.youtube.com/v/{0}&hl=en&fs=1"" type=""application/x-shockwave-flash"" allowfullscreen=""true"" width=""425"" height=""344"" wmode=""opaque""></embed></object>", Uri);
            }
            else if (MType == ClimbFind.Model.Enum.MediaType.FacebookAlbum)
            {
                return string.Format(@"<iframe frameborder=0 src=""http://{0}"" width=""660"" height=""540""></iframe>", Uri);
            }
            else
            {
                throw new Exception(string.Format("{0} not supported", this.Type));
            }
        }
    }
}
