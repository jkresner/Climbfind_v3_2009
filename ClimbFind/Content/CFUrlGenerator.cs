
namespace ClimbFind.Content
{
    public class CFUrlGenerator
    {
        public static string GetIndoorPlaceUrl(string friendlyUrlLocation, string friendlyUrlName)
        {
            return GetPlaceUrl(true, friendlyUrlLocation, friendlyUrlName);
        }

        public static string GetOutdoorPlaceUrl(string friendlyUrlLocation, string friendlyUrlName)
        {
            return GetPlaceUrl(false, friendlyUrlLocation, friendlyUrlName);
        }

        public static string GetOutdoorCragUrl(string friendlyUrlLocation, string friendlyUrlPlaceName, string friendlyUrlCragName)
        {
            return GetPlaceUrl(false, friendlyUrlLocation, friendlyUrlPlaceName) + "/" + friendlyUrlCragName;
        }      

        public static string GetPlaceUrl(bool IsIndoor, string friendlyUrlLocation, string friendlyUrlName)
        {
            if (IsIndoor) { return string.Format("/places/indoor-rock-climbing-gyms/{0}/{1}", friendlyUrlLocation, friendlyUrlName); }
            else { return string.Format("/places/outdoor-rock-climbing/{0}/{1}", friendlyUrlLocation, friendlyUrlName); }
        }

        public static string GetPlaceRegularsUrl(bool IsIndoor, string friendlyUrlLocation, string friendlyUrlName)
        {
            return string.Format("/all-regular-climbers/{0}/{1}", friendlyUrlLocation, friendlyUrlName);
        }
    }
}
