namespace _7637_WS4
{
    partial class frmBPPP
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
            this.components = new System.ComponentModel.Container();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pict = new System.Windows.Forms.PictureBox();
            this.grpBoards = new System.Windows.Forms.GroupBox();
            this.panel = new System.Windows.Forms.Panel();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pict)).BeginInit();
            this.grpBoards.SuspendLayout();
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
            this.txtComment.TabIndex = 18;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pict
            // 
            this.pict.Location = new System.Drawing.Point(324, 12);
            this.pict.Name = "pict";
            this.pict.Size = new System.Drawing.Size(800, 600);
            this.pict.TabIndex = 17;
            this.pict.TabStop = false;
            // 
            // grpBoards
            // 
            this.grpBoards.Controls.Add(this.panel);
            this.grpBoards.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBoards.Location = new System.Drawing.Point(12, 12);
            this.grpBoards.Name = "grpBoards";
            this.grpBoards.Size = new System.Drawing.Size(306, 697);
            this.grpBoards.TabIndex = 19;
            this.grpBoards.TabStop = false;
            this.grpBoards.Text = "Список плат";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 19);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(300, 675);
            this.panel.TabIndex = 0;
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 5000;
            this.tip.InitialDelay = 300;
            this.tip.ReshowDelay = 100;
            // 
            // frmBPPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 721);
            this.Controls.Add(this.grpBoards);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.pict);
            this.Name = "frmBPPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBPPP";
            this.Activated += new System.EventHandler(this.frmBPPP_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBPPP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pict)).EndInit();
            this.grpBoards.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.PictureBox pict;
        private System.Windows.Forms.GroupBox grpBoards;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip tip;
    }
}