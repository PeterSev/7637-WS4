﻿namespace _7637_WS4
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTEstCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDCStatus = new System.Windows.Forms.TextBox();
            this.grpTestInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(716, 22);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(75, 23);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // grpTestInfo
            // 
            this.grpTestInfo.Controls.Add(this.txtDCStatus);
            this.grpTestInfo.Controls.Add(this.label2);
            this.grpTestInfo.Controls.Add(this.lblTEstCount);
            this.grpTestInfo.Controls.Add(this.label1);
            this.grpTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpTestInfo.Location = new System.Drawing.Point(12, 12);
            this.grpTestInfo.Name = "grpTestInfo";
            this.grpTestInfo.Size = new System.Drawing.Size(402, 156);
            this.grpTestInfo.TabIndex = 2;
            this.grpTestInfo.TabStop = false;
            this.grpTestInfo.Text = "Информация";
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
            // lblTEstCount
            // 
            this.lblTEstCount.AutoSize = true;
            this.lblTEstCount.Location = new System.Drawing.Point(198, 29);
            this.lblTEstCount.Name = "lblTEstCount";
            this.lblTEstCount.Size = new System.Drawing.Size(16, 17);
            this.lblTEstCount.TabIndex = 4;
            this.lblTEstCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Статус DC:";
            // 
            // txtDCStatus
            // 
            this.txtDCStatus.Location = new System.Drawing.Point(200, 54);
            this.txtDCStatus.Multiline = true;
            this.txtDCStatus.Name = "txtDCStatus";
            this.txtDCStatus.ReadOnly = true;
            this.txtDCStatus.Size = new System.Drawing.Size(196, 96);
            this.txtDCStatus.TabIndex = 6;
            // 
            // frmBPPP_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 361);
            this.Controls.Add(this.grpTestInfo);
            this.Controls.Add(this.btnShowReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBPPP_Test";
            this.Text = "frmBPPP_Test";
            this.Activated += new System.EventHandler(this.frmBPPP_Test_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBPPP_Test_FormClosing);
            this.grpTestInfo.ResumeLayout(false);
            this.grpTestInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.GroupBox grpTestInfo;
        private System.Windows.Forms.Label lblTEstCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDCStatus;
    }
}