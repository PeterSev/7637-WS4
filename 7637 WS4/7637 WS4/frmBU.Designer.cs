namespace _7637_WS4
{
    partial class frmBU
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
            this.pict = new System.Windows.Forms.PictureBox();
            this.btnProzvonka = new System.Windows.Forms.Button();
            this.btnIndic = new System.Windows.Forms.Button();
            this.btnOscill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pict)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.Control;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComment.Location = new System.Drawing.Point(324, 618);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(800, 91);
            this.txtComment.TabIndex = 16;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pict
            // 
            this.pict.Location = new System.Drawing.Point(324, 12);
            this.pict.Name = "pict";
            this.pict.Size = new System.Drawing.Size(800, 600);
            this.pict.TabIndex = 15;
            this.pict.TabStop = false;
            // 
            // btnProzvonka
            // 
            this.btnProzvonka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProzvonka.Location = new System.Drawing.Point(12, 12);
            this.btnProzvonka.Name = "btnProzvonka";
            this.btnProzvonka.Size = new System.Drawing.Size(300, 230);
            this.btnProzvonka.TabIndex = 17;
            this.btnProzvonka.Text = "Прозвонка";
            this.btnProzvonka.UseVisualStyleBackColor = true;
            this.btnProzvonka.Click += new System.EventHandler(this.btnProzvonka_Click);
            // 
            // btnIndic
            // 
            this.btnIndic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnIndic.Location = new System.Drawing.Point(12, 248);
            this.btnIndic.Name = "btnIndic";
            this.btnIndic.Size = new System.Drawing.Size(300, 230);
            this.btnIndic.TabIndex = 17;
            this.btnIndic.Text = "Индикация";
            this.btnIndic.UseVisualStyleBackColor = true;
            this.btnIndic.Click += new System.EventHandler(this.btnIndic_Click);
            // 
            // btnOscill
            // 
            this.btnOscill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOscill.Location = new System.Drawing.Point(12, 484);
            this.btnOscill.Name = "btnOscill";
            this.btnOscill.Size = new System.Drawing.Size(300, 230);
            this.btnOscill.TabIndex = 17;
            this.btnOscill.Text = "Осциллограф";
            this.btnOscill.UseVisualStyleBackColor = true;
            this.btnOscill.Click += new System.EventHandler(this.btnOscill_Click);
            // 
            // frmBU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 721);
            this.Controls.Add(this.btnOscill);
            this.Controls.Add(this.btnIndic);
            this.Controls.Add(this.btnProzvonka);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.pict);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBU";
            this.Text = "frmBU";
            this.Activated += new System.EventHandler(this.frmBU_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBU_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.PictureBox pict;
        private System.Windows.Forms.Button btnProzvonka;
        private System.Windows.Forms.Button btnIndic;
        private System.Windows.Forms.Button btnOscill;
    }
}