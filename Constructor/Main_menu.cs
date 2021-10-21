﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constructor
{
    public partial class Main_menu : Form
    {
        List<string[]> people = new List<string[]>();
        DB db = new DB();
        int count;
        int x = 11, y = 14;
        public Main_menu()
        {
            InitializeComponent();
            LoadList();
            count = people.Count;
            ElementCreator();
            btn_generate.Click += new EventHandler(this.btn_generate_Click);
        }

        private void LoadList()
        {
            db.OpenConnection();
            string s = "SELECT * FROM People";
            SqlCommand com = new SqlCommand(s,db.GetConnection());
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) 
            {
                people.Add(new string[3]);
                people[people.Count - 1][0] = reader[0].ToString();
                people[people.Count - 1][1] = reader[1].ToString();
                people[people.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            db.CloseConnection();
        }

        private void ElementCreator()
        {
            for (int i = 0; i < count; i++)
            {
                string path = Environment.CurrentDirectory + people[i][2];
                this.Controls["panel1"].Controls.Add(new PictureBox { Name = "photo" + i, Location = new Point(x, y), Size = new Size(136, 125), SizeMode = PictureBoxSizeMode.StretchImage, Image = Image.FromFile(path) });
                this.Controls["panel1"].Controls.Add(new Label { Name = "lab" + i, Location = new Point(x, y + 137), Text = people[i][1], Size = new Size(140, 26) });

                if ((i + 1) % 3 == 0)
                {
                    x = 11; y+=205;
                   

                }
                else
                {
                     
                    x += 162;
                }
            }
                
        }
        private void btn_generate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
           int  ch= rnd.Next(0, people.Count - 1);
            txt_num.Text = ch.ToString();
        }

    }
}
