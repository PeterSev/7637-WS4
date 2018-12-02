namespace _7637_WS4
{
    partial class frmBU_Ind_Test_Light
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
            this.pict = new System.Windows.Forms.PictureBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pict)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pict
            // 
            this.pict.Location = new System.Drawing.Point(12, 12);
            this.pict.Name = "pict";
            this.pict.Size = new System.Drawing.Size(800, 600);
            this.pict.TabIndex = 14;
            this.pict.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.Control;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComment.Location = new System.Drawing.Point(12, 618);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(654, 91);
            this.txtComment.TabIndex = 15;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.btnNo);
            this.panelRight.Controls.Add(this.btnOK);
            this.panelRight.Location = new System.Drawing.Point(672, 618);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(140, 94);
            this.panelRight.TabIndex = 16;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 86);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Y";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(72, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(65, 86);
            this.btnNo.TabIndex = 8;
            this.btnNo.Text = "N";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // frmBU_Ind_Test_Light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 719);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.pict);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBU_Ind_Test_Light";
            this.Text = "frmBU_Ind_Test_Light";
            this.Activated += new System.EventHandler(this.frmBU_Ind_Test_Light_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pict)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pict;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnOK;
    }
}