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
            richTextBox1 = new RichTextBox();
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
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(27, 30);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1009, 517);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(1066, 30);
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
            radioButtonAfad.Location = new Point(1066, 92);
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
            radioButtonKandilli.Location = new Point(1066, 123);
            radioButtonKandilli.Name = "radioButtonKandilli";
            radioButtonKandilli.Size = new Size(79, 25);
            radioButtonKandilli.TabIndex = 3;
            radioButtonKandilli.Text = "Kandilli";
            radioButtonKandilli.UseVisualStyleBackColor = true;
            radioButtonKandilli.CheckedChanged += radioButtonKandilli_CheckedChanged;
            // 
            // textBoxTimer
            // 
            textBoxTimer.Location = new Point(1066, 230);
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
            label2.Location = new Point(1066, 190);
            label2.Name = "label2";
            label2.Size = new Size(293, 37);
            label2.TabIndex = 5;
            label2.Text = "Tekrar Süresi (Saniye)";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(1066, 299);
            label5.Name = "label5";
            label5.Size = new Size(236, 37);
            label5.TabIndex = 8;
            label5.Text = "Veri Sayısı (Adet)";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(1066, 339);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(43, 23);
            textBoxCount.TabIndex = 7;
            textBoxCount.Text = "10";
            textBoxCount.TextChanged += textBox_TextChanged;
            textBoxCount.KeyPress += textBox_KeyPress;
            // 
            // buttonDatas
            // 
            buttonDatas.Location = new Point(1066, 421);
            buttonDatas.Name = "buttonDatas";
            buttonDatas.Size = new Size(121, 45);
            buttonDatas.TabIndex = 9;
            buttonDatas.Text = "Değişkenleri Güncelle";
            buttonDatas.UseVisualStyleBackColor = true;
            buttonDatas.Click += buttonDatas_Click;
            // 
            // buttonTimer
            // 
            buttonTimer.Location = new Point(1238, 421);
            buttonTimer.Name = "buttonTimer";
            buttonTimer.Size = new Size(121, 45);
            buttonTimer.TabIndex = 10;
            buttonTimer.Text = "Sayacı Durdur";
            buttonTimer.UseVisualStyleBackColor = true;
            buttonTimer.Click += buttonTimer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 614);
            Controls.Add(buttonTimer);
            Controls.Add(buttonDatas);
            Controls.Add(label5);
            Controls.Add(textBoxCount);
            Controls.Add(label2);
            Controls.Add(textBoxTimer);
            Controls.Add(radioButtonKandilli);
            Controls.Add(radioButtonAfad);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "EarthquakeDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
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
    }
}
