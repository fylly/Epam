using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class DiningCar : PassengerCars, IDining
    {
        public int DeanerSeats { get; set; }
    }
}
