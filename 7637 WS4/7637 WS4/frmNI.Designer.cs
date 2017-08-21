namespace _7637_WS4
{
    partial class frmNI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblV1 = new System.Windows.Forms.Label();
            this.lblV2 = new System.Windows.Forms.Label();
            this.ind2 = new System.Windows.Forms.Button();
            this.ind1 = new System.Windows.Forms.Button();
            this.txtDCStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDCWarning = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDCWarning);
            this.groupBox1.Controls.Add(this.txtDCStatus);
            this.groupBox1.Controls.Add(this.ind1);
            this.groupBox1.Controls.Add(this.ind2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblV2);
            this.groupBox1.Controls.Add(this.lblV1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Источник питания DC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Канал 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Канал 2";
            // 
            // lblV1
            // 
            this.lblV1.AutoSize = true;
            this.lblV1.Location = new System.Drawing.Point(83, 33);
            this.lblV1.Name = "lblV1";
            this.lblV1.Size = new System.Drawing.Size(20, 13);
            this.lblV1.TabIndex = 0;
            this.lblV1.Text = "V: ";
            // 
            // lblV2
            // 
            this.lblV2.AutoSize = true;
            this.lblV2.Location = new System.Drawing.Point(83, 85);
            this.lblV2.Name = "lblV2";
            this.lblV2.Size = new System.Drawing.Size(20, 13);
            this.lblV2.TabIndex = 0;
            this.lblV2.Text = "V: ";
            // 
            // ind2
            // 
            this.ind2.Enabled = false;
            this.ind2.Location = new System.Drawing.Point(191, 79);
            this.ind2.Name = "ind2";
            this.ind2.Size = new System.Drawing.Size(25, 25);
            this.ind2.TabIndex = 1;
            this.ind2.UseVisualStyleBackColor = true;
            // 
            // ind1
            // 
            this.ind1.Enabled = false;
            this.ind1.Location = new System.Drawing.Point(191, 27);
            this.ind1.Name = "ind1";
            this.ind1.Size = new System.Drawing.Size(25, 25);
            this.ind1.TabIndex = 1;
            this.ind1.UseVisualStyleBackColor = true;
            // 
            // txtDCStatus
            // 
            this.txtDCStatus.Location = new System.Drawing.Point(9, 149);
            this.txtDCStatus.Multiline = true;
            this.txtDCStatus.Name = "txtDCStatus";
            this.txtDCStatus.ReadOnly = true;
            this.txtDCStatus.Size = new System.Drawing.Size(207, 76);
            this.txtDCStatus.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Статус";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Warning";
            // 
            // txtDCWarning
            // 
            this.txtDCWarning.Location = new System.Drawing.Point(9, 258);
            this.txtDCWarning.Multiline = true;
            this.txtDCWarning.Name = "txtDCWarning";
            this.txtDCWarning.ReadOnly = true;
            this.txtDCWarning.Size = new System.Drawing.Size(207, 76);
            this.txtDCWarning.TabIndex = 2;
            // 
            // frmNI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 406);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNI";
            this.Text = "Текущее состояние устройств NI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ind1;
        private System.Windows.Forms.Button ind2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblV2;
        private System.Windows.Forms.Label lblV1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDCWarning;
        private System.Windows.Forms.TextBox txtDCStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}