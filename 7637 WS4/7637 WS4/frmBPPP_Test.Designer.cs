namespace _7637_WS4
{
    partial class frmBPPP_Test
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
            this.grpTestInfo = new System.Windows.Forms.GroupBox();
            this.lblTEstCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.grpDC = new System.Windows.Forms.GroupBox();
            this.numDCV2 = new System.Windows.Forms.NumericUpDown();
            this.numDCV1 = new System.Windows.Forms.NumericUpDown();
            this.grpSwitch = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCloseRelay = new System.Windows.Forms.Button();
            this.btnOpenRelay = new System.Windows.Forms.Button();
            this.numSwitchChannel = new System.Windows.Forms.NumericUpDown();
            this.cmbSwitchName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.lblResultOfDMM = new System.Windows.Forms.Label();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.grpTestInfo.SuspendLayout();
            this.grpDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDCV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDCV1)).BeginInit();
            this.grpSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSwitchChannel)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(1082, 31);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(75, 23);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // grpTestInfo
            // 
            this.grpTestInfo.Controls.Add(this.lblTEstCount);
            this.grpTestInfo.Controls.Add(this.label1);
            this.grpTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpTestInfo.Location = new System.Drawing.Point(12, 12);
            this.grpTestInfo.Name = "grpTestInfo";
            this.grpTestInfo.Size = new System.Drawing.Size(402, 105);
            this.grpTestInfo.TabIndex = 2;
            this.grpTestInfo.TabStop = false;
            this.grpTestInfo.Text = "Информация";
            // 
            // lblTEstCount
            // 
            this.lblTEstCount.AutoSize = true;
            this.lblTEstCount.Location = new System.Drawing.Point(198, 29);
            this.lblTEstCount.Name = "lblTEstCount";
            this.lblTEstCount.Size = new System.Drawing.Size(16, 17);
            this.lblTEstCount.TabIndex = 4;
            this.lblTEstCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Общее количество тестов:";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(127, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вкл к.1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(127, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Вкл к.2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(187, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Выкл";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(187, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Выкл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // grpDC
            // 
            this.grpDC.Controls.Add(this.numDCV2);
            this.grpDC.Controls.Add(this.numDCV1);
            this.grpDC.Controls.Add(this.button1);
            this.grpDC.Controls.Add(this.button2);
            this.grpDC.Controls.Add(this.button3);
            this.grpDC.Controls.Add(this.button4);
            this.grpDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpDC.Location = new System.Drawing.Point(420, 12);
            this.grpDC.Name = "grpDC";
            this.grpDC.Size = new System.Drawing.Size(254, 105);
            this.grpDC.TabIndex = 5;
            this.grpDC.TabStop = false;
            this.grpDC.Text = "DC";
            // 
            // numDCV2
            // 
            this.numDCV2.DecimalPlaces = 2;
            this.numDCV2.Location = new System.Drawing.Point(52, 62);
            this.numDCV2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDCV2.Name = "numDCV2";
            this.numDCV2.Size = new System.Drawing.Size(69, 23);
            this.numDCV2.TabIndex = 5;
            this.numDCV2.Value = new decimal(new int[] {
            270,
            0,
            0,
            65536});
            // 
            // numDCV1
            // 
            this.numDCV1.DecimalPlaces = 2;
            this.numDCV1.Location = new System.Drawing.Point(52, 26);
            this.numDCV1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDCV1.Name = "numDCV1";
            this.numDCV1.Size = new System.Drawing.Size(69, 23);
            this.numDCV1.TabIndex = 5;
            this.numDCV1.Value = new decimal(new int[] {
            33,
            0,
            0,
            65536});
            // 
            // grpSwitch
            // 
            this.grpSwitch.Controls.Add(this.label3);
            this.grpSwitch.Controls.Add(this.label2);
            this.grpSwitch.Controls.Add(this.btnCloseRelay);
            this.grpSwitch.Controls.Add(this.btnOpenRelay);
            this.grpSwitch.Controls.Add(this.numSwitchChannel);
            this.grpSwitch.Controls.Add(this.cmbSwitchName);
            this.grpSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpSwitch.Location = new System.Drawing.Point(680, 12);
            this.grpSwitch.Name = "grpSwitch";
            this.grpSwitch.Size = new System.Drawing.Size(296, 105);
            this.grpSwitch.TabIndex = 6;
            this.grpSwitch.TabStop = false;
            this.grpSwitch.Text = "SWITCH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Реле";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Канал";
            // 
            // btnCloseRelay
            // 
            this.btnCloseRelay.ForeColor = System.Drawing.Color.Black;
            this.btnCloseRelay.Location = new System.Drawing.Point(189, 59);
            this.btnCloseRelay.Name = "btnCloseRelay";
            this.btnCloseRelay.Size = new System.Drawing.Size(75, 23);
            this.btnCloseRelay.TabIndex = 3;
            this.btnCloseRelay.Text = "Выкл";
            this.btnCloseRelay.UseVisualStyleBackColor = true;
            this.btnCloseRelay.Click += new System.EventHandler(this.btnCloseRelay_Click);
            // 
            // btnOpenRelay
            // 
            this.btnOpenRelay.ForeColor = System.Drawing.Color.Black;
            this.btnOpenRelay.Location = new System.Drawing.Point(189, 30);
            this.btnOpenRelay.Name = "btnOpenRelay";
            this.btnOpenRelay.Size = new System.Drawing.Size(75, 23);
            this.btnOpenRelay.TabIndex = 2;
            this.btnOpenRelay.Text = "Вкл";
            this.btnOpenRelay.UseVisualStyleBackColor = true;
            this.btnOpenRelay.Click += new System.EventHandler(this.btnOpenRelay_Click);
            // 
            // numSwitchChannel
            // 
            this.numSwitchChannel.Location = new System.Drawing.Point(114, 62);
            this.numSwitchChannel.Name = "numSwitchChannel";
            this.numSwitchChannel.Size = new System.Drawing.Size(46, 23);
            this.numSwitchChannel.TabIndex = 1;
            // 
            // cmbSwitchName
            // 
            this.cmbSwitchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwitchName.FormattingEnabled = true;
            this.cmbSwitchName.Items.AddRange(new object[] {
            "R1",
            "R2",
            "R3",
            "R4",
            "R5",
            "R6",
            "R7",
            "R8"});
            this.cmbSwitchName.Location = new System.Drawing.Point(76, 30);
            this.cmbSwitchName.Name = "cmbSwitchName";
            this.cmbSwitchName.Size = new System.Drawing.Size(84, 24);
            this.cmbSwitchName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRunCount);
            this.groupBox1.Controls.Add(this.lblResultOfDMM);
            this.groupBox1.Controls.Add(this.numTest);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(444, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тесты";
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(184, 36);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(16, 17);
            this.lblRunCount.TabIndex = 4;
            this.lblRunCount.Text = "0";
            // 
            // lblResultOfDMM
            // 
            this.lblResultOfDMM.AutoSize = true;
            this.lblResultOfDMM.Location = new System.Drawing.Point(309, 36);
            this.lblResultOfDMM.Name = "lblResultOfDMM";
            this.lblResultOfDMM.Size = new System.Drawing.Size(16, 17);
            this.lblResultOfDMM.TabIndex = 3;
            this.lblResultOfDMM.Text = "0";
            // 
            // numTest
            // 
            this.numTest.Location = new System.Drawing.Point(23, 33);
            this.numTest.Maximum = new decimal(new int[] {
            5000,
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(103, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "RUN";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(547, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // numTimeout
            // 
            this.numTimeout.Location = new System.Drawing.Point(266, 215);
            this.numTimeout.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(61, 20);
            this.numTimeout.TabIndex = 9;
            this.numTimeout.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(196, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Таймаут";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(346, 217);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(13, 13);
            this.lblT.TabIndex = 11;
            this.lblT.Text = "t:";
            // 
            // frmBPPP_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 381);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTimeout);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSwitch);
            this.Controls.Add(this.grpDC);
            this.Controls.Add(this.grpTestInfo);
            this.Controls.Add(this.btnShowReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBPPP_Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBPPP_Test";
            this.Activated += new System.EventHandler(this.frmBPPP_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBPPP_Test_FormClosing);
            this.grpTestInfo.ResumeLayout(false);
            this.grpTestInfo.PerformLayout();
            this.grpDC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDCV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDCV1)).EndInit();
            this.grpSwitch.ResumeLayout(false);
            this.grpSwitch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSwitchChannel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.GroupBox grpTestInfo;
        private System.Windows.Forms.Label lblTEstCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox grpDC;
        private System.Windows.Forms.GroupBox grpSwitch;
        private System.Windows.Forms.ComboBox cmbSwitchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCloseRelay;
        private System.Windows.Forms.Button btnOpenRelay;
        private System.Windows.Forms.NumericUpDown numSwitchChannel;
        private System.Windows.Forms.NumericUpDown numDCV2;
        private System.Windows.Forms.NumericUpDown numDCV1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResultOfDMM;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblT;
    }
}