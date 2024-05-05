﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
     class RetrieveData
    {
        public static SqlConnection con = new SqlConnection($@"Server=DESKTOP-F7NVC06\ASEEL;Database=elmasry;User Id=sa;Password=aseel1234;");
      public static DataTable executequery(string text, CommandType com)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = com;
            cmd.CommandText = text;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataAdapter dt = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            dt.Fill(ds);
            return ds.Tables[0];

        }


        public static DataTable executequery(string text, CommandType com, params parameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = com;
            cmd.CommandText = text;
            foreach (parameter prm in param)
            {
                cmd.Parameters.Add(prm.pname, prm.dpt).Value = prm.pvalue;


            }
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dt.Fill(ds);
            return ds.Tables[0];

        }
        public static void executeNonquery(string text, CommandType com, params parameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = com;
            cmd.CommandText = text;
            foreach (parameter prm in param)
            {
                cmd.Parameters.Add(prm.pname, prm.dpt).Value = prm.pvalue;


            }
         
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                cmd.ExecuteNonQuery();
            }
            catch { con.Close(); }


        }
        public class parameter
        {
            public string pname;
            public SqlDbType dpt;
            public object pvalue;
            public parameter(string pname, SqlDbType dpt, object pvalue)
            {
                this.pname = pname;
                this.dpt = dpt;
                this.pvalue = pvalue;
            }

        }
    }
}

