using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            PBX pbx = new PBX();
            pbx.Add(new PBXPort(){ PbxTerminal = new PBXTerminal()});

            Console.ReadKey();
        }
    }
}
