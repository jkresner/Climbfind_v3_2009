using System;
using ClimbFind.Content;
using ClimbFind.Model.Enum;


namespace ClimbFind.Model.Objects
{
    public class MessageBoardMessage : ClimbFind.Model.LinqToSqlMapping.MessageBoardMessage
    {
        public Guid PosterUserID { get; set; }
        public string PostersName { get; set; }
        public string ProfilePictureFile { get; set; }
        public string ProfilePictureUrl
        {
            get
            {
                return ImageManager.GetThumnailUrl(PosterUserID, ProfilePictureFile, ImageType.CPinMB);
            }
        }
    }
}
