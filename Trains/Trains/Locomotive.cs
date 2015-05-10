using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class Locomotive : TrainItem, ILocomotive
    {
        public int speed { get; set; }
       
    }
}
