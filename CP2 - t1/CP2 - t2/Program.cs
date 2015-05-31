using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CP2___t1
{
    class Program
    {
        private static String [] _seperatorLine = { ".","?"};
        private static String[] _seperatorSentence = { ",", ".", "-","?"};
        private static String _pathIn = @"D:\MyFileIn.txt";

        static void Main(string[] args)
        {
            LinesBuilder linesBuilder = new LinesBuilder(_seperatorLine, _seperatorSentence);

            WordsCollection wordsCollection = new WordsCollection();

            List<String> linesList = new List<String>();
            try
            {
                StreamReader sr=new StreamReader(_pathIn);
                while (!sr.EndOfStream)
                {
                    foreach (var i in linesBuilder.GetLinesFromString(sr.ReadLine()))
                    {
                        linesList.Add(i);
                    }
                }
                sr.Close();

                foreach (var i in linesList)
                {
                    wordsCollection.Add(new WordsLine(linesBuilder.GetSentencesFromString(i).ToArray()));
                }

                foreach (var i in wordsCollection)
                {
                    Console.WriteLine(i.ToString());
                }

                Console.WriteLine("\n - wordsCollection.GetLinesSortedByWordsCount()");
                foreach (var i in wordsCollection.GetLinesSortedByWordsCount())
                {
                     Console.WriteLine(i.ToString());
                }

                Console.WriteLine("\n - wordsCollection.GetWordsInQuestionLines(1)");
                foreach (var i in wordsCollection.GetWordsInQuestionLines(1))
                {
                    Console.WriteLine(i.ToString());
                }

                Console.WriteLine("\n - wordsCollection.GetLinesWithDeletedWords(5, seperstorConsonants)");
                var seperstorConsonants = new char[]
                {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};
                foreach (var i in wordsCollection.GetLinesWithDeletedWords(5, seperstorConsonants))
                {
                    Console.WriteLine(i.ToString());
                }

                Console.WriteLine("\n - wordsCollection.GetLinesWithReplacedWords(4,'yelow')");
                foreach (var i in wordsCollection.GetLinesWithReplacedWords(4,"yelow"))
                {
                    Console.WriteLine(i.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }

            

            Console.ReadKey();
        }
    }
}
