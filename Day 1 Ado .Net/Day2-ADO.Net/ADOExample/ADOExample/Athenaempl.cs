using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ADOExample
{
    
    class Athenaempl
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;

        public void Readdata()
        {
            con = new SqlConnection("data source=(local);Initial Catalog=Athena;Integrated security=true");
            con.Open();
            cmd = new SqlCommand("Select * from employee",con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                Console.WriteLine(rdr[1]);
                Console.WriteLine(rdr[2]);
                Console.WriteLine(rdr[3]);
            }
         }

        public void Readparamdata()
        {
            int i;
            Console.WriteLine("Enter the employee id");
            i = Convert.ToInt16(Console.ReadLine());
            con = new SqlConnection("data source=(local);Initial Catalog=Athena;Integrated security=SSPI");
            con.Open();
           // cmd = new SqlCommand("Select * from employee where eid=@id",con);
            cmd = new SqlCommand("getempname1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@id", i);
            cmd.Parameters.Add(param);

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                Console.WriteLine(rdr[1]);
                Console.WriteLine(rdr[2]);
                Console.WriteLine(rdr[3]);
            }
         }

        
        public void Insertdata()
        {
            con = new SqlConnection("data source=(local);Initial Catalog=Athena;Integrated security=SSPI");
            con.Open();
            string insertString = @"
                 insert into Employee(EID,EName, doj,salary)
                 values (5040,'Danista','8/1/2014',80000)";
            cmd = new SqlCommand(insertString, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Inserted");
        }

        public void updatedata()
        {
            con = new SqlConnection("data source=(local);Initial Catalog=Athena;Integrated security=SSPI");
            con.Open();
            string insertString = @"update Employee set salary=90000 where eid=5040";
                 
            cmd = new SqlCommand(insertString, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Updated");
        }
        public void deletedata()
        {
            con = new SqlConnection("data source=(local);Initial Catalog=Athena;Integrated security=SSPI");
            con.Open();
            string insertString = @"delete Employee where eid=5009";

            cmd = new SqlCommand(insertString, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Deleted");
        }
        public static void Main()
        {
            Athenaempl obj = new Athenaempl();
           // obj.Readdata();
            //obj.Insertdata();
            //obj.updatedata();
           //obj.deletedata();
           //obj.Readdata();
          obj.Readparamdata();
            Console.Read();
        }
    }
}
