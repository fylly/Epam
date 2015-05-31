using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CP2___t1
{
    class Program
    {
        private static char [] _seperator = { ' ', '.','?',',','-'};
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
                    wordsCollection.Add(new WordsLine(LineBuilder.StringSplit(sr.ReadLine(), _seperator)));
                }
                sr.Close();

                try
                {
                    StreamWriter sw = new StreamWriter(_pathOut);
                    foreach (var i in wordsCollection.GetSingleOrderWords())
                    {
                        sw.WriteLine("[{0}] ", i.Key);
                        foreach (var j in i)
                        {
                             sw.WriteLine("{0} - {1} - {2}",
                            j,
                            wordsCollection.GetWordsLinesCount(j),
                            String.Join(",", wordsCollection.GetPositionsWord(j).ToArray()));   
                        }
                    }
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e);
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
