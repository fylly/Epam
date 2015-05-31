using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;

namespace CP2___t1
{
    public class WordsLine : ICollection<ISentenceItem>, IWordsLine
    {
        private ICollection<ISentenceItem> _sentences = new List<ISentenceItem>();                

        // Constructors
        #region Constructors
        public WordsLine(IEnumerable<ISentenceItem> item)
        {
            _sentences = item.ToList();
        }
        #endregion

        // Standard methods of ICollection
        #region Standart
        public void Add(ISentenceItem item)
        {
            _sentences.Add(item);            
        }

        public void Clear()
        {
            _sentences.Clear();
        }

        public bool Contains(ISentenceItem item)
        {
            return _sentences.Contains(item);
        }

        public void CopyTo(ISentenceItem[] array, int arrayIndex)
        {
            _sentences.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _sentences.Count; }
        }

        public bool IsReadOnly
        {
            get { return _sentences.IsReadOnly; }
        }

        public bool Remove(ISentenceItem item)
        {
            return _sentences.Remove(item);
        }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return _sentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        public override string ToString()
        {
            return string.Join(" ", _sentences.Select(x=>x.Item));
        }
    }
}
