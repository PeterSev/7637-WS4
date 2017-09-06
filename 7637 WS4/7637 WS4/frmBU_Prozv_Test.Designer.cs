namespace _7637_WS4
{
    partial class frmBU_Prozv_Test
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
            this.btnShowReport = new System.Windows.Forms.Button();
            this.btnRunDAQTest = new System.Windows.Forms.Button();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.btnRunDAQ = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResultOfDAQ = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTestCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRunAllDAQTest = new System.Windows.Forms.Button();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStopAllTest = new System.Windows.Forms.Button();
            this.colorProgressBar = new _7637_WS4.ColorProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(750, 12);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(75, 23);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // btnRunDAQTest
            // 
            this.btnRunDAQTest.Location = new System.Drawing.Point(292, 52);
            this.btnRunDAQTest.Name = "btnRunDAQTest";
            this.btnRunDAQTest.Size = new System.Drawing.Size(75, 25);
            this.btnRunDAQTest.TabIndex = 3;
            this.btnRunDAQTest.Text = "Запуск";
            this.btnRunDAQTest.UseVisualStyleBackColor = true;
            this.btnRunDAQTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // numTest
            // 
            this.numTest.Location = new System.Drawing.Point(213, 55);
            this.numTest.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(73, 23);
            this.numTest.TabIndex = 4;
            // 
            // btnRunDAQ
            // 
            this.btnRunDAQ.Location = new System.Drawing.Point(245, 71);
            this.btnRunDAQ.Name = "btnRunDAQ";
            this.btnRunDAQ.Size = new System.Drawing.Size(75, 23);
            this.btnRunDAQ.TabIndex = 5;
            this.btnRunDAQ.Text = "RunDAQ";
            this.btnRunDAQ.UseVisualStyleBackColor = true;
            this.btnRunDAQ.Click += new System.EventHandler(this.btnRunDAQ_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorProgressBar);
            this.groupBox1.Controls.Add(this.btnStopAllTest);
            this.groupBox1.Controls.Add(this.lblT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblRunCount);
            this.groupBox1.Controls.Add(this.btnRunAllDAQTest);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblResultOfDAQ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTestCount);
            this.groupBox1.Controls.Add(this.numTest);
            this.groupBox1.Controls.Add(this.btnRunDAQTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(104, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 154);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тесты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Результат:";
            // 
            // lblResultOfDAQ
            // 
            this.lblResultOfDAQ.AutoSize = true;
            this.lblResultOfDAQ.Location = new System.Drawing.Point(478, 57);
            this.lblResultOfDAQ.Name = "lblResultOfDAQ";
            this.lblResultOfDAQ.Size = new System.Drawing.Size(16, 17);
            this.lblResultOfDAQ.TabIndex = 12;
            this.lblResultOfDAQ.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Запуск одиночного теста:";
            // 
            // lblTestCount
            // 
            this.lblTestCount.AutoSize = true;
            this.lblTestCount.Location = new System.Drawing.Point(210, 25);
            this.lblTestCount.Name = "lblTestCount";
            this.lblTestCount.Size = new System.Drawing.Size(16, 17);
            this.lblTestCount.TabIndex = 6;
            this.lblTestCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Общее количество тестов:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OpenRelay54Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "CloseRelay54Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRunAllDAQTest
            // 
            this.btnRunAllDAQTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunAllDAQTest.ForeColor = System.Drawing.Color.White;
            this.btnRunAllDAQTest.Location = new System.Drawing.Point(27, 85);
            this.btnRunAllDAQTest.Name = "btnRunAllDAQTest";
            this.btnRunAllDAQTest.Size = new System.Drawing.Size(172, 25);
            this.btnRunAllDAQTest.TabIndex = 14;
            this.btnRunAllDAQTest.Text = "Запуск всех тестов";
            this.btnRunAllDAQTest.UseVisualStyleBackColor = false;
            this.btnRunAllDAQTest.Click += new System.EventHandler(this.btnRunAllDAQTest_Click);
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(289, 25);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(16, 17);
            this.lblRunCount.TabIndex = 15;
            this.lblRunCount.Text = "0";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(375, 93);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(16, 17);
            this.lblT.TabIndex = 17;
            this.lblT.Text = "t:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Время:";
            // 
            // btnStopAllTest
            // 
            this.btnStopAllTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopAllTest.Enabled = false;
            this.btnStopAllTest.ForeColor = System.Drawing.Color.White;
            this.btnStopAllTest.Location = new System.Drawing.Point(208, 85);
            this.btnStopAllTest.Name = "btnStopAllTest";
            this.btnStopAllTest.Size = new System.Drawing.Size(75, 25);
            this.btnStopAllTest.TabIndex = 18;
            this.btnStopAllTest.Text = "Стоп";
            this.btnStopAllTest.UseVisualStyleBackColor = false;
            this.btnStopAllTest.Click += new System.EventHandler(this.btnStopAllTest_Click);
            // 
            // colorProgressBar
            // 
            this.colorProgressBar.BackColor = System.Drawing.Color.White;
            this.colorProgressBar.BorderColor = System.Drawing.Color.Black;
            this.colorProgressBar.BorderWidth = 0;
            this.colorProgressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorProgressBar.Location = new System.Drawing.Point(6, 116);
            this.colorProgressBar.MaxValue = 100;
            this.colorProgressBar.MinValue = 0;
            this.colorProgressBar.Name = "colorProgressBar";
            this.colorProgressBar.ProgressColor = System.Drawing.Color.LightGreen;
            this.colorProgressBar.ProgressTextType = _7637_WS4.ColorProgressBar.FsProgressTextType.Percent;
            this.colorProgressBar.ShowProgressText = true;
            this.colorProgressBar.Size = new System.Drawing.Size(541, 25);
            this.colorProgressBar.TabIndex = 19;
            this.colorProgressBar.Value = 0;
            this.colorProgressBar.Visible = false;
            // 
            // frmBU_Prozv_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 452);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRunDAQ);
            this.Controls.Add(this.btnShowReport);
            this.Name = "frmBU_Prozv_Test";
            this.Text = "frmBU_Prozv_Tests";
            this.Activated += new System.EventHandler(this.frmBZ_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBZ_Test_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnRunDAQTest;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button btnRunDAQ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTestCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResultOfDAQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRunAllDAQTest;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStopAllTest;
        private ColorProgressBar colorProgressBar;
    }
}