using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingStock rollingStock = new RollingStock();
            rollingStock.Add(new Diesel() {
                Model = "Diesel E56"
            });
            rollingStock.Add(new Coach()
            {
                Model = "Coach C605",
                CoachSeats = 10,
                CoachType = PassengerCarsType.Second
            });
            rollingStock.Add(new BaggageCar()
            {
                Model = "Baggage B605",
                CoachSeats = 10,
                CoachType = PassengerCarsType.First
            });

            foreach (var i in rollingStock)
            {
                Console.WriteLine("{0}, {1}", i.Model, i.Builder);
            }

            Console.WriteLine("\n GetCoachItemByNumber()");
            foreach (var i in rollingStock.GetCoachItemByNumber(1, 100))
            {
                Console.WriteLine("{0}, {1}", i.Model, i.Builder);
            }

            Console.WriteLine("\n GetCoachSeatsSum()");
            Console.WriteLine("{0}", rollingStock.GetCoachSeatsSum());

            Console.WriteLine("\n GetBaggagSeatsSum()");
            Console.WriteLine("{0}", rollingStock.GetBaggageQuantitySum());

            Console.WriteLine("\n GetCoachItemByNumber()");
            foreach (var i in rollingStock.SortByCoachType())
            {
                Console.WriteLine("{0}, {1}", i.Model, i.Builder);
            }

            Console.ReadKey();
        }
    }
}
