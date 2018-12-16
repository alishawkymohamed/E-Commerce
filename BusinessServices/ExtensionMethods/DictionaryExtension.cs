using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.ExtensionMethods
{
    public static class DictionaryExtension
    {
        public static T GetValue<T>(this Dictionary<string, object> args, string key)
        {
            object value = args.Where(x => x.Key == key).Select(x => x.Value).FirstOrDefault();

            Type t = typeof(T);

            if (t.IsConstructedGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t);
        }
    }
}