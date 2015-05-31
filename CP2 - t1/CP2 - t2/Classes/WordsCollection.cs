using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;


namespace CP2___t1
{
    public class WordsCollection : ICollection <WordsLine>// var curentItem = item.Where(x => x.Length != 0);
    {

        private ICollection<WordsLine> _lines = new List<WordsLine>();

        // return WordsLines sorted by words count
        public IEnumerable<WordsLine> GetLinesSortedByWordsCount()
        {
            return _lines.Select(x=>x)
                .OrderBy(x=>x.OfType<IWord>().Count()); 
        }

        // return question WordsLines where words have a predetermined length
        public IEnumerable<WordsLine> GetWordsInQuestionLines(int itemLength)
        {
            return _lines.Where(x => x.Last().Item == "?") 
                .Select(x => new WordsLine(x.OfType<IWord>().Where(y => y.Length() == itemLength).Distinct())); // !!! rewrite .Distinct()
        }

        // return WordsLines without the words having a predetermined length and starts at  a predetermined character
        public IEnumerable<WordsLine> GetLinesWithDeletedWords(int itemLength, char [] firstIndex)
        {
            List<char> firstIndexList = firstIndex.ToList();
            return _lines
                .Select(x => new WordsLine(x.OfType<IWord>().Where(y => (y.Length() != itemLength) || (firstIndexList.FindIndex(z=> z == y.ToLower()[0]) < 0))));
        }

        public IEnumerable<WordsLine> GetLinesWithReplacedWords(int itemLength, String st)
        {
            return  _lines.Select(x => new WordsLine(x.Select(delegate(ISentenceItem y)
                {
                    if ((y is IWord)&&(y.Length() == itemLength))
                    {
                        return new Word(st);
                    }
                    else
                    {
                        return y;
                    }
                }
                )));

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
            get { return _lines.IsReadOnly; }
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
