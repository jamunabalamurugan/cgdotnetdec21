using System;
using System.Collections.Generic;
using System.Text;

namespace AdoEg2
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

    public class UseClient
    {
        List<Client> clients = new List<Client>();
    }
}
