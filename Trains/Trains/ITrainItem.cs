using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public interface ITrainItem
    {
        string Model { get; }
        string Builder { get; }
        DateTime BuildDate { get; }
        int Weight { get; }
    }
}
