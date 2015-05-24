using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CP2___t1
{
    class Program
    {
        private static char [] _seperator = { ' ', '.','?',','};
        private static String _pathIn = @"C:\MyFiles.txt";
        private static String _pathOut = @"D:\MyFiles.txt";

        static void Main(string[] args)
        {
            WordsCollection wordsCollection = new WordsCollection();

            // Read from file
            //System.IO.StreamReader file = new System.IO.StreamReader(_path);
           
            try
            {
                using (StreamReader sr = new StreamReader(_pathIn))
                {
                    while (sr.Peek() >= 0)
                    {
                        wordsCollection.Add(new WordsLine(sr.ReadLine(),_seperator));
                    }
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
           // var hg = new WordsLine(new String [] {"jhgh","a","a","j"});
               

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_pathOut))
            {
                foreach (var i in wordsCollection.GetSingleOrderWords())
                {
                    file.WriteLine("{0} - {1} - {2}",
                    i,
                    wordsCollection.GetWordsLinesCount(i),
                    String.Join(",", wordsCollection.GetPositionsWord(i).ToArray()));                   
                }
            }

            Console.ReadKey();
        }
    }
}
