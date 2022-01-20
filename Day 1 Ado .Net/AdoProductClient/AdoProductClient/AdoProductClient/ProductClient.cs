using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoProductBAL;
using System.Data;

namespace AdoProductClient
{
    partial class ProductClient
    {
        static void Main(string[] args)
        {
            ProductBAL bl = new ProductBAL();
           
            DataSet ds=bl.SelectDataBAL();//This is turn will call the insert method of DAL class
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dr.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }

            int rows = bl.InsertBAL( "Coffee", 1, 25);
            if(rows>0)
                Console.WriteLine("Product inserted in the Database succesfully");
            Console.ReadKey();
        }
    }

    partial class ProductClient
    {
        public void AcceptProduct()
        {

        }
    }
}
