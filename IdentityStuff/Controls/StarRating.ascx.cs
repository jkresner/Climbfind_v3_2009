using System;

namespace IdentityStuff.Controls
{
    public partial class StarRating : System.Web.Mvc.ViewUserControl
    {
        //private bool _showAmountOfFeedback;
        //private int _amountOfFeedback;

        //public bool ShowAmountOfFeedback
        //{
        //    set
        //    {
        //        _showAmountOfFeedback = value;
        //        AmountOfFeedbackStringLtr.Visible = _showAmountOfFeedback;
        //    }
        //    get { return (_showAmountOfFeedback); }
        //}

        public double Rating { get; set; }

        //public int AmountOfFeedback
        //{
        //    set
        //    {
        //        _amountOfFeedback = value;
        //        RImg.Visible = (_amountOfFeedback != 0);
        //        AmountOfFeedbackStringLtr.Text = getAmountOfFeedbackString(_amountOfFeedback);
        //    }
        //    get
        //    {
        //        return (_amountOfFeedback);
        //    }
        //}

        //--------------------------------------------------------------------------------//

        protected string getAmountOfFeedbackString(int amountOfFeedback)
        {
            if (amountOfFeedback == 0) { return ("Not yet rated"); }
            else { return (String.Format("&nbsp by {0:G} user{1}", amountOfFeedback, getPlural(amountOfFeedback))); }
        }

        //--------------------------------------------------------------------------------//

        public static string getPlural(int number)
        {
            if (number > 1) { return ("s"); }
            return ("");
        }

        //--------------------------------------------------------------------------------//

        public string ImageRatingUrl
        {
            get
            {
                if (Rating > 4.75) { return ("/images/UI/ratings/five.bmp"); }
                else if (Rating > 4.25) { return ("/images/UI/ratings/fournhalf.bmp"); }
                else if (Rating > 3.75) { return ("/images/UI/ratings/four.bmp"); }
                else if (Rating > 3.25) { return ("/images/UI/ratings/threenhalf.bmp"); }
                else if (Rating > 2.75) { return ("/images/UI/ratings/three.bmp"); }
                else if (Rating > 2.25) { return ("/images/UI/ratings/twonhalf.bmp"); }
                else if (Rating > 1.75) { return ("/images/UI/ratings/two.bmp"); }
                else if (Rating > 1.25) { return ("/images/UI/ratings/onenhalf.bmp"); }
                else if (Rating > 0.75) { return ("/images/UI/ratings/one.bmp"); }
                else if (Rating > 0.25) { return ("/images/UI/ratings/half.bmp"); }
                else { return ("/images/UI/ratings/zero.bmp"); }
            }        
        }
    }
}
