using ClimbFind.Content;
using ClimbFind.Model.Enum;
using LinqToSql_Feedback = ClimbFind.Model.LinqToSqlMapping.Feedback;

namespace ClimbFind.Model.Objects
{
    public partial class Feedback : LinqToSql_Feedback
    {
        public string FeedbackName { get; set; }
        public string FeedbackEmail { get; set; }
        public string FeedbackProfileImageFile { get; set; }


        public string FeedbackProfileImageUrl
        {
            get
            {
                return ImageManager.GetThumnailUrl(UserID, FeedbackProfileImageFile, ImageType.CPinMB);
            }
        }

    }
}

