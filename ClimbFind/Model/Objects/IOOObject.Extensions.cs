using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.Objects
{
    /// <summary>
    /// Extension helpers methods for SSRObjects
    /// </summary>
    public static partial class ClimbFindObjectExtensionMethods
    {
        /// <summary>
        /// GetProperyNameAndValues uses reflection to return a collection of
        /// an objects Simple Type (String or ValueType) properties and values.
        /// </summary>
        /// <param name="o"></param>
        /// <returns>NameValueCollection of an objects properties and associated values</returns>
        public static NameValueCollection GetProperyNameAndValues(this IOOObject o)
        {
            Type objType = o.GetType();
            PropertyInfo[] fields = objType.GetProperties();
            NameValueCollection nvCollection = new NameValueCollection();

            foreach (PropertyInfo property in fields)
            {
                if (property.PropertyType == typeof(string) ||
                    property.PropertyType.BaseType == typeof(ValueType))
                {
                    if (property.GetValue(o, null) != null)
                    {
                        nvCollection.Add(property.Name, property.GetValue(o, null).ToString());
                    }
                }
            }

            return nvCollection;
        }

        /// <summary>
        /// ToFriendlyHTMLString (ONLY TO BE USED FOR DEBUGGING PUPOSES PLEASE)!
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Unordered HTML list of properties and values of an object</returns>
        public static string ToFriendlyHTMLString(this IOOObject o)
        {
            StringBuilder sb = new StringBuilder("<ul>");
            NameValueCollection nvCollection = GetProperyNameAndValues(o);

            foreach (string key in nvCollection.Keys)
            {
                sb.AppendFormat("<li>{0}: {1}</li>", key, nvCollection[key]);
            }

            sb.Append("</ul>");

            return sb.ToString();   
        }


        /// <summary>
        /// http://www.codeproject.com/KB/linq/linqrandomsample.aspx
        /// </summary>
        public static List<T> RandomSample<T>(this IEnumerable<T> source, int count)
        {
            return RandomSampleIterator<T>(source, count, -1, false).ToList();
        }

        public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> source, int count, int seed,
           bool allowDuplicates)
        {
            return RandomSampleIterator<T>(source, count, seed,
                allowDuplicates);
        }

        static IEnumerable<T> RandomSampleIterator<T>(IEnumerable<T> source,
            int count, int seed, bool allowDuplicates)
        {
            // take a copy of the current list
            List<T> buffer = new List<T>(source);

            // create the "random" generator, time dependent or with 
            // the specified seed
            Random random;
            if (seed < 0)
                random = new Random();
            else
                random = new Random(seed);

            count = Math.Min(count, buffer.Count);

            if (count > 0)
            {
                // iterate count times and "randomly" return one of the 
                // elements
                for (int i = 1; i <= count; i++)
                {
                    // maximum index actually buffer.Count -1 because 
                    // Random.Next will only return values LESS than 
                    // specified.
                    int randomIndex = random.Next(buffer.Count);
                    yield return buffer[randomIndex];
                    if (!allowDuplicates)
                        // remove the element so it can't be selected a 
                        // second time
                        buffer.RemoveAt(randomIndex);
                }
            }
        }

    }
}
