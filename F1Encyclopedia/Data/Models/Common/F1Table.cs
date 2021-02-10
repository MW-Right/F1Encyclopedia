using System;
using System.Collections.Generic;
using System.Linq;

namespace F1Encyclopedia.Data.Models.Common
{
    public class F1Table
    {
        public static dynamic FromCsv(string[] values, List<string> headers, Object obj)
        {
            foreach(var prop in obj.GetType().GetProperties())
            {
                var index = headers.IndexOf(prop.Name);
                if (index != -1)
                {
                    prop.SetValue(obj, Convert.ChangeType(values[index], prop.PropertyType));
                }
            }

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
                    return false;
                }
            }
            badHeader = "";
            return true;
        }
    }
}
