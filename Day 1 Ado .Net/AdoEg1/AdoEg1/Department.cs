using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoEg1
{
    class Department
    {
        int deptno;
        string dname;
        string loc;

        public int Deptno { get => deptno; set => deptno = value; }
        public string Dname { get => dname; set => dname = value; }
        public string Loc { get => loc; set => loc = value; }
        public Department(int depno,string name,string location)
        {
            deptno = depno;
            dname = name;
            loc = location;
        }
        public override string ToString()
        {
            return deptno + "\t" + dname + "\t" + loc;
        }

    }

    class DepartmentDisConnected
    {
        public SqlConnection conn= new SqlConnection(@"data source=MSBEEYS\HBSQLEXPRESS;initial catalog=Sample;user id=sa;password=newuser123#");
        SqlDataAdapter da;
        DataSet ds=new DataSet();

        public void GetAllDepartments()
        {
            
            da = new SqlDataAdapter("select * from departments", conn);
            da.Fill(ds, "dept");
            da = new SqlDataAdapter("select * from employees", conn);
            da.Fill(ds, "employees");
            Console.WriteLine("The connection state " + conn.State);

            foreach (DataRow item in ds.Tables["dept"].Rows)
            {
                Console.WriteLine(item["deptno"]+"\t"+item["dname"]+"\t"+item["loc"]);
            }

            foreach (DataRow item in ds.Tables["employees"].Rows)
            {
                Console.WriteLine(item["empno"] + "\t" + item["ename"] + "\t" + item["job"]);
            }


        }
    }
}
