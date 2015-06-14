using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PBX_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            TariffStandart tariffStandart = new TariffStandart("Tariff 1", 12087);

            PBX pbx = new PBX();
            pbx.AddPort(new PBXPort(new PhoneNumberStruct("110")) { PbxTerminal = new PBXTerminal() }, "Egor", tariffStandart);
            pbx.AddPort(new PBXPort(new PhoneNumberStruct("111")) { PbxTerminal = new PBXTerminal() }, "Stepa", tariffStandart );

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


            pbx.Answer(new PhoneNumberStruct("110"));
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

            System.Threading.Thread.Sleep(3000);

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
            Console.WriteLine("Statistics");
            foreach (var i in pbx.GetStatistics())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", i.PhoneSource.Number, i.PhoneDestination.Number, i.TimeCall, i.Summ);
            }

            //------------------------------------------------------------------------

            pbx.SetNewBillingType(new PhoneNumberStruct("111"), new TariffStandart("111",15));

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
            
            pbx.Answer(new PhoneNumberStruct("110"));
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

            System.Threading.Thread.Sleep(9000);

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
            Console.WriteLine("Statistics");
            foreach (var i in pbx.GetStatistics())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", i.PhoneSource.Number, i.PhoneDestination.Number, i.TimeCall, i.Summ);
            }


            Console.ReadKey();
        }
    }
}
