using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP2___t1
{
    public class WordsLine : ICollection<String>
    {
        private ICollection<String> _words = new List<String>();

        private IEnumerable<String> GetCurrentWords(IEnumerable<String> item)
        {
            return item.Where(x => (x != null) && (x.Length > 0));
        }
             
        public Nullable<int> GetWordsCount(String item)
        {
           return _words.Where(x=>String.Compare(x,item,true)==0) 
               .Count();
        }

        // Constructors
        #region Constructors
        public WordsLine(string[] item)
        {            
                _words = GetCurrentWords(item).ToList();            
        }

        public WordsLine(string item, char[] separator)
        {            
                _words = item
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();            
        }
        #endregion

        // Standard methods of ICollection
        #region Standart
        public void Add(string item)
        {
            if ((item != null) && (item.Length > 0))
            {
                _words.Add(item);
            }
        }


        public void Clear()
        {
            _words.Clear();
        }

        public bool Contains(string item)
        {
            return _words.Contains(item.ToLower());
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _words.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _words.Count; }
        }

        public bool IsReadOnly
        {
            get { return _words.IsReadOnly; }
        }

        public bool Remove(string item)
        {
            return _words.Remove(item);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

    }
}
