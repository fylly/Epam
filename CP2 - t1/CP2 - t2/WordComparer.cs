using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP2___t1
{
    public class WordComparer : IEqualityComparer<IWord>
    {
        public bool Equals(IWord x, IWord y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the words properties are equal.
            return String.Compare(x.Item,y.Item, true) == 0;
        }

        public int GetHashCode(IWord obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Item field if it is not null.
            int hashWordItem = obj.Item == null ? 0 : obj.Item.GetHashCode();
                        
            //Calculate the hash code for the product.
            return hashWordItem;
        }
    }
}
