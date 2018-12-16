using System;

namespace BusinessServices.ExtensionMethods
{
    internal static class DateTimeExtensions
    {
        public static DateTime? Max(this DateTime? Date1, DateTime? Date2)
        {
            if (!Date1.HasValue && !Date2.HasValue) return null;
            if (!Date1.HasValue) return Date2;
            if (!Date1.HasValue) return Date1;

            return Date1.Value > Date2.Value ? Date1 : Date2;
        }
    }
}
