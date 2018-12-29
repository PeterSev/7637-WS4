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
            this.colorProgressBar = new _7637_WS4.ColorProgressBar();
            this.btnStopAllTests = new System.Windows.Forms.Button();
            this.btnRunAllTests = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.colorProgressBar);
            this.groupBox1.Controls.Add(this.btnStopAllTests);
            this.groupBox1.Controls.Add(this.btnRunAllTests);
            this.groupBox1.Controls.Add(this.btnMeasure);
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
            this.groupBox1.Size = new System.Drawing.Size(555, 215);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tests";
            // 
            // colorProgressBar
            // 
            this.colorProgressBar.BackColor = System.Drawing.Color.White;
            this.colorProgressBar.BorderColor = System.Drawing.Color.Black;
            this.colorProgressBar.BorderWidth = 0;
            this.colorProgressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorProgressBar.Location = new System.Drawing.Point(6, 113);
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
            // btnStopAllTests
            // 
            this.btnStopAllTests.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopAllTests.ForeColor = System.Drawing.Color.White;
            this.btnStopAllTests.Location = new System.Drawing.Point(337, 82);
            this.btnStopAllTests.Name = "btnStopAllTests";
            this.btnStopAllTests.Size = new System.Drawing.Size(142, 25);
            this.btnStopAllTests.TabIndex = 18;
            this.btnStopAllTests.Text = "Stop All Tests";
            this.btnStopAllTests.UseVisualStyleBackColor = false;
            this.btnStopAllTests.Visible = false;
            this.btnStopAllTests.Click += new System.EventHandler(this.btnStopAllTests_Click);
            // 
            // btnRunAllTests
            // 
            this.btnRunAllTests.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunAllTests.ForeColor = System.Drawing.Color.White;
            this.btnRunAllTests.Location = new System.Drawing.Point(189, 82);
            this.btnRunAllTests.Name = "btnRunAllTests";
            this.btnRunAllTests.Size = new System.Drawing.Size(142, 25);
            this.btnRunAllTests.TabIndex = 17;
            this.btnRunAllTests.Text = "Run All Tests";
            this.btnRunAllTests.UseVisualStyleBackColor = false;
            this.btnRunAllTests.Click += new System.EventHandler(this.btnRunAllTests_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMeasure.ForeColor = System.Drawing.Color.White;
            this.btnMeasure.Location = new System.Drawing.Point(337, 19);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(73, 25);
            this.btnMeasure.TabIndex = 16;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.button1_Click);
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
            this.btnStopIndTest.Visible = false;
            this.btnStopIndTest.Click += new System.EventHandler(this.btnStopIndTest_Click);
            // 
            // txtDAQInfo
            // 
            this.txtDAQInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtDAQInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDAQInfo.ForeColor = System.Drawing.Color.White;
            this.txtDAQInfo.Location = new System.Drawing.Point(6, 144);
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
            this.numTest.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(73, 23);
            this.numTest.TabIndex = 4;
            this.numTest.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.ClientSize = new System.Drawing.Size(577, 235);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button btnRunAllTests;
        private System.Windows.Forms.Button btnStopAllTests;
        private ColorProgressBar colorProgressBar;
    }
}