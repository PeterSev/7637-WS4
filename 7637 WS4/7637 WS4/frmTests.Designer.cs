namespace _7637_WS4
{
    partial class frmTests
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
            this.txtComment = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.btnBZ = new System.Windows.Forms.PictureBox();
            this.btnBU = new System.Windows.Forms.PictureBox();
            this.btnPP = new System.Windows.Forms.PictureBox();
            this.btnBPPP = new System.Windows.Forms.PictureBox();
            this.lblPP = new System.Windows.Forms.Label();
            this.lblBU = new System.Windows.Forms.Label();
            this.lblBPPP = new System.Windows.Forms.Label();
            this.lblBZ = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBPPP)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.Control;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComment.Location = new System.Drawing.Point(12, 618);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(800, 91);
            this.txtComment.TabIndex = 2;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnBZ);
            this.panel.Controls.Add(this.btnBU);
            this.panel.Controls.Add(this.btnPP);
            this.panel.Controls.Add(this.btnBPPP);
            this.panel.Controls.Add(this.lblPP);
            this.panel.Controls.Add(this.lblBU);
            this.panel.Controls.Add(this.lblBPPP);
            this.panel.Controls.Add(this.lblBZ);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 600);
            this.panel.TabIndex = 3;
            // 
            // btnBZ
            // 
            this.btnBZ.Location = new System.Drawing.Point(0, 0);
            this.btnBZ.Name = "btnBZ";
            this.btnBZ.Size = new System.Drawing.Size(400, 260);
            this.btnBZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBZ.TabIndex = 5;
            this.btnBZ.TabStop = false;
            this.btnBZ.Click += new System.EventHandler(this.btnBZ_Click);
            this.btnBZ.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnBU
            // 
            this.btnBU.Location = new System.Drawing.Point(400, 0);
            this.btnBU.Name = "btnBU";
            this.btnBU.Size = new System.Drawing.Size(400, 260);
            this.btnBU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBU.TabIndex = 5;
            this.btnBU.TabStop = false;
            this.btnBU.Click += new System.EventHandler(this.btnBU_Click);
            this.btnBU.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnPP
            // 
            this.btnPP.Location = new System.Drawing.Point(400, 300);
            this.btnPP.Name = "btnPP";
            this.btnPP.Size = new System.Drawing.Size(400, 260);
            this.btnPP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPP.TabIndex = 5;
            this.btnPP.TabStop = false;
            this.btnPP.Click += new System.EventHandler(this.btnPP_Click);
            this.btnPP.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnBPPP
            // 
            this.btnBPPP.Location = new System.Drawing.Point(0, 300);
            this.btnBPPP.Name = "btnBPPP";
            this.btnBPPP.Size = new System.Drawing.Size(400, 260);
            this.btnBPPP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBPPP.TabIndex = 4;
            this.btnBPPP.TabStop = false;
            this.btnBPPP.Click += new System.EventHandler(this.btnBPPP_Click);
            this.btnBPPP.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // lblPP
            // 
            this.lblPP.AutoSize = true;
            this.lblPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPP.Location = new System.Drawing.Point(397, 563);
            this.lblPP.Name = "lblPP";
            this.lblPP.Size = new System.Drawing.Size(113, 17);
            this.lblPP.TabIndex = 1;
            this.lblPP.Text = "Test signals Unit";
            this.lblPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBU
            // 
            this.lblBU.AutoSize = true;
            this.lblBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBU.Location = new System.Drawing.Point(397, 263);
            this.lblBU.Name = "lblBU";
            this.lblBU.Size = new System.Drawing.Size(82, 17);
            this.lblBU.TabIndex = 1;
            this.lblBU.Text = "Control Unit";
            this.lblBU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBPPP
            // 
            this.lblBPPP.AutoSize = true;
            this.lblBPPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBPPP.Location = new System.Drawing.Point(3, 563);
            this.lblBPPP.Name = "lblBPPP";
            this.lblBPPP.Size = new System.Drawing.Size(218, 17);
            this.lblBPPP.TabIndex = 1;
            this.lblBPPP.Text = "Test Unit of printed circuit boards";
            this.lblBPPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBZ
            // 
            this.lblBZ.AutoSize = true;
            this.lblBZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBZ.Location = new System.Drawing.Point(3, 263);
            this.lblBZ.Name = "lblBZ";
            this.lblBZ.Size = new System.Drawing.Size(74, 17);
            this.lblBZ.TabIndex = 1;
            this.lblBZ.Text = "Mirror Unit";
            this.lblBZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 719);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tests";
            this.Activated += new System.EventHandler(this.frmTests_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTests_FormClosing);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBPPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblPP;
        private System.Windows.Forms.Label lblBU;
        private System.Windows.Forms.Label lblBPPP;
        private System.Windows.Forms.Label lblBZ;
        private System.Windows.Forms.PictureBox btnBPPP;
        private System.Windows.Forms.PictureBox btnBZ;
        private System.Windows.Forms.PictureBox btnBU;
        private System.Windows.Forms.PictureBox btnPP;
    }
}