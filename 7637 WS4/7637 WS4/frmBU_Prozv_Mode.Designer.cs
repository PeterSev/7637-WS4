namespace _7637_WS4
{
    partial class frmBU_Prozv_Mode
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
            this.btnVybor = new System.Windows.Forms.Button();
            this.btnKZ = new System.Windows.Forms.Button();
            this.btnObryv = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pict = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pict)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVybor
            // 
            this.btnVybor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVybor.Location = new System.Drawing.Point(12, 481);
            this.btnVybor.Name = "btnVybor";
            this.btnVybor.Size = new System.Drawing.Size(300, 230);
            this.btnVybor.TabIndex = 20;
            this.btnVybor.Text = "Выборочная";
            this.btnVybor.UseVisualStyleBackColor = true;
            // 
            // btnKZ
            // 
            this.btnKZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKZ.Location = new System.Drawing.Point(12, 245);
            this.btnKZ.Name = "btnKZ";
            this.btnKZ.Size = new System.Drawing.Size(300, 230);
            this.btnKZ.TabIndex = 21;
            this.btnKZ.Text = "КЗ";
            this.btnKZ.UseVisualStyleBackColor = true;
            // 
            // btnObryv
            // 
            this.btnObryv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnObryv.Location = new System.Drawing.Point(12, 9);
            this.btnObryv.Name = "btnObryv";
            this.btnObryv.Size = new System.Drawing.Size(300, 230);
            this.btnObryv.TabIndex = 22;
            this.btnObryv.Text = "Обрыв";
            this.btnObryv.UseVisualStyleBackColor = true;
            this.btnObryv.Click += new System.EventHandler(this.btnObryv_Click);
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.Control;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComment.Location = new System.Drawing.Point(324, 615);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(800, 91);
            this.txtComment.TabIndex = 19;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pict
            // 
            this.pict.Location = new System.Drawing.Point(324, 9);
            this.pict.Name = "pict";
            this.pict.Size = new System.Drawing.Size(800, 600);
            this.pict.TabIndex = 18;
            this.pict.TabStop = false;
            // 
            // frmBU_Prozv_Mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 721);
            this.Controls.Add(this.btnVybor);
            this.Controls.Add(this.btnKZ);
            this.Controls.Add(this.btnObryv);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.pict);
            this.Name = "frmBU_Prozv_Mode";
            this.Text = "frmBU_Prozv_Mode";
            this.Activated += new System.EventHandler(this.frmBPPP_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBPPP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVybor;
        private System.Windows.Forms.Button btnKZ;
        private System.Windows.Forms.Button btnObryv;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.PictureBox pict;
    }
}