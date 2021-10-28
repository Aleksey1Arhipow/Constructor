using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Constructor
{
    public partial class Add_people : Form
    {
        string filename = "";
        string filetext = "";
        string photo = "";
        DB db = new DB();
        public Add_people()
        {
            InitializeComponent();
        }

        private void btn_photo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images(*.jpg)|*.jpg|Images(*.png)|*.png|All files(*.*)|(*.*)";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            filename = openFileDialog1.FileName;
            //MessageBox.Show(filename);
            filetext = Path.GetFileName(openFileDialog1.FileName);
            pic_photo.Image = Image.FromFile(filename);
            btn_photo.Text = filetext;
            photo = @"\pictures\" + filetext;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_FIO.Text == "") MessageBox.Show("Заполните ФИО");
            else
            {
                if (!File.Exists(Environment.CurrentDirectory + @"\pictures\" + filetext))
                    try 
                    {
                        File.Copy(filename, Environment.CurrentDirectory + @"\pictures\" + filetext);
                    }
                    catch { }
            }
            if (btn_photo.Text == "Выбрать") photo = @"\pictures\" + "5254456.png";
            db.NonQuerry("INSERT INTO People VALUES (N'"+txt_FIO.Text+"',N'"+photo+"')");
            MessageBox.Show("Yes");
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Main_menu mm = new Main_menu();
            this.Hide();
            mm.Show();
        }
    }
}
