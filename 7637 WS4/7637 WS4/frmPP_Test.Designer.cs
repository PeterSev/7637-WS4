namespace _7637_WS4
{
    partial class frmPP_Test
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
            this.btnShowUDPDebug = new System.Windows.Forms.Button();
            this.grpPPTest = new System.Windows.Forms.GroupBox();
            this.txtDAQInfo = new System.Windows.Forms.TextBox();
            this.lblT = new System.Windows.Forms.Label();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTEstCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStopAllTest = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.btnRunAllPPTest = new System.Windows.Forms.Button();
            this.btnRunPPTest = new System.Windows.Forms.Button();
            this.colorProgressBar = new _7637_WS4.ColorProgressBar();
            this.grpPPTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowUDPDebug
            // 
            this.btnShowUDPDebug.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnShowUDPDebug.ForeColor = System.Drawing.Color.White;
            this.btnShowUDPDebug.Location = new System.Drawing.Point(433, 51);
            this.btnShowUDPDebug.Name = "btnShowUDPDebug";
            this.btnShowUDPDebug.Size = new System.Drawing.Size(117, 30);
            this.btnShowUDPDebug.TabIndex = 2;
            this.btnShowUDPDebug.Text = "UDP Debug";
            this.btnShowUDPDebug.UseVisualStyleBackColor = false;
            this.btnShowUDPDebug.Click += new System.EventHandler(this.btnShowUDPDebug_Click);
            // 
            // grpPPTest
            // 
            this.grpPPTest.Controls.Add(this.txtDAQInfo);
            this.grpPPTest.Controls.Add(this.btnShowUDPDebug);
            this.grpPPTest.Controls.Add(this.colorProgressBar);
            this.grpPPTest.Controls.Add(this.lblT);
            this.grpPPTest.Controls.Add(this.lblRunCount);
            this.grpPPTest.Controls.Add(this.button1);
            this.grpPPTest.Controls.Add(this.label6);
            this.grpPPTest.Controls.Add(this.label5);
            this.grpPPTest.Controls.Add(this.lblTEstCount);
            this.grpPPTest.Controls.Add(this.label4);
            this.grpPPTest.Controls.Add(this.btnStopAllTest);
            this.grpPPTest.Controls.Add(this.label7);
            this.grpPPTest.Controls.Add(this.label1);
            this.grpPPTest.Controls.Add(this.lblResult);
            this.grpPPTest.Controls.Add(this.numTest);
            this.grpPPTest.Controls.Add(this.btnRunAllPPTest);
            this.grpPPTest.Controls.Add(this.btnRunPPTest);
            this.grpPPTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpPPTest.Location = new System.Drawing.Point(12, 12);
            this.grpPPTest.Name = "grpPPTest";
            this.grpPPTest.Size = new System.Drawing.Size(556, 222);
            this.grpPPTest.TabIndex = 8;
            this.grpPPTest.TabStop = false;
            this.grpPPTest.Text = "Tests";
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
            this.lblRunCount.Location = new System.Drawing.Point(386, 24);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(16, 17);
            this.lblRunCount.TabIndex = 4;
            this.lblRunCount.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(475, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnShowReport_Click);
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
            this.label5.Location = new System.Drawing.Point(300, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Result:";
            // 
            // lblTEstCount
            // 
            this.lblTEstCount.AutoSize = true;
            this.lblTEstCount.Location = new System.Drawing.Point(187, 24);
            this.lblTEstCount.Name = "lblTEstCount";
            this.lblTEstCount.Size = new System.Drawing.Size(16, 17);
            this.lblTEstCount.TabIndex = 4;
            this.lblTEstCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 51);
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
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Current  test:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total amount of tests:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(358, 78);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(16, 17);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "0";
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
            // btnRunAllPPTest
            // 
            this.btnRunAllPPTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunAllPPTest.ForeColor = System.Drawing.Color.White;
            this.btnRunAllPPTest.Location = new System.Drawing.Point(9, 91);
            this.btnRunAllPPTest.Name = "btnRunAllPPTest";
            this.btnRunAllPPTest.Size = new System.Drawing.Size(172, 25);
            this.btnRunAllPPTest.TabIndex = 8;
            this.btnRunAllPPTest.Text = "Run all tests";
            this.btnRunAllPPTest.UseVisualStyleBackColor = false;
            // 
            // btnRunPPTest
            // 
            this.btnRunPPTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunPPTest.ForeColor = System.Drawing.Color.White;
            this.btnRunPPTest.Location = new System.Drawing.Point(264, 48);
            this.btnRunPPTest.Name = "btnRunPPTest";
            this.btnRunPPTest.Size = new System.Drawing.Size(75, 25);
            this.btnRunPPTest.TabIndex = 0;
            this.btnRunPPTest.Text = "Run";
            this.btnRunPPTest.UseVisualStyleBackColor = false;
            this.btnRunPPTest.Click += new System.EventHandler(this.btnRunPPTest_Click);
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
            // frmPP_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 243);
            this.Controls.Add(this.grpPPTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPP_Test";
            this.Text = "frmPP_Test";
            this.Activated += new System.EventHandler(this.frmPP_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPP_Test_FormClosing);
            this.grpPPTest.ResumeLayout(false);
            this.grpPPTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowUDPDebug;
        private System.Windows.Forms.GroupBox grpPPTest;
        private ColorProgressBar colorProgressBar;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStopAllTest;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button btnRunAllPPTest;
        private System.Windows.Forms.Button btnRunPPTest;
        public System.Windows.Forms.Label lblTEstCount;
        public System.Windows.Forms.Label lblResult;
        public System.Windows.Forms.TextBox txtDAQInfo;
    }
}