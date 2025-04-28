namespace EarthquakeDataFormsApp
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            labelVersion = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            richTextBox1 = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(677, 86);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(253, 37);
            label1.TabIndex = 0;
            label1.Text = "Earthquake Monitor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(16, 110);
            label2.Name = "label2";
            label2.Size = new Size(124, 17);
            label2.TabIndex = 1;
            label2.Text = "Earthquake Monitor";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelVersion.Location = new Point(16, 140);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(52, 17);
            labelVersion.TabIndex = 2;
            labelVersion.Text = "Sürüm: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(16, 170);
            label3.Name = "label3";
            label3.Size = new Size(143, 17);
            label3.TabIndex = 3;
            label3.Text = "© 2025 Deniz Sarıbayır";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(16, 200);
            label4.Name = "label4";
            label4.Size = new Size(123, 17);
            label4.TabIndex = 4;
            label4.Text = "Tüm hakları saklıdır.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(16, 252);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 5;
            label5.Text = "Detaylar";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 280);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(650, 96);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 385);
            Controls.Add(richTextBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelVersion);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "About";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hakkında";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label labelVersion;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox richTextBox1;
    }
}