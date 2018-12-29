namespace _7637_WS4
{
    partial class frmComPort
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
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnOKCom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(15, 19);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(75, 21);
            this.cmbCom.TabIndex = 0;
            // 
            // btnOKCom
            // 
            this.btnOKCom.Location = new System.Drawing.Point(15, 46);
            this.btnOKCom.Name = "btnOKCom";
            this.btnOKCom.Size = new System.Drawing.Size(75, 23);
            this.btnOKCom.TabIndex = 1;
            this.btnOKCom.Text = "OK";
            this.btnOKCom.UseVisualStyleBackColor = true;
            this.btnOKCom.Click += new System.EventHandler(this.btnOKCom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOKCom);
            this.groupBox1.Controls.Add(this.cmbCom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // frmComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(134, 110);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComPort";
            this.Text = "COM";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.Button btnOKCom;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}