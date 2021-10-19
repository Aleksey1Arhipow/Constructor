using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constructor
{
    class DB
    {
        public SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Constructor;Integrated Security=True");

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

        public string ReturnFromDB(string s)
        {
            OpenConnection();
            SqlCommand com = new SqlCommand(s, GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = com;
            try
            {
                adapter.Fill(table);
                CloseConnection();
                return table.Rows[0][0].ToString();
            }
            catch
            {
                CloseConnection();
                return "";
            }

        }

        public void NonQery(string s)
        {
            OpenConnection();
            SqlCommand com = new SqlCommand(s, GetConnection());
            com.ExecuteNonQuery();
            CloseConnection();
        }

        public void ComboLoad(ComboBox combo, string s, string z)
        {
            OpenConnection();
            SqlCommand com = new SqlCommand(s,GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = com;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    combo.Items.Add(table.Rows[i][j]);
                }
            }
            combo.SelectedIndex = -1;
            CloseConnection();
        }


    }

}
