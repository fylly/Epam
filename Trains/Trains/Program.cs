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
                Model = "Diesel E56",
                BuildDate = new DateTime(2010,5,12),
                EnginePower = 30000,
                MaxSpeed = 150,
                SpeedUp = 4.1,
                Weight = 3000
            });
                        
            rollingStock.Add(new Coach()
            {
                Model = "Coach C605",
                BuildDate = new DateTime(2005, 1, 19),
                Weight = 2000,
                CoachSeats = 38,
                CoachType = PassengerCarsType.Second
            });
            rollingStock.Add(new BaggageCar()
            {
                Model = "Baggage B605",
                BuildDate = new DateTime(2010, 4, 1),
                Weight = 2000,                
                CoachSeats = 45,
                BaggageQuantity = 111,
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
            rollingStock.SortByCoachType();
            foreach (var i in rollingStock)
            {
                Console.WriteLine("{0}, {1}", i.Model, i.Builder);
            }

            Console.ReadKey();
        }
    }
}
