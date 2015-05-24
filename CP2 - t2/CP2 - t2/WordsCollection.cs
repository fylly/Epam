using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP2___t1
{
    public class WordsCollection : ICollection <WordsLine>// var curentItem = item.Where(x => x.Length != 0);
    {
        private ICollection<WordsLine> _lines = new List<WordsLine>();

        public Nullable<int> GetWordsLinesCount(String item)
        {
            return _lines.Select(x =>x.GetWordsCount(item)).Sum();
        }

        public IEnumerable<String> GetSingleOrderWords()
        {
            return _lines.SelectMany(x => x)
                .GroupBy(x=>x)
                .Select(x=>x.Key)
                .OrderBy(x=>x);
        }

        public IEnumerable <int> GetPositionsWord(String item)
        {            
            int n=1;
            return _lines.Select(x => new { index = n++, countValue = x.GetWordsCount(item) })
                .Where(y=>y.countValue > 0)
                .Select(z=> z.index);                   
        }
                
        #region Standart
        public void Add(WordsLine item)
        {
            _lines.Add(item);
        }

        public void Clear()
        {
            _lines.Clear();
        }

        public bool Contains(WordsLine item)
        {
            return _lines.Contains(item);
        }

        public void CopyTo(WordsLine[] array, int arrayIndex)
        {
            _lines.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _lines.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(WordsLine item)
        {
            return _lines.Remove(item);
        }

        public IEnumerator<WordsLine> GetEnumerator()
        {
            return _lines.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
