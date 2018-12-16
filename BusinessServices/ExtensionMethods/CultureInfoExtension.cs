using System.Globalization;

namespace BusinessServices.ExtensionMethods
{
    public static class CultureInfoExtension
    {
        public static bool IsArabic(this CultureInfo cultureInfo)
        {
            return cultureInfo.TwoLetterISOLanguageName.ToString().StartsWith("ar");
        }
    }
}