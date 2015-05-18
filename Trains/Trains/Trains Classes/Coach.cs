using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Coach : PassengerCars, ICoach
    {
        public PassengerCarsType CoachType { get; set; }

        public int CoachSeats { get; set; }
    }
}
