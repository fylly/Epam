using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Diagnostics;

namespace ConsoleApplication1
{
    // Объявление структуры
    struct Item
    {
        string name;
        int number;
        int cost;

        public Item(string name_, int number_, int cost_)
        {
            name = name_;
            number = number_;
            cost = cost_;
        }
        public int get_summ()
        {
            return number * cost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Начало измерения затраченного времени
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // Объявление переменных
            long summ = 0;
            Random rand = new Random();
            ArrayList myAL = new ArrayList();

            // Создание коллекции
            for (int i = 0; i < 100000; i++)
            {
                myAL.Add(new Item("Name1", rand.Next(1, 1000), rand.Next(1, 1000000)));
            }

            // Подсчет суммы
            //foreach (Object obj in myAL)
            foreach (Item item in myAL) 
            {
                summ += item.get_summ();
            }
            Console.WriteLine("summ = " + summ);

            // Завершение измерения затраченного времени
            stopWatch.Stop();
            Console.WriteLine("Time: " + stopWatch.Elapsed);

            Console.ReadKey();
        }
    }
}
