using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP2___t1
{
    public static class LineBuilder
    {
        public static IEnumerable <String> StringSplit(string item, char[] separator)
        {
            if (item == null || separator == null)
            {
                throw new NotImplementedException();
            }
                
            return item
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
