using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using System.Collections.Generic;

namespace ClimbFind.Helpers
{
    public static class CFExtensions
    {
        public static bool ContainsCaseInsensitive(this string source, string value)
        {
            int results = source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
            return results == -1 ? false : true;
        }


        /// <summary>
        /// Guid methods
        /// </summary>
        public static string GetGuidPathString(this Guid guid)
        {
            return guid.ToString().Substring(0, 3);
        }

        /// <summary>
        /// Decimal methods
        /// </summary>
        public static string GetNoTrailingZerosString(this decimal number)
        {
            if (number == 0) { return "0"; }
            string numberString = number.ToString();
            while (numberString.EndsWith("0")) { numberString = numberString.Substring(0, numberString.Length-1); }
            if (numberString.EndsWith(".")) { numberString = numberString.Substring(0, numberString.Length - 1); }
            return numberString;
        }
        
        

        
        /// <summary>
        /// Date Helpers / formatting
        /// </summary>
        public static string ToCFDateString(this DateTime dateTime)
        {
            return dateTime.ToString("ddd dd MMM");
        }


        public static string ToCFDateAndTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("hh:mm tt ddd dd MMM");
        }


        public static string GetDaysToGoString(this DateTime dateTime)
        {
            TimeSpan timeUntilParty = dateTime.Subtract(DateTime.Now);
            if (timeUntilParty.Days > 1) { return (String.Format("{0} days to go", timeUntilParty.Days.ToString())); }
            else if (timeUntilParty.Days == 1) { return ("Tomorrow"); }
            else if (timeUntilParty.Days == 0) { return ("Today"); }
            else if (timeUntilParty.Days == -1) { return ("Yesterday"); }
            else { return (String.Format("{0} days ago", (-1 * timeUntilParty.Days).ToString())); }
        }


        public static string GetAgoString(this DateTime dateTime)
        {
            TimeSpan timeAfter = DateTime.Now.Subtract(dateTime);
            if (timeAfter.Days == 1) { return ("1 day ago"); }
            else if (timeAfter.Days > 1) { return (String.Format("{0:G} days ago", timeAfter.Days)); }
            else if (timeAfter.Hours == 1) { return ("1 hour ago"); }
            else if (timeAfter.Hours > 1) { return (String.Format("{0:G} hours ago", timeAfter.Hours)); }
            else if (timeAfter.Minutes <= 1) { return ("1 minute ago"); }
            else { return (String.Format("{0:G} minutes ago", timeAfter.Minutes)); }
        }


        public static string ConvertIntToDate(int day)
        {
            string lastDigit = day.ToString().Substring(day.ToString().Length - 1, 1);

            if (day.ToString() == "11") { return (day.ToString() + "th"); }
            if (day.ToString() == "12") { return (day.ToString() + "th"); }
            if (day.ToString() == "13") { return (day.ToString() + "th"); }

            if (lastDigit == "1") { return (day.ToString() + "st"); }
            else if (lastDigit == "2") { return (day.ToString() + "nd"); }
            else if (lastDigit == "3") { return (day.ToString() + "rd"); }
            else { return (day.ToString() + "th"); }
        }


        /// <summary>
        /// String helpers
        /// </summary>

        public static string Take(this string value, int length)
        {
            if (value.Length < length) { return value; }
            else { return value.Substring(0, length - 1); }
        }

