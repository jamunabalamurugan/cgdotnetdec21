using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoProductDataAccessLayer
{
    public class ProducRetrieve
    {

        public DataSet SelectData()
        {
           SqlConnection conn = new SqlConnection(@"Data Source=JAMUNA\SQLEXPRESS;initial catalog=northwind;user id=sa;password=newuser123#");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from products", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int InsertData(string pname,int cid,double price)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=JAMUNA\SQLEXPRESS;initial catalog=northwind;user id=sa;password=newuser123#");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert products(productname,categoryid,unitprice) values(@pname,@cid,@price)", conn);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@cid",cid);
            cmd.Parameters.AddWithValue("@price",price);
            int z = cmd.ExecuteNonQuery();
            return z;
        }

    }
}
