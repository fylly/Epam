using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    

    class Triangle 
    {
        public enum triangleType { none = 0, acute, right, obtuse };

        private double p_a = 0;
        private double p_b = 0;
        private double p_c = 0;

        public double a
        {
            get
            {
                return p_a;
            }
            set
            {
                isCorrect(value);
                p_a = value;
            }            
        }

        public double b
        {
            get
            {
                return p_b;
            }
            set
            {
                isCorrect(value);
                p_b = value;
            }
        }

        public double c
        {
            get
            {
                return p_c;
            }
            set
            {
                isCorrect(value);
                p_c = value;
            }
        }

        public Triangle()
        {

        }

        private void isCorrect(double p_)
        {
            if (p_ <= 0)
            {
                throw new Exception("Incorrect value");
            }
        }

        private void isCorrect(double a_, double b_, double c_)
        {
            if ((a_ <= 0) || (b_ <= 0) || (c_ <= 0))
            {
                throw new Exception("Incorrect value");
            }
        }
        
        public bool isExist()
        {
            if ((a + b <= c) || (a + c <= b) || (b + c <= a))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isExist(double a_, double b_, double c_)
        {
            if ((a_ + b_ <= c_) || (a_ + c_ <= b_) || (b_ + c_ <= a_))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool createTriangle(double a_, double b_, double c_)
        {
            isCorrect(a_, b_, c_);
            if (isExist(a_, b_, c_))
            {
                a = a_;
                b = b_;
                c = c_;
                return true;
            }
            else
            {
                return false;
            }
        }

        public triangleType getTypeTriangle()
        {
            if (!isExist())
            {
                return triangleType.none;
            }
            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double cosB = (a * a + c * c - b * b) / (2 * a * c);
            double cosC = (b * b + a * a - c * c) / (2 * b * a);

            if ((cosA == 0) || (cosB == 0) || (cosC == 0))
            {
                return triangleType.right;
            }
            else if ((cosA < 0) || (cosB < 0) || (cosC < 0))
            {
                return triangleType.obtuse;
            }
            return triangleType.acute;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();

            string input;

            Console.WriteLine("a = ");
            input = Console.ReadLine();
            double a = Convert.ToDouble(input);

            Console.WriteLine("b = ");
            input = Console.ReadLine();
            double b = Convert.ToDouble(input);

            Console.WriteLine("c = ");
            input = Console.ReadLine();
            double c = Convert.ToDouble(input);

            triangle.createTriangle(a, b, c);
            Console.WriteLine("Type Triangle: " + triangle.getTypeTriangle());

            Console.ReadKey();
        }
    }
}
