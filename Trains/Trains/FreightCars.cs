using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class FreightCars : TrainItem, IFreightCars
    {
        public float FreightLoad  { get; set; }
    }
}
