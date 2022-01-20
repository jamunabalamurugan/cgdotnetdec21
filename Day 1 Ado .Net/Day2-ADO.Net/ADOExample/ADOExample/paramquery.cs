using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace ADOExample
{
    class paramquery
    {
                public paramquery()
        {
            // Instantiate the connection
            
        }

        // call methods that demo SqlCommand capabilities
        public static void Main()
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=school;Integrated Security=SSPI");
            //Console.WriteLine("Connection created");
            Console.WriteLine("Enter the CategoryID");
            string i = Console.ReadLine();
            conn.Open();
            Console.WriteLine("Connection created");
            SqlCommand cmd;
            cmd=new SqlCommand("select * from categories where catergoryId=@id",conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
           // cmd.CommandType = System.Data.CommandType.Text;
           // string query = "select * from categories where CatergoryID = @id";
           // cmd.Connection = conn;
          //  cmd.CommandText = query;

             //SqlParameter param = new SqlParameter("@id", i);
            //cmd.Parameters.Add(param);
            cmd.Parameters.Add(new SqlParameter("@id", i));
            SqlDataReader rdr = null;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                Console.WriteLine(rdr[1]);
                Console.WriteLine(rdr[2]);
                Console.WriteLine(rdr[3]);
                Console.WriteLine(rdr[4]);
            }
               Console.Read();

        }
    }
}