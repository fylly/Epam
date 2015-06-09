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
            pbx.Add(new PBXPort(){ PbxTerminal = new PBXTerminal(),phoneNumber = new PhoneNumber(){Number = "110"}});
            pbx.Add(new PBXPort() { PbxTerminal = new PBXTerminal(), phoneNumber = new PhoneNumber() { Number = "111" } });

            pbx.Call(new PhoneNumber(){Number = "111"}, new PhoneNumber(){Number = "110"});

            Console.WriteLine("Ports State");
            foreach (var i in pbx)
            {
                Console.WriteLine("{0} - {1} - {2}",i.phoneNumber.Number, i.State, i.PbxTerminal.State);
            }

            pbx.EndCall(new PhoneNumber() { Number = "110" });
            Console.WriteLine("Ports State");
            foreach (var i in pbx)
            {
                Console.WriteLine("{0} - {1} - {2}", i.phoneNumber.Number, i.State, i.PbxTerminal.State);
            }

            pbx.UnPlugTerminal(new PhoneNumber() { Number = "110" });
            Console.WriteLine("Ports State");
            foreach (var i in pbx)
            {
                Console.WriteLine("{0} - {1} - {2}", i.phoneNumber.Number, i.State, i.PbxTerminal.State);
            }

            pbx.Call(new PhoneNumber() { Number = "111" }, new PhoneNumber() { Number = "110" });
            Console.WriteLine("Ports State");
            foreach (var i in pbx)
            {
                Console.WriteLine("{0} - {1} - {2}", i.phoneNumber.Number, i.State, i.PbxTerminal.State);
            }

            Console.ReadKey();
        }
    }
}
