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
            this.lst = new System.Windows.Forms.ListBox();
            this.btnRunDAQTest = new System.Windows.Forms.Button();
            this.numTest = new System.Windows.Forms.NumericUpDown();
            this.btnRunDAQ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).BeginInit();
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
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(591, 45);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(234, 368);
            this.lst.TabIndex = 2;
            // 
            // btnRunDAQTest
            // 
            this.btnRunDAQTest.Location = new System.Drawing.Point(324, 210);
            this.btnRunDAQTest.Name = "btnRunDAQTest";
            this.btnRunDAQTest.Size = new System.Drawing.Size(75, 23);
            this.btnRunDAQTest.TabIndex = 3;
            this.btnRunDAQTest.Text = "Run Test";
            this.btnRunDAQTest.UseVisualStyleBackColor = true;
            this.btnRunDAQTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // numTest
            // 
            this.numTest.Location = new System.Drawing.Point(245, 210);
            this.numTest.Name = "numTest";
            this.numTest.Size = new System.Drawing.Size(73, 20);
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
            // frmBU_Prozv_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 452);
            this.Controls.Add(this.btnRunDAQ);
            this.Controls.Add(this.numTest);
            this.Controls.Add(this.btnRunDAQTest);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnShowReport);
            this.Name = "frmBU_Prozv_Test";
            this.Text = "frmBU_Prozv_Tests";
            this.Activated += new System.EventHandler(this.frmBZ_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBZ_Test_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button btnRunDAQTest;
        private System.Windows.Forms.NumericUpDown numTest;
        private System.Windows.Forms.Button btnRunDAQ;
    }
}