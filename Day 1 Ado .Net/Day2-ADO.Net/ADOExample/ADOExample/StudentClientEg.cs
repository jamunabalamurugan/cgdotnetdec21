using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentBusinessLogicEg;
using StudentDALEg;
namespace ADOExample
{
    

        class ThreetireArchitectureEg
        {
            public static void Main()
            {

                BusinessLogicLayer balobj = new BusinessLogicLayer();
                Student1 student = new Student1();
                Console.WriteLine("Enter the student Id");
                student.Id = int.Parse(Console.ReadLine());
                string result = balobj.CheckPlacementAge(student.Id);
                Console.WriteLine("The Students Age is {0 }", result);
                Console.WriteLine(student.Age);
                Console.Read();
            }
        }
    }

