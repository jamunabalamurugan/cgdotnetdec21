using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Day7Project
{
    class Sample
    {
        SqlConnection conn;

        SqlCommand cmd;
        SqlDataReader dr;


        public void GetConnection()
        {
            conn = new SqlConnection(@"Data source=MSBEEYS\HBSQLEXPRESS;user id=sa;password=newuser123#;initial catalog=sample");
            //conn = new SqlConnection(@"Data source=MSBEEYS\HBSQLEXPRESS;initial catalog=Sample;integrated security=true");
            conn.Open();
            Console.WriteLine("Connected to Sample Database!!!");
        }
        public void PrintClientDetails()
        {
            //Using Connected 
            cmd = new SqlCommand("select * from clients",conn);
            //  cmd.Connection = conn;
            //  cmd.CommandText = "select client_ID,cname,Addr,Email,phone from clients";

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }


        }
        public void PrintClientDisconnected()
        {
            cmd = new SqlCommand("select * from clients", conn);
            SqlCommand cmd2 = new SqlCommand("select * from employees", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

            DataSet ds=new DataSet();
            da.Fill(ds,"clients");
            da2.Fill(ds, "employees");
            conn.Close();

            DataTable dtclient = ds.Tables["clients"];
            Console.WriteLine("Printing details of the table {0}", dtclient.TableName);
            foreach (DataRow row in dtclient.Rows)
            {
                foreach (var col in row.ItemArray)
                {
                    Console.Write(col + "\t");
                }
                Console.WriteLine();
            }


            DataTable dtemp = ds.Tables["employees"];
            Console.WriteLine("Printing details of the table {0}",dtemp.TableName);
            foreach (DataRow row in dtemp.Rows)
            {
                foreach (var col in row.ItemArray)
                {
                    Console.Write(col+"\t");
                }
                Console.WriteLine();
            }

            foreach (DataTable dt in ds.Tables)
            {
                foreach (var item in dt.Columns)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
                //To print the rows in the result
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var col in row.ItemArray)
                    {
                        Console.Write(col + "\t");
                    }
                    Console.WriteLine();
                }
            }
            ds.Clear();
        }
 

        public void PrintClient(string usercid)
        {
            //cmd = new SqlCommand("select cname from clients where client_id='1001'", conn);
            cmd = new SqlCommand("select cname from clients where client_id=@cid", conn);
            SqlParameter param = new SqlParameter("@cid",usercid);
            cmd.Parameters.Add(param);
            var str = cmd.ExecuteScalar();
            Console.WriteLine("The client name  is {0}",str);
        }
        public int ChangeBusiness(string business,int cid)
        {
            
            //cmd = new SqlCommand("prcUpdateClient",conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //return cmd.ExecuteNonQuery();

            cmd = new SqlCommand("prcUpdateClientType @totype,@clientid", conn);
            cmd.Parameters.AddWithValue("@totype", business);
            cmd.Parameters.AddWithValue("@clientid", cid);
            return cmd.ExecuteNonQuery();


        }
        public static void Main()
        {
            Sample sample = new Sample();
            sample.GetConnection();
            // sample.PrintClientDetails();
            // Console.WriteLine("Enter client id");
            // int cid = int.Parse(Console.ReadLine());
            // // sample.PrintClient(str);
            // Console.WriteLine("ENter the type of business");
            // string type = Console.ReadLine();
            //int rows=sample.ChangeBusiness(type, cid);
            // Console.WriteLine("The Client table updated {0} rows", rows);
            sample.PrintClientDisconnected();
            Console.ReadKey();
        }
    }
}
