using System;

namespace CP2___t1
{
    public class Character: ICharacter
    {
        public string Item
        {
            set;
            get;
        }

        public Character(String item)
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
