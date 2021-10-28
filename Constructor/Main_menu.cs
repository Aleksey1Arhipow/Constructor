using System;
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
        int count, count2;
        int x = 11, y = 14;
        int last = -1;
        int ch = -1;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            count2++;
            int a = this.Controls["vyb" + ch].Size.Width + 5;
            int b = this.Controls["vyb" + ch].Size.Height + 5;
            this.Controls["vyb" + ch].Size = new Size(a,b);
            if (count2 == 5) timer1.Stop();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_people add = new Add_people();
            this.Hide();
            add.Show();
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
             ch = rnd.Next(0, people.Count);
            txt_num.Text = ch.ToString();

            Controls.RemoveByKey("vyb" + last);
            Controls.RemoveByKey("tx" + last);
            last = ch;


            string path = Environment.CurrentDirectory + people[ch][2];
            this.Controls.Add(new PictureBox { Name = "vyb" + ch, Location = new Point(btn_restart.Location.X, btn_restart.Location.Y+80), Size = new Size(153, 113 ), SizeMode = PictureBoxSizeMode.StretchImage, Image = Image.FromFile(path), Anchor=AnchorStyles.None });
            this.Controls.Add(new Label { Name = "tx" + ch, Location = new Point(btn_restart.Location.X, btn_restart.Location.Y + 200), Text = people[ch][1], Size = new Size(140, 26) });
            people.RemoveAt(ch);
            count = people.Count;
            panel1.Controls.Clear();
            x = 11; y = 14;
            ElementCreator();
            if (count < 1)
            {
                foreach (Control con in this.Controls) con.Enabled = false;
                btn_restart.Enabled = true;
                timer1.Start();
            }

        }

    }
}
