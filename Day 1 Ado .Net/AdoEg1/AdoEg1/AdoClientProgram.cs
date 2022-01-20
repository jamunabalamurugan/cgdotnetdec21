using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoEg1
{
    //Model
    public class Client
    {
        string client_id;
        string cname;
        string addr;
        string email;
        string phoneno;
        string business;

        public Client()
        {

        }
        public Client(string client_id, string cname, string addr, string email, string phoneno, string business)
        {
            this.client_id = client_id;
            this.cname = cname;
            this.addr = addr;
            this.business = business;
            this.phoneno = phoneno;
            this.email = email;
        }

        public string Client_id { get { return client_id; } set { client_id = value; } }
        public string Cname { get => cname; set => cname = value; }
        public string Addr { get => addr; set => addr = value; }
        public string Email { get => email; set => email = value; }
        public string Phoneno { get => phoneno; set => phoneno = value; }
        public string Business { get => business; set => business = value; }

        public override string ToString()
        {
            return client_id + "\t" + cname + "\t" + addr + "\t" + email + "\t" + business + "\t" + phoneno;
        }
    }
    //Data Access Layer
    class Sample
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        List<Client> clients = new List<Client>();
        public List<Client> clientlist = new List<Client>();
        public Client client = new Client();
        public void GetConnection()
        {
            conn = new SqlConnection(@"data source=MSBEEYS\HBSQLEXPRESS;user id=sa;password=newuser123#;initial catalog=Sample");
            conn.Open();
            Console.WriteLine("Connected to Sample Database  successfully!!!");
        }

        public void PrintAllClients()
        {
            cmd = new SqlCommand("select * from clients");
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            clientlist.Clear();
            while (dr.Read())
            {
              //  Console.WriteLine("Client Id: " + dr[0] + "\tClient Name: " + dr[1] + "\tAddress: " + dr[2]);
                clientlist.Add(new Client(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),dr[4].ToString(),dr[5].ToString()));
            }
            dr.Close();
        }

        public Client PrintClient(string cid)
        {
            //string query1 = "select * from clients where client_id=" + cid ;
            //cmd = new SqlCommand(query1);

            string query2 = "select * from clients where client_id=@clientno";
            cmd = new SqlCommand(query2);

            //SqlParameter param = new SqlParameter("@clientno", cid);
            //cmd.Parameters.Add(param);

            cmd.Parameters.AddWithValue("@clientno", cid);


            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            dr.Read();
            //     Console.WriteLine("Client Id: " + dr[0] + "\tClient Name: " + dr[1] + "\tAddress: " + dr[2]);
            client = new Client(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            dr.Close();
            return client;
         

        }

        public int PrintSingleValue()
        {

            cmd = new SqlCommand("select count(*) from clients where business='reseller'",conn);
            var result= (int)cmd.ExecuteScalar();
            // Console.WriteLine(result);
            return result;

        }
        public void AcceptClient(string cid,string cname,string bus,string email)
        {
           
            {
                // string cid, cname, bus, em;
                // cid = Console.ReadLine();
                // cname = Console.ReadLine();
                // bus = Console.ReadLine();
                // em = Console.ReadLine();
                //// insert clients(client_id, cname, business, email)
                // //values('1007', 'AT', 'consultant', 'at@gmail.com')
                // cmd = new SqlCommand("insert clients(client_id,cname,business,email) values(@clientid,@clientname,@business,@email)",conn);
                // cmd.Parameters.AddWithValue("@clientid", cid);
                // cmd.Parameters.AddWithValue("@clientname", cname);
                // cmd.Parameters.AddWithValue("@business", bus);
                // cmd.Parameters.AddWithValue("@email", em);
            }
            client.Client_id = cid;
            client.Cname = cname;
            client.Business = bus;
            client.Email =email;
        }
        public void AddClient(Client cobj)
        {
         
            // insert clients(client_id, cname, business, email)
            //values('1007', 'AT', 'consultant', 'at@gmail.com')
            cmd = new SqlCommand("insert clients(client_id,cname,business,email) values(@clientid,@clientname,@business,@email)", conn);
            cmd.Parameters.AddWithValue("@clientid", cobj.Client_id);
            cmd.Parameters.AddWithValue("@clientname",cobj.Cname);
            cmd.Parameters.AddWithValue("@business", cobj.Business);
            cmd.Parameters.AddWithValue("@email", cobj.Email);

            int rows=cmd.ExecuteNonQuery();
            if (rows != 0)
            {
                Console.WriteLine("{0} Client added", rows);
                clientlist.Add(client);
            }

        }

        public int UpdateClient(string clientid,string clientname)
        {
            cmd = new SqlCommand("prcUpdateClients", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", clientid);
            cmd.Parameters.AddWithValue("@name", clientname);
            int rows=cmd.ExecuteNonQuery();
            return rows;

        }
    }

    //Presentation Layer or User Interface Layer
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to ADO.Net programming using CSharp!");
            //Sample s = new Sample();
            //s.GetConnection();
            //s.PrintAllClients();
            ////   Console.WriteLine("Enter client id");
            //string cid = Console.ReadLine();
            //Console.WriteLine(s.PrintClient(cid));
            //Console.WriteLine(s.PrintSingleValue());
            //s.AcceptClient("1012", "Kayan", "consultant", "kanav@gmail.com");

            //s.AddClient(s.client);

            //Displaying all the clients from the clientlist
            //foreach (var item in s.clientlist)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("updated {0} records in clients table", s.UpdateClient("1011", "Kanav Consultancy"));
            DepartmentDisConnected dd = new DepartmentDisConnected();
            dd.GetAllDepartments();
            Console.ReadKey();
        }
    }
}
