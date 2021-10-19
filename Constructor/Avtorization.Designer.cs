namespace Constructor
{
    partial class Avtorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_log.Location = new System.Drawing.Point(195, 214);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(372, 26);
            this.txt_log.TabIndex = 0;
            // 
            // btn_reg
            // 
            this.btn_reg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reg.Location = new System.Drawing.Point(195, 378);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(126, 38);
            this.btn_reg.TabIndex = 1;
            this.btn_reg.Text = "Регистрация";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // Avtorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.txt_log);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Avtorization";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_reg;
    }
}

