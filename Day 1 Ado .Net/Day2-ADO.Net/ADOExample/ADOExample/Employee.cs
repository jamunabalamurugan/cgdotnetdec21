using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADOExample
{
    partial class Employee
    {
        static int num1;
        int num2;
        static Employee()
        {
            num1 = 100;
            Console.WriteLine("Employee static constructor");
        }
        public Employee()
        {
            num2 = num1;
            Console.WriteLine("Instance Default constructor");
            //age = 21;
        }
        public void Print()
        {
            Console.WriteLine("Num1 is " + num1);
            Console.WriteLine("Num2 is " + num2);
        }
    }
}
