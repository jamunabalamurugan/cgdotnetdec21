using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ADOExample
{
    struct MyDate
    {
        public int day, month, year;
        public MyDate(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
        public string PrintDate()
        {
            return day + "/" + month + "/" + year;

        }
    }
    class TransactionsEg
    {
        MyDate dob = new MyDate(10, 10, 2020);
        MyDate doj;
        SqlConnection conn;
        string studentName, courseName;
        int age;
        float fees;
        const int PI = 100;
        TransactionsEg()
        {
            Console.WriteLine(dob.PrintDate());
            doj = dob;
            doj.year = 1999;
            Console.WriteLine(dob.PrintDate());
            //iNum1 = 200;
            // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tranCon"].ConnectionString);
            conn = new SqlConnection("Data source=MSBEEYS\\HBSQLEXPRESS;Initial Catalog=northwind;user id=sa;password=newuser123#");
            //conn.Open();
            //Console.WriteLine("Connected");
        }
        void ExampleScalar()
        {
            //SqlCommand cmd = new SqlCommand("Select avg(age) from tblStudent", conn);
            SqlCommand cmd = new SqlCommand("Select top 1 name from tblStudent", conn);
            conn.Open();
            //double avgAge = Convert.ToDouble(cmd.ExecuteScalar().ToString());
            string name = cmd.ExecuteScalar().ToString();
            conn.Close();
            //Console.WriteLine("THe average age of students "+avgAge);
            Console.WriteLine("The students name is  " + name);
        }
        void TakeStudentData()
        {
            Console.WriteLine("Please enter the studnet name");
            studentName = Console.ReadLine();
            Console.WriteLine("Please enter the studnet age");
            age = Convert.ToInt32(Console.ReadLine());
        }
        void TakeCourseData()
        {
            Console.WriteLine("Please enter the course name");
            courseName = Console.ReadLine();
            Console.WriteLine("Please enter the course fees");
            fees = float.Parse(Console.ReadLine());
        }
        void InsertDataToDatabase()
        {
            TakeCourseData();
            TakeStudentData();
            try
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand cmdInserts = conn.CreateCommand();
                cmdInserts.Transaction = sqlTransaction;
                try
                {
                    cmdInserts.CommandText = "Insert into tblCourse(name,fees) values(@cname,@cfees)";
                    cmdInserts.Parameters.AddWithValue("@cname", courseName);
                    cmdInserts.Parameters.AddWithValue("@cfees", fees);
                    cmdInserts.ExecuteNonQuery();
                    sqlTransaction.Save("t1");

                    cmdInserts.CommandText = "Insert into Students(name,age) values(@sname,@sage)";
                    cmdInserts.Parameters.AddWithValue("@sname", studentName);
                    cmdInserts.Parameters.AddWithValue("@sage", age);
                    cmdInserts.ExecuteNonQuery();
                    try
                    {
                        Console.WriteLine("Please enter name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter num");
                        int number = int.Parse(Console.ReadLine());
                        cmdInserts.CommandText = "Insert into tblDummy values(@name,@num)";
                        cmdInserts.Parameters.AddWithValue("@name", number);
                        cmdInserts.Parameters.AddWithValue("@num", name);
                        cmdInserts.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        sqlTransaction.Rollback("t1");
                    }
                    sqlTransaction.Commit();
                    Console.WriteLine("Course and Student added");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //Console.WriteLine(e.StackTrace);
                    sqlTransaction.Rollback();
                    Console.WriteLine("GO go nothing has been inserted. All gone...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        static void Main(string[] args)
        {
            TransactionsEg program = new TransactionsEg();
            program.ExampleScalar();
            //Employee e1 = new Employee();
            //Employee e2 = new Employee();
            //e1.Print();
            //e2.Print();
            Console.ReadKey();
        }
    }
}
