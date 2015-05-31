using System;
using System.Collections.Generic;
using System.Linq;

namespace CP2___t1
{
    public class LinesBuilder
    {
        private String [] _seperatorLine;
        private String [] _seperatorSentence;

        public LinesBuilder(String[] seperatorLine, String[] seperatorSentence)
        {
            _seperatorLine = seperatorLine;
            _seperatorSentence = seperatorSentence;
        }
        
        public IEnumerable<String> GetLinesFromString(String item)
        {
            var itemsList = new List<String>();

            itemsList.Add(item);
            _seperatorLine.OrderBy(x=>x.Count()).ToList().FindAll(
                    delegate(String st)
                    {
                        var bufferList = new List<String>();
                        foreach (var i in itemsList)
                        {
                            if (i.IndexOf(st) >= 0)
                            {
                                bufferList.AddRange(ParseToLines(i, st));
                            }
                            else
                            {
                                bufferList.Add(i);
                            }                            
                        };
                        itemsList = bufferList.ToList();
                        return true;
                    }
                );

            return itemsList.ToArray();
        }

        public IEnumerable<ISentenceItem> GetSentencesFromString(String item)
        {   
            List<ISentenceItem> itemsList = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>GetSentenceResult(x))
                .ToList();

            _seperatorSentence.ToList().FindAll(
                    delegate(String st)
                    {
                        var bufferList = new List<ISentenceItem>();
                        foreach (var i in itemsList)
                        {
                            if (i is ICharacter)
                            {
                                bufferList.Add(i);
                            }
                            else
                            {
                                if (i.IndexOf(st) >= 0)
                                {
                                    bufferList.AddRange(ParseToWords(i.Item, st).Select(x => GetSentenceResult(x)));
                                }
                                else
                                {
                                    bufferList.Add(i);
                                }
                            }
                        }
                        itemsList = bufferList.ToList();
                        return true;
                    }
                );
                                   
            return  itemsList.ToArray();
        }

        // return Words and Chars persed by seperator
        public static IEnumerable<String> ParseToWords(String item, String seperator)
        {                         
            while (true)
            {
                var itemIndex = item.IndexOf(seperator);
                if (itemIndex > -1)
                {
                    yield return item.Substring(0, itemIndex);
                    yield return item.Substring(itemIndex, seperator.Length);

                    item = item.Remove(0, itemIndex + seperator.Length);
                }
                else
                {                    
                    if (!String.IsNullOrEmpty(item))
                    {
                       yield return item;
                    }
                    break;
                }
            }
        }

        // return Lines persed by seperator
        public static IEnumerable<String> ParseToLines(String item, String seperator)
        {                         
            while (true)
            {
                var itemIndex = item.IndexOf(seperator);
                if (itemIndex > -1)
                {
                    yield return item.Substring(0, itemIndex + seperator.Length).Trim();
                    item = item.Remove(0, itemIndex + seperator.Length).Trim();
                }
                else
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        yield return item;
                    }
                    break;
                }
            }
        }

        // Method determines the type of SentenceItem
        public ISentenceItem GetSentenceResult(String item)
        {
            var buffer = _seperatorSentence.ToList().Find(x=> x==item);

            if ((buffer!=null) && (buffer.Any()))
            {
                return new Character(buffer);
            }
            else
            {
                return new Word(item);
            }
        }
    }
}
