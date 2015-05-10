using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public interface ICoach : IPassengerCars
    {
        PassengerCarsType CoachType { get; }
        int CoachSeats { get; }
    }
}
