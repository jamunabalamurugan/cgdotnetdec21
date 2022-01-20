using System;
using System.Data;
using AdoProductDataAccessLayer;
namespace AdoProductBAL
{
    public class ProductBAL
    {
        ProducRetrieve pr = new ProducRetrieve();

        public DataSet SelectDataBAL()
        {
            DataSet ds = pr.SelectData();

            //Any logic before sending the data

            if (ds.Tables.Count > 0)
                return ds;
            else
                return null;
        }
        public int InsertBAL(string pname,int cid,double price)
        {
            //Implement our Business Logic before we insert by calling the DAL class Insert method

            int x = pr.InsertData(pname,cid,price);
            return x;
        }

    }
}
