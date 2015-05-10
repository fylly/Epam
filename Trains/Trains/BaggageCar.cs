using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class BaggageCar : PassengerCars, ICoach, IBaggageCar
    {
        public PassengerCarsType CoachType { get; set; }

        public int CoachSeats { get; set; }

        public int BaggageQuantity { get; set; }
    }
}
