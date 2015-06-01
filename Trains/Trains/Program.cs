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
            RollingStock rollingStock = new RollingStock()
            {                    
                new Diesel() 
                {
                    Model = "Diesel E56",
                    BuildDate = new DateTime(2010,5,12),
                    EnginePower = 30000,
                    MaxSpeed = 150,
                    SpeedUp = 4.1,
                    Weight = 3000
                },                        
                new Coach()
                {
                    Model = "Coach C605",
                    BuildDate = new DateTime(2005, 1, 19),
                    Weight = 2000,
                    CoachSeats = 38,
                    CoachType = PassengerCarsType.Second
                },
                new BaggageCar()
                {
                    Model = "Baggage B605",
                    BuildDate = new DateTime(2010, 4, 1),
                    Weight = 2000,                
                    CoachSeats = 45,
                    BaggageQuantity = 111,
                    CoachType = PassengerCarsType.First
                },                        
                new Coach()
                {
                    Model = "Coach C609",
                    BuildDate = new DateTime(2005, 1, 19),
                    Weight = 2000,
                    CoachSeats = 38,
                    CoachType = PassengerCarsType.First
                },
                new BaggageCar()
                {
                    Model = "Baggage B610",
                    BuildDate = new DateTime(2010, 4, 1),
                    Weight = 2000,                
                    CoachSeats = 45,
                    BaggageQuantity = 111,
                    CoachType = PassengerCarsType.Third
                },
                new DiningCar() 
                {
                    Model = "Dining E57",
                    BuildDate = new DateTime(2010,5,12),
                    DeanerSeats = 20,
                    Weight = 3000
                },
            };

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

            Console.WriteLine("\n SortByCoachType()");           
            foreach (var i in rollingStock.Sort(new TrainItemComparerBySeatsCount()))
            {
                Console.WriteLine("{0}, {1}", i.Model, i.Builder);
            }

            Console.ReadKey();
        }
    }
}
