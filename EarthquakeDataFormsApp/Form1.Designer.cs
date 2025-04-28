namespace EarthquakeDataFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            radioButtonAfad = new RadioButton();
            radioButtonKandilli = new RadioButton();
            textBoxTimer = new TextBox();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            textBoxCount = new TextBox();
            buttonDatas = new Button();
            buttonTimer = new Button();
            dataGridView1 = new DataGridView();
            timerLabel = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButtonAbout = new ToolStripButton();
            toolStripButtonUpdate = new ToolStripButton();
            toolStripButtonContact = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(1066, 58);
            label1.Name = "label1";
            label1.Size = new Size(178, 37);
            label1.TabIndex = 1;
            label1.Text = "Veri Kaynağı";
            // 
            // radioButtonAfad
            // 
            radioButtonAfad.AutoSize = true;
            radioButtonAfad.Checked = true;
            radioButtonAfad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            radioButtonAfad.Location = new Point(1066, 120);
            radioButtonAfad.Name = "radioButtonAfad";
            radioButtonAfad.Size = new Size(66, 25);
            radioButtonAfad.TabIndex = 2;
            radioButtonAfad.TabStop = true;
            radioButtonAfad.Text = "AFAD";
            radioButtonAfad.UseVisualStyleBackColor = true;
            radioButtonAfad.CheckedChanged += radioButtonAfad_CheckedChanged;
            // 
            // radioButtonKandilli
            // 
            radioButtonKandilli.AutoSize = true;
            radioButtonKandilli.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            radioButtonKandilli.Location = new Point(1066, 151);
            radioButtonKandilli.Name = "radioButtonKandilli";
            radioButtonKandilli.Size = new Size(79, 25);
            radioButtonKandilli.TabIndex = 3;
            radioButtonKandilli.Text = "Kandilli";
            radioButtonKandilli.UseVisualStyleBackColor = true;
            radioButtonKandilli.CheckedChanged += radioButtonKandilli_CheckedChanged;
            // 
            // textBoxTimer
            // 
            textBoxTimer.Location = new Point(1066, 258);
            textBoxTimer.Name = "textBoxTimer";
            textBoxTimer.Size = new Size(43, 23);
            textBoxTimer.TabIndex = 4;
            textBoxTimer.Text = "5";
            textBoxTimer.KeyPress += textBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(1066, 218);
            label2.Name = "label2";
            label2.Size = new Size(293, 37);
            label2.TabIndex = 5;
            label2.Text = "Tekrar Süresi (Saniye)";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(1066, 327);
            label5.Name = "label5";
            label5.Size = new Size(236, 37);
            label5.TabIndex = 8;
            label5.Text = "Veri Sayısı (Adet)";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(1066, 367);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(43, 23);
            textBoxCount.TabIndex = 7;
            textBoxCount.Text = "20";
            textBoxCount.TextChanged += textBox_TextChanged;
            textBoxCount.KeyPress += textBox_KeyPress;
            // 
            // buttonDatas
            // 
            buttonDatas.BackColor = Color.MediumSeaGreen;
            buttonDatas.Location = new Point(1066, 449);
            buttonDatas.Name = "buttonDatas";
            buttonDatas.Size = new Size(121, 45);
            buttonDatas.TabIndex = 9;
            buttonDatas.Text = "Değişkenleri Güncelle";
            buttonDatas.UseVisualStyleBackColor = false;
            buttonDatas.Click += buttonDatas_Click;
            // 
            // buttonTimer
            // 
            buttonTimer.BackColor = Color.LightCoral;
            buttonTimer.Location = new Point(1238, 449);
            buttonTimer.Name = "buttonTimer";
            buttonTimer.Size = new Size(121, 45);
            buttonTimer.TabIndex = 10;
            buttonTimer.Text = "Sayacı Durdur";
            buttonTimer.UseVisualStyleBackColor = false;
            buttonTimer.Click += buttonTimer_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1009, 525);
            dataGridView1.TabIndex = 11;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            timerLabel.Location = new Point(1066, 558);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(188, 25);
            timerLabel.TabIndex = 12;
            timerLabel.Text = "Gelen Veri: 0 Saniye";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAbout, toolStripButtonUpdate, toolStripButtonContact });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1386, 25);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAbout
            // 
            toolStripButtonAbout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAbout.Image = (Image)resources.GetObject("toolStripButtonAbout.Image");
            toolStripButtonAbout.ImageTransparentColor = Color.Magenta;
            toolStripButtonAbout.Name = "toolStripButtonAbout";
            toolStripButtonAbout.Size = new Size(61, 22);
            toolStripButtonAbout.Text = "Hakkında";
            toolStripButtonAbout.Click += toolStripButtonAbout_Click;
            // 
            // toolStripButtonUpdate
            // 
            toolStripButtonUpdate.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonUpdate.Image = (Image)resources.GetObject("toolStripButtonUpdate.Image");
            toolStripButtonUpdate.ImageTransparentColor = Color.Magenta;
            toolStripButtonUpdate.Name = "toolStripButtonUpdate";
            toolStripButtonUpdate.Size = new Size(133, 22);
            toolStripButtonUpdate.Text = "Güncellemeleri Denetle";
            toolStripButtonUpdate.Click += toolStripButtonUpdate_Click;
            // 
            // toolStripButtonContact
            // 
            toolStripButtonContact.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonContact.Image = (Image)resources.GetObject("toolStripButtonContact.Image");
            toolStripButtonContact.ImageTransparentColor = Color.Magenta;
            toolStripButtonContact.Name = "toolStripButtonContact";
            toolStripButtonContact.Size = new Size(72, 22);
            toolStripButtonContact.Text = "Sorun Bildir";
            toolStripButtonContact.Click += toolStripButtonContact_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 607);
            Controls.Add(toolStrip1);
            Controls.Add(timerLabel);
            Controls.Add(buttonTimer);
            Controls.Add(buttonDatas);
            Controls.Add(label5);
            Controls.Add(textBoxCount);
            Controls.Add(label2);
            Controls.Add(textBoxTimer);
            Controls.Add(radioButtonKandilli);
            Controls.Add(radioButtonAfad);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Earthquake Monitor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private RadioButton radioButtonAfad;
        private RadioButton radioButtonKandilli;
        private TextBox textBoxTimer;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label label5;
        private TextBox textBoxCount;
        private Button buttonDatas;
        private Button buttonTimer;
        private DataGridView dataGridView1;
        private Label timerLabel;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAbout;
        private ToolStripButton toolStripButtonUpdate;
        private ToolStripButton toolStripButtonContact;
    }
}
