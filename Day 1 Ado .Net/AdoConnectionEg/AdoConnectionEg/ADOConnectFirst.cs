using System;
using System.Data;
using System.Data.SqlClient;
namespace ConnectionExample1
{
    class ConnectionExample
    {
        static void Main(string[] args)
        {
            //Prepare a connection string with login credentials
            String conString = @"server=MSBEEYS\HBSQLEXPRESS;user=sa;pwd=newuser123#;initial catalog=northwind";
            //create a new object of the SqlConnection class using the connecton string created
            SqlConnection con = new SqlConnection(conString);
            
            try
            {
                //open the connection
                con.Open();
                Console.WriteLine("Connection established successfully");
                Console.WriteLine("Conneted to {0} with the database {1}....", con.DataSource, con.Database);
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                //com.CommandText = "Select customerid,contactname from customers where customerid like 'A%'";
                com.CommandText = "Select * from Suppliers";
                try
                {
                    SqlDataReader dr = com.ExecuteReader();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write(dr.GetName(i)+"\t");
                    }
                    while (dr.Read())
                    {
                        Console.WriteLine();
                        for(int i=0;i<dr.FieldCount;i++)
                        {
                            Console.Write(dr[i] + "\t");
                        }
                        //Console.WriteLine(dr[0]+"\t"+dr[1]+"\t"+dr[2]);

                        //Gets the value of the first column using column index 0.
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                con.Close();
                Console.WriteLine("Connection closed successfully");
            }
            catch (Exception e)
            {
                Console.Write(e.ToString()); Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}