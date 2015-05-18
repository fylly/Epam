using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class TrainItem : ITrainItem
    {
        public string Model { get; set; }

        public string Builder { get; set; }

        public DateTime BuildDate { get; set; }

        public int Weight { get; set; }
    }
}