        public static string RemoveNewLines(this string input)
        {
            if (input == "") { return (""); }
		 
            Regex RemoveNewLinesRX = new Regex(@"[\r|\n]", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            return RemoveNewLinesRX.Replace(input, string.Empty);
        }


        public static string RemoveSpaces(this string input)
        {
            return (input.Replace(" ", ""));
        }

       
        public static string RemoveSpecialChars(this string input)
        {
            return (input.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("'", "").Replace("&", ""));
        }

        public static string RemoveSpecialCharsExcludingSpaces(this string input)
        {
            return (input.Replace("_", "").Replace("-", "").Replace("'", "").Replace("&", "")).Trim();
        }


        private static string upperCaseMatch(Match match)
        {
            return match.Value.ToUpper();
        }
 

        public static string CapitalizeWordsInString(this string words)
        {
            Regex CapitalizeWordsRX = new Regex(@"\b\w", RegexOptions.Compiled);

            return (CapitalizeWordsRX.Replace(words, new MatchEvaluator(upperCaseMatch)));
        }


        /// <summary>
        /// Bool helper
        /// </summary>

        public static string ToYesNo(this bool boolean)
        {
            if (boolean) { return ("Yes"); }
            return ("No");
        }

        public static string ToYesNo(this bool? boolean)
        {
            if (!boolean.HasValue) { return ("Unknown"); }
            else if (boolean.Value) { return ("Yes"); }
            else return ("No");
        }

        //--------------------------------------------------------------------------------//
        //- Misc Methods -----------------------------------------------------------------//
        //--------------------------------------------------------------------------------//		


        public static int GetRandomNumber(int floor, int ceiling)
        {
            Random randomGenerator = new Random(DateTime.Now.Millisecond);
            return (randomGenerator.Next(floor, ceiling));
        }



        public static string GetFriendUrlFromString(this string s)
        {
            s = s.RemoveSpaces();
            string friendly = s[0].ToString().ToLower();

            for (int i = 1; i < s.Length; i++)
            {
                if (Char.IsLower(s[i])) { friendly += s[i]; }
                else { friendly += "-" + s[i].ToString().ToLower(); }
            }

            return friendly;
        }

        public static string GetFriendlyUrlName(this string s)
        {
            return s.Trim().ToLower().Replace("'", "").Replace(" ", "-");
        }


        public static string GetCountryFriendlyUrl(this Nation nation)
        {
            string p = nation.ToString();
            
            string friendlyCountry = p[0].ToString().ToLower();

            for (int i = 1; i < p.Length; i++)
            {
                if (Char.IsLower(p[i])) { friendlyCountry += p[i]; }
                else { friendlyCountry += "-" + p[i].ToString().ToLower(); }
            }

            return friendlyCountry;
        }

        

        public static Nation GetNationFromFriendCountryUrl(this string countryUrl)
        {
            string nationString = countryUrl[0].ToString().ToUpper();

            for (int i = 1; i < countryUrl.Length; i++)
            {
                if (countryUrl[i] == '-') { nationString += countryUrl[i + 1].ToString().ToUpper(); i++; }
                else { nationString += countryUrl[i].ToString(); }
            }

            try { return (Nation)Enum.Parse(typeof(Nation), nationString); }
            catch { return Nation.Unknown; }
        }

        public static string GetHtmlParagraph(this string text)
        {
            if (text == null) { return (""); }
            if (text == "") { return (""); }

            text = HttpUtility.HtmlEncode(text);

            string replace = "<br />";

            string tempStringOne = ieTextBoxReplace.Replace(text, replace);
            string tempStringTwo = ffTextBoxReplace.Replace(tempStringOne, replace);

            return (tempStringTwo);
        }

        private static readonly Regex ieTextBoxReplace = new Regex(Environment.NewLine, RegexOptions.Compiled);
        private static readonly Regex ffTextBoxReplace = new Regex("\n", RegexOptions.Compiled);


        public static List<PartnerCall> GetDistinctUserCalls(this List<PartnerCall> list)
        {
            return list.Distinct(new PartnerCallUserComparer()).ToList(); 
        }

        public static List<PartnerCall> GetDistinctPlaceCalls(this List<PartnerCall> list)
        {
            return list.Distinct(new PartnerCallPlacesComparer()).ToList();
        }

        public static bool HasSamePlaces(this PartnerCall c1, PartnerCall c2)
        {
            return new PartnerCallPlacesComparer().Equals(c1, c2);
        }

        private class PartnerCallUserComparer : IEqualityComparer<PartnerCall>
        {
            public bool Equals(PartnerCall x, PartnerCall y) { return x.CreatorUserID == y.CreatorUserID; }
            public int GetHashCode(PartnerCall obj) { return obj.CreatorUserID.GetHashCode(); }
        }

        private class PartnerCallPlacesComparer : IEqualityComparer<PartnerCall>
        {
            public bool Equals(PartnerCall x, PartnerCall y)
            {
                if (x.PlaceIDs.Count != y.PlaceIDs.Count) { return false; }
                else
                {
                    foreach (int id in x.PlaceIDs) { if (!y.PlaceIDs.Contains(id)) { return false; } }
                    return true;
                }
            }
            public int GetHashCode(PartnerCall obj) { return obj.CreatorUserID.GetHashCode(); }
        }

}
}

