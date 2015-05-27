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
        private static String _pathIn = @"D:\MyFileIn.txt";
        private static String _pathOut = @"D:\MyFileOut.txt";

        static void Main(string[] args)
        {
            WordsCollection wordsCollection = new WordsCollection();
             
            try
            {
                StreamReader sr=new StreamReader(_pathIn);
                while (!sr.EndOfStream)
                {                    
                    wordsCollection.Add(new WordsLine(sr.ReadLine(),_seperator));
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            
            try
            {
                StreamWriter sw = new StreamWriter(_pathOut);
                foreach (var i in wordsCollection.GetSingleOrderWords())
                {
                    sw.WriteLine("{0} - {1} - {2}",
                    i,
                    wordsCollection.GetWordsLinesCount(i),
                    String.Join(",", wordsCollection.GetPositionsWord(i).ToArray()));                   
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            Console.ReadKey();
        }
    }
}
