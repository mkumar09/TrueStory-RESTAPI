namespace RestApi.Utils
{
    public class Constants
    {
        public static readonly HashSet<string> SMARTPHONE = new HashSet<string> { "phone", "iphone", "pixel", "galaxy", "smartphone" };
        public static readonly HashSet<string> SMARTWATCH = new HashSet<string> { "watch", "smartwatch", "fitbit", "garmin", "apple watch" };
        public static readonly HashSet<string> LAPTOP = new HashSet<string> { "laptop", "notebook", "ultrabook", "macbook", "surface" };
        public static readonly HashSet<string> TABLET = new HashSet<string> { "tablet", "ipad", "galaxy tab", "surface pro", "kindle" };
        public static readonly HashSet<string> HEADPHONE = new HashSet<string> { "headphones", "earbuds", "airpods", "beats", "sony" };
        public static readonly string[] REQUIRED_FIELDS_SMARTPHONE = new string[] { "color", "capacity" };
        public static readonly string[] REQUIRED_FIELDS_SMARTWATCH = new string[] { "strap colour", "case size" };
        public static readonly string[] REQUIRED_FIELDS_LAPTOP = new string[] { "year", "cpu model", "price", "hard disk size" };
        public static readonly string[] REQUIRED_FIELDS_TABLET = new string[] { "screen size", "capacity" };
        public static readonly string[] REQUIRED_FIELDS_HEADPHONE = new string[] { "color", "description" };
    }
}
