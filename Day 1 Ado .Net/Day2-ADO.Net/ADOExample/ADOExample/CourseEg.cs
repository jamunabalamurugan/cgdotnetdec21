using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADOExample
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Fees { get; set; }
        public void TakeCourseDataFromUser()
        {
            Console.WriteLine("Please enter the course name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the fee amount");
            Fees = float.Parse(Console.ReadLine());
        }
    }
    class School
    {
        SqlConnection conn;
        SqlDataAdapter daCourse;
        DataSet dsCourse;
        School()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
            conn = new SqlConnection("Data source=MSBEEYS\\HBSQLEXPRESS;Initial Catalog=northwind;user id=sa;password=newuser123#");
        }

        void GetAllCourses()
        {
            daCourse = new SqlDataAdapter("proc_GetAllCourse", conn);
            daCourse.SelectCommand.CommandType = CommandType.StoredProcedure;
            dsCourse = new DataSet();
            daCourse.Fill(dsCourse, "myCourse");//open,get the data and put it in dataset,close the connection
            Console.WriteLine("The connection state " + conn.State);
            foreach (DataRow row in dsCourse.Tables["myCourse"].Rows)
            //foreach (DataRow row in dsCourse.Tables[0].Rows)
            {
                //Console.WriteLine("Course Id "+row[0]+" name "+row[1]+" fees "+row[2]);
                Console.WriteLine("Course Id " + row["id"] + " name " + row["name"] + " fees " + row["fees"]);
            }
        }
        void CreateCourseTable()
        {
            DataTable obj= new DataTable("Course");
            DataColumn objCourseId = new DataColumn();
            objCourseId.DataType = System.Type.GetType("System.Int32");
            objCourseId.AllowDBNull = false;
            objCourseId.ColumnName = "StudentNo";
            objCourseId.DefaultValue = 25;
            obj.Columns.Add(objCourseId);
            obj.Columns.Add("Name", typeof(String));
            obj.Columns.Add("Fees", typeof(Double));
            DataRow drNew = obj.NewRow();
            drNew["name"] = "Kavin";
            drNew["fees"] = 3000;
            obj.Rows.Add(drNew);
            new SqlCommandBuilder(daCourse);//generate the insert command
            daCourse.Update(dsCourse, "Course");
        }
        void InsertNewCourseToDatabase()
        {
            Course course = new Course();
            course.TakeCourseDataFromUser();
            //daCourse = new SqlDataAdapter();
            //daCourse.InsertCommand = new SqlCommand("proc_InsertCourse", conn);
            //daCourse.InsertCommand.CommandType = CommandType.StoredProcedure;
            //daCourse.InsertCommand.Parameters.AddWithValue("@cname", course.Name);
            //daCourse.InsertCommand.Parameters.AddWithValue("@cfees", course.Fees);
            //DataSet dataSet = new DataSet();
            DataRow drNew = dsCourse.Tables[0].NewRow();
            drNew["name"] = course.Name;
            drNew["fees"] = course.Fees;
            dsCourse.Tables["myCourse"].Rows.Add(drNew);
            new SqlCommandBuilder(daCourse);//generate the insert command
            daCourse.Update(dsCourse, "myCourse");
        }
        static void Main(string[] a)
        {
            School school = new School();
            school.CreateCourseTable();
    //        school.InsertNewCourseToDatabase();
           // school.GetAllCourses();
            Console.ReadKey();
        }
    }


}
