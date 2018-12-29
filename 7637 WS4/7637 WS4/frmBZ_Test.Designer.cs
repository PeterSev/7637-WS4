namespace _7637_WS4
{
    partial class frmBZ_Test
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
            this.grpBPPPTest = new System.Windows.Forms.GroupBox();
            this.txtDAQInfo = new System.Windows.Forms.TextBox();
            this.colorProgressBar = new _7637_WS4.ColorProgressBar();
            this.lblT = new System.Windows.Forms.Label();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTEstCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStopAllTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResultOfDMM = new System.Windows.Forms.Label();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.btnRunAllBPPPTest = new System.Windows.Forms.Button();
            this.btnRunBPPPTest = new System.Windows.Forms.Button();
            this.grpBPPPTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBPPPTest
            // 
            this.grpBPPPTest.Controls.Add(this.txtDAQInfo);
            this.grpBPPPTest.Controls.Add(this.colorProgressBar);
            this.grpBPPPTest.Controls.Add(this.lblT);
            this.grpBPPPTest.Controls.Add(this.lblRunCount);
            this.grpBPPPTest.Controls.Add(this.btnShowReport);
            this.grpBPPPTest.Controls.Add(this.label6);
            this.grpBPPPTest.Controls.Add(this.label5);
            this.grpBPPPTest.Controls.Add(this.lblTEstCount);
            this.grpBPPPTest.Controls.Add(this.label4);
            this.grpBPPPTest.Controls.Add(this.btnStopAllTest);
            this.grpBPPPTest.Controls.Add(this.label1);
            this.grpBPPPTest.Controls.Add(this.lblResultOfDMM);
            this.grpBPPPTest.Controls.Add(this.numTest);
            this.grpBPPPTest.Controls.Add(this.btnRunAllBPPPTest);
            this.grpBPPPTest.Controls.Add(this.btnRunBPPPTest);
            this.grpBPPPTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBPPPTest.Location = new System.Drawing.Point(12, 12);
            this.grpBPPPTest.Name = "grpBPPPTest";
            this.grpBPPPTest.Size = new System.Drawing.Size(556, 222);
            this.grpBPPPTest.TabIndex = 8;
            this.grpBPPPTest.TabStop = false;
            this.grpBPPPTest.Text = "Tests";
            // 
            // txtDAQInfo
            // 
            this.txtDAQInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtDAQInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDAQInfo.ForeColor = System.Drawing.Color.White;
            this.txtDAQInfo.Location = new System.Drawing.Point(9, 151);
            this.txtDAQInfo.Multiline = true;
            this.txtDAQInfo.Name = "txtDAQInfo";
            this.txtDAQInfo.ReadOnly = true;
            this.txtDAQInfo.Size = new System.Drawing.Size(541, 64);
            this.txtDAQInfo.TabIndex = 9;
            this.txtDAQInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colorProgressBar
            // 
            this.colorProgressBar.BackColor = System.Drawing.Color.White;
            this.colorProgressBar.BorderColor = System.Drawing.Color.Black;
            this.colorProgressBar.BorderWidth = 0;
            this.colorProgressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorProgressBar.Location = new System.Drawing.Point(9, 120);
            this.colorProgressBar.MaxValue = 100;
            this.colorProgressBar.MinValue = 0;
            this.colorProgressBar.Name = "colorProgressBar";
            this.colorProgressBar.ProgressColor = System.Drawing.Color.LightGreen;
            this.colorProgressBar.ProgressTextType = _7637_WS4.ColorProgressBar.FsProgressTextType.Percent;
            this.colorProgressBar.ShowProgressText = true;
            this.colorProgressBar.Size = new System.Drawing.Size(541, 25);
            this.colorProgressBar.TabIndex = 13;
            this.colorProgressBar.Value = 0;
            this.colorProgressBar.Visible = false;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(386, 94);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(16, 17);
            this.lblT.TabIndex = 11;
            this.lblT.Text = "t:";
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(273, 24);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(16, 17);
            this.lblRunCount.TabIndex = 4;
            this.lblRunCount.Text = "0";
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnShowReport.ForeColor = System.Drawing.Color.White;
            this.btnShowReport.Location = new System.Drawing.Point(475, 16);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(75, 25);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Report";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Visible = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Result:";
            // 
            // lblTEstCount
            // 
            this.lblTEstCount.AutoSize = true;
            this.lblTEstCount.Location = new System.Drawing.Point(198, 24);
            this.lblTEstCount.Name = "lblTEstCount";
            this.lblTEstCount.Size = new System.Drawing.Size(16, 17);
            this.lblTEstCount.TabIndex = 4;
            this.lblTEstCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Index of single test:";
            // 
            // btnStopAllTest
            // 
            this.btnStopAllTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopAllTest.Enabled = false;
            this.btnStopAllTest.ForeColor = System.Drawing.Color.White;
            this.btnStopAllTest.Location = new System.Drawing.Point(189, 91);
            this.btnStopAllTest.Name = "btnStopAllTest";
            this.btnStopAllTest.Size = new System.Drawing.Size(75, 25);
            this.btnStopAllTest.TabIndex = 9;
            this.btnStopAllTest.Text = "Stop";
            this.btnStopAllTest.UseVisualStyleBackColor = false;
            this.btnStopAllTest.Click += new System.EventHandler(this.btnStopAllTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total amount of tests:";
            // 
            // lblResultOfDMM
            // 
            this.lblResultOfDMM.AutoSize = true;
            this.lblResultOfDMM.Location = new System.Drawing.Point(448, 51);
            this.lblResultOfDMM.Name = "lblResultOfDMM";
            this.lblResultOfDMM.Size = new System.Drawing.Size(16, 17);
            this.lblResultOfDMM.TabIndex = 3;
            this.lblResultOfDMM.Text = "0";
            // 
            // numTest
            // 
            this.numTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.numTest.ForeColor = System.Drawing.Color.White;
            this.numTest.Location = new System.Drawing.Point(197, 49);
            this.numTest.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numTest.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(61, 23);
            this.numTest.TabIndex = 2;
            this.numTest.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRunAllBPPPTest
            // 
            this.btnRunAllBPPPTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunAllBPPPTest.ForeColor = System.Drawing.Color.White;
            this.btnRunAllBPPPTest.Location = new System.Drawing.Point(9, 91);
            this.btnRunAllBPPPTest.Name = "btnRunAllBPPPTest";
            this.btnRunAllBPPPTest.Size = new System.Drawing.Size(172, 25);
            this.btnRunAllBPPPTest.TabIndex = 8;
            this.btnRunAllBPPPTest.Text = "Run all tests";
            this.btnRunAllBPPPTest.UseVisualStyleBackColor = false;
            this.btnRunAllBPPPTest.Click += new System.EventHandler(this.btnRunAllBPPPTest_Click);
            // 
            // btnRunBPPPTest
            // 
            this.btnRunBPPPTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunBPPPTest.ForeColor = System.Drawing.Color.White;
            this.btnRunBPPPTest.Location = new System.Drawing.Point(264, 48);
            this.btnRunBPPPTest.Name = "btnRunBPPPTest";
            this.btnRunBPPPTest.Size = new System.Drawing.Size(75, 25);
            this.btnRunBPPPTest.TabIndex = 0;
            this.btnRunBPPPTest.Text = "Run";
            this.btnRunBPPPTest.UseVisualStyleBackColor = false;
            this.btnRunBPPPTest.Click += new System.EventHandler(this.btnRunBPPPTest_Click);
            // 
            // frmBZ_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 244);
            this.Controls.Add(this.grpBPPPTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBZ_Test";
            this.Activated += new System.EventHandler(this.frmBZ_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBZ_Test_FormClosing);
            this.grpBPPPTest.ResumeLayout(false);
            this.grpBPPPTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBPPPTest;
        private System.Windows.Forms.TextBox txtDAQInfo;
        private ColorProgressBar colorProgressBar;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTEstCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStopAllTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResultOfDMM;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button btnRunAllBPPPTest;
        private System.Windows.Forms.Button btnRunBPPPTest;
    }
}