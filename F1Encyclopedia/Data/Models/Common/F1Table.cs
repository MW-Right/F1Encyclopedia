using System;
using System.Collections.Generic;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Common
{
    public class F1Table
    {
        private static string[] PropertiesRequiringForeignKey = new [] {"Nationality", "Country"};
        public static dynamic FromCsv(string[] values, List<string> headers, Object obj, ref string customTypeData)
        {
            for (var i = 0; i < headers.Count(); i++)
            {
                var prop = obj.GetType().GetProperties()
                    .ToList()
                    .FirstOrDefault(y => y.Name == headers.ElementAt(i));

                if (PropertiesRequiringForeignKey.Contains(headers[i]))
                {
                    customTypeData = values[i];
                }
                else if (prop.PropertyType.Namespace.StartsWith("System"))
                {
                    prop.SetValue(obj, Convert.ChangeType(values[i], prop.PropertyType));
                }
            }

            //foreach (var prop in obj.GetType().GetProperties())
            //{
            //    var index = headers.IndexOf(prop.Name);
            //    if (prop.Name == "Id") continue;
            //    if (index != -1)
            //    {
            //        if (prop.Name == "CountryId")
            //        {
            //            customTypeData = values[index];
            //        }
            //        else if (prop.PropertyType.Namespace.StartsWith("System"))
            //            prop.SetValue(obj, Convert.ChangeType(values[index], prop.PropertyType));
            //    }
            //}

            return obj;
        }

        public static bool CheckHeadersCorrect(List<string> headers, Type type, out string badHeader)
        {
            foreach (var header in headers)
            {
                if (header.Contains("Id")) continue;

                if (!type.GetProperties().Select(x => x.Name).Contains(header))
                {
                    badHeader = header;
                }
            }
            badHeader = "";
            return true;
        }
    }
}
