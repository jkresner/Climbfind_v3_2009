using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_Feedback = ClimbFind.Model.LinqToSqlMapping.Feedback;


namespace ClimbFind.Model.DataAccess
{
    public class FeedbackDA : AbstractBaseDA<Feedback, LinqToSql_Feedback, int>
    {
        /// <summary>
        /// Combines info from the user to the feedback so can display nicely in a list view
        /// </summary>
        protected override Feedback MapLinqTypeToOOType(LinqToSql_Feedback o)
        {
            Feedback o2 = new Feedback();
            MapValues(o2, o.GetProperyNameAndValues());

            ClimberProfile cp = new ClimberProfileDA(ctx).GetByID(o.UserID);

            o2.FeedbackName = cp.FullName;
            o2.FeedbackProfileImageFile = cp.ProfilePictureFile;

            return (o2);
        }

        /// <summary>
        /// Returns a list of Feedback that has been reviewed by the admin to be displayed to the public.
        /// </summary>
        public List<Feedback> GetAllPublishedFeedback()
        {
            return MapList((from c in EntityTable where c.Published select c).ToList());
        }
    }

}
