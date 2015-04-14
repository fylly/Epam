using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class LinearFunction
    {
        private int p_a;
        private int p_b;

        public LinearFunction()
        {
            a = 0;
            b = 0;
        }

        public LinearFunction(int a_, int b_)
        {
            a = a_;
            b = b_;
        }

        public int a
        {
            get
            {
                return p_a;
            }
            set
            {
                p_a = value;
            }
        }
        
        public int b
        {
            get
            {
                return p_b;
            }
            set
            {
                p_b = value;
            }
        }
        public int get_y(int x_)
        {
            int y = a * x_ + b;
            return y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            

            string input;

            Console.WriteLine("a = ");
            input = Console.ReadLine();
            int a = Convert.ToInt32(input);


            Console.WriteLine("b = ");
            input = Console.ReadLine();
            int b = Convert.ToInt32(input);

            LinearFunction linearFunction = new LinearFunction(a,b);

            Console.WriteLine("a = " + linearFunction.a);
            Console.WriteLine("b = " + linearFunction.b);

            // linearFunction.a
            // linearFunction.b

            int x;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter x: ");
                input = Console.ReadLine();
                x = Convert.ToInt32(input);

                Console.WriteLine("y = " + linearFunction.get_y(x));
            }

                
            Console.ReadLine();

        }
    }
}
