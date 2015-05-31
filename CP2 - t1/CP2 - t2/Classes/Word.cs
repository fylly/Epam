using System;

namespace CP2___t1
{
    public class Word :IWord
    {

        public string Item
        {
            get;
            set;
        }

        public Word(String item)
        {
            Item = item;
        }

        public int IndexOf(String item)
        {
            return Item.IndexOf(item);       
        }


        public bool IsNullOrEmpty()
        {
            return String.IsNullOrEmpty(Item);
        }


        public int Length()
        {
            return Item.Length;
        }


        public string ToLower()
        {
            return Item.ToLower();
        }
    }
}
