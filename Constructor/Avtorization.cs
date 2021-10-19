using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constructor
{
    public partial class Avtorization : Form
    {
        int x = 195, y = 214;
        int x1 = 441, y2 = 378;

        public Avtorization()
        {
            InitializeComponent();
            ElementConstructor();
            this.Controls["btn_sign"].Click += new System.EventHandler(this.btn_sign_Click);
        }
        private void ElementConstructor()
        {
            y += 60;
            this.Controls.Add(new TextBox { Name = "txt_pas", Location = new Point(x, y), Size = txt_log.Size, Anchor = AnchorStyles.None });

            this.Controls.Add(new Button { Name = "btn_sign", Location = new Point(x1, y2), Size = btn_reg.Size, Anchor = AnchorStyles.None, Text = "Вход", FlatStyle = FlatStyle.Flat, TabIndex = 1, UseVisualStyleBackColor = true });
        }


        private void btn_reg_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.Show();
        }  
        private void btn_sign_Click(object sender, EventArgs e)
        {
            Main_menu mm = new Main_menu();
            this.Hide();
            mm.Show();
        }

     
        
    }
}
