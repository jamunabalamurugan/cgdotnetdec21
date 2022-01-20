using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ADOExample
{
    class storedpceg
    {
        public static void Main()
        {
            SqlConnection conn = new SqlConnection("Data Source=jamuna\\sqlexpress;Initial Catalog=Northwind;Integrated Security=SSPI");
            Console.WriteLine("Connection created");
            Console.WriteLine("Enter the value");
            int i = Convert.ToInt32(Console.ReadLine());
            conn.Open();
            
            SqlCommand cmd = new SqlCommand("getcatname1", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;            
            SqlParameter param = new SqlParameter("@id", i);
            cmd.Parameters.Add(param);

            SqlDataReader rdr = null;
            
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                Console.WriteLine(rdr[1]);
                Console.WriteLine(rdr[2]);
               // Console.WriteLine(rdr[3]);
               // Console.WriteLine(rdr[4]);
            }
               Console.Read();

        }
    }
}
    

