namespace _7637_WS4
{
    partial class frmPP_Report
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
            this.lstTest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstTest
            // 
            this.lstTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTest.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstTest.FormattingEnabled = true;
            this.lstTest.ItemHeight = 18;
            this.lstTest.Location = new System.Drawing.Point(0, 0);
            this.lstTest.Name = "lstTest";
            this.lstTest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTest.Size = new System.Drawing.Size(778, 313);
            this.lstTest.TabIndex = 3;
            // 
            // frmPP_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 313);
            this.Controls.Add(this.lstTest);
            this.Name = "frmPP_Report";
            this.Text = "frmPP_Report";
            this.Activated += new System.EventHandler(this.frmPP_Report_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPP_Report_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTest;
    }
}