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
            pbx.AddPort(new PBXPort(new PhoneNumberStruct("110")){ PbxTerminal = new PBXTerminal() });
            pbx.AddPort(new PBXPort(new PhoneNumberStruct("111")) { PbxTerminal = new PBXTerminal() });

            pbx.Call(new PhoneNumberStruct("111"), new PhoneNumberStruct("110"));

            Console.WriteLine("Ports State");
            foreach (var i in pbx.GetPorts())
            {
                Console.WriteLine("{0} - {1} - {2}",i.PhoneNumber.Number, i.State, i.PbxTerminal.State);
            }
            Console.WriteLine("Active Rings");
            foreach (var i in pbx.GetActiveRings())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneSource.Number, i.PhoneDestination.Number, i.State);
            }


            pbx.EndCall(new PhoneNumberStruct("110"));
            Console.WriteLine("Ports State");
            foreach (var i in pbx.GetPorts())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneNumber.Number, i.State, i.PbxTerminal.State);
            }
            Console.WriteLine("Active Rings");
            foreach (var i in pbx.GetActiveRings())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneSource.Number, i.PhoneDestination.Number, i.State);
            }


            pbx.UnPlugTerminal(new PhoneNumberStruct("110"));
            Console.WriteLine("Ports State");
            foreach (var i in pbx.GetPorts())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneNumber.Number, i.State, i.PbxTerminal.State);
            }
            Console.WriteLine("Active Rings");
            foreach (var i in pbx.GetActiveRings())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneSource.Number, i.PhoneDestination.Number, i.State);
            }


            pbx.Call(new PhoneNumberStruct("111"), new PhoneNumberStruct("110"));
            Console.WriteLine("Ports State");
            foreach (var i in pbx.GetPorts())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneNumber.Number, i.State, i.PbxTerminal.State);
            }
            Console.WriteLine("Active Rings");
            foreach (var i in pbx.GetActiveRings())
            {
                Console.WriteLine("{0} - {1} - {2}", i.PhoneSource.Number, i.PhoneDestination.Number, i.State);
            }

            Console.ReadKey();
        }
    }
}
