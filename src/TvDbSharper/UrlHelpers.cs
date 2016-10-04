namespace TvDbSharper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class UrlHelpers
    {
        public static string Parametrify(Enum value)
        {
            var elements = value.ToString().Split(',').Select(element => PascalCase(element.Trim())).OrderBy(element => element);

            return string.Join(",", elements);
        }

        public static string Querify<T>(T obj)
        {
            IList<string> parts = new List<string>();

            foreach (var propertyInfo in typeof(T).GetProperties().OrderBy(info => info.Name))
            {
                object value = propertyInfo.GetValue(obj);

                if (value != null)
                {
                    parts.Add($"{PascalCase(propertyInfo.Name)}={Uri.EscapeDataString(value.ToString())}");
                }
            }

            return string.Join("&", parts);
        }

        private static string PascalCase(string name)
        {
            char[] array = name.ToCharArray();

            array[0] = char.ToLower(array[0]);

            return new string(array);
        }
    }
}