namespace _7637_WS4
{
    partial class frmBU_Ind_Test
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStopIndTest = new System.Windows.Forms.Button();
            this.txtDAQInfo = new System.Windows.Forms.TextBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResultOfInd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTestCount = new System.Windows.Forms.Label();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.btnRunIndTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnStopIndTest);
            this.groupBox1.Controls.Add(this.txtDAQInfo);
            this.groupBox1.Controls.Add(this.btnShowReport);
            this.groupBox1.Controls.Add(this.lblRunCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblResultOfInd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTestCount);
            this.groupBox1.Controls.Add(this.numTest);
            this.groupBox1.Controls.Add(this.btnRunIndTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 154);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tests";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(337, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Measure";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStopIndTest
            // 
            this.btnStopIndTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopIndTest.ForeColor = System.Drawing.Color.White;
            this.btnStopIndTest.Location = new System.Drawing.Point(337, 49);
            this.btnStopIndTest.Name = "btnStopIndTest";
            this.btnStopIndTest.Size = new System.Drawing.Size(73, 25);
            this.btnStopIndTest.TabIndex = 16;
            this.btnStopIndTest.Text = "Stop";
            this.btnStopIndTest.UseVisualStyleBackColor = false;
            this.btnStopIndTest.Click += new System.EventHandler(this.btnStopIndTest_Click);
            // 
            // txtDAQInfo
            // 
            this.txtDAQInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtDAQInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDAQInfo.ForeColor = System.Drawing.Color.White;
            this.txtDAQInfo.Location = new System.Drawing.Point(6, 82);
            this.txtDAQInfo.Multiline = true;
            this.txtDAQInfo.Name = "txtDAQInfo";
            this.txtDAQInfo.ReadOnly = true;
            this.txtDAQInfo.Size = new System.Drawing.Size(541, 64);
            this.txtDAQInfo.TabIndex = 8;
            this.txtDAQInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnShowReport.ForeColor = System.Drawing.Color.White;
            this.btnShowReport.Location = new System.Drawing.Point(466, 19);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(75, 25);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Report";
            this.btnShowReport.UseVisualStyleBackColor = false;
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(277, 23);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(16, 17);
            this.lblRunCount.TabIndex = 15;
            this.lblRunCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Result:";
            // 
            // lblResultOfInd
            // 
            this.lblResultOfInd.AutoSize = true;
            this.lblResultOfInd.Location = new System.Drawing.Point(502, 54);
            this.lblResultOfInd.Name = "lblResultOfInd";
            this.lblResultOfInd.Size = new System.Drawing.Size(16, 17);
            this.lblResultOfInd.TabIndex = 12;
            this.lblResultOfInd.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(54, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Index of single test:";
            // 
            // lblTestCount
            // 
            this.lblTestCount.AutoSize = true;
            this.lblTestCount.Location = new System.Drawing.Point(198, 23);
            this.lblTestCount.Name = "lblTestCount";
            this.lblTestCount.Size = new System.Drawing.Size(16, 17);
            this.lblTestCount.TabIndex = 6;
            this.lblTestCount.Text = "0";
            // 
            // numTest
            // 
            this.numTest.Location = new System.Drawing.Point(189, 53);
            this.numTest.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(73, 23);
            this.numTest.TabIndex = 4;
            // 
            // btnRunIndTest
            // 
            this.btnRunIndTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunIndTest.ForeColor = System.Drawing.Color.White;
            this.btnRunIndTest.Location = new System.Drawing.Point(268, 50);
            this.btnRunIndTest.Name = "btnRunIndTest";
            this.btnRunIndTest.Size = new System.Drawing.Size(63, 25);
            this.btnRunIndTest.TabIndex = 3;
            this.btnRunIndTest.Text = "Run";
            this.btnRunIndTest.UseVisualStyleBackColor = false;
            this.btnRunIndTest.Click += new System.EventHandler(this.btnRunIndTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total amount of tests:";
            // 
            // frmBU_Ind_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 172);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBU_Ind_Test";
            this.Text = "frmBU_Ind_Tests";
            this.Activated += new System.EventHandler(this.frmBU_Ind_Tests_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBU_Ind_Tests_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDAQInfo;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblResultOfInd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTestCount;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button btnRunIndTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopIndTest;
        private System.Windows.Forms.Button button1;
    }
}