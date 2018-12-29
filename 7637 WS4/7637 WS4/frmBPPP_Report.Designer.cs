namespace _7637_WS4
{
    partial class frmBPPP_Report
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
            this.lstTest = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.очиститьЛогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скопироватьВБуферToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печататьВыделенныеСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTest
            // 
            this.lstTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTest.ContextMenuStrip = this.contextMenuStrip1;
            this.lstTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTest.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstTest.FormattingEnabled = true;
            this.lstTest.ItemHeight = 18;
            this.lstTest.Location = new System.Drawing.Point(0, 0);
            this.lstTest.Name = "lstTest";
            this.lstTest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTest.Size = new System.Drawing.Size(1340, 289);
            this.lstTest.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьЛогToolStripMenuItem,
            this.скопироватьВБуферToolStripMenuItem,
            this.печататьВыделенныеСтрокиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 92);
            // 
            // очиститьЛогToolStripMenuItem
            // 
            this.очиститьЛогToolStripMenuItem.Name = "очиститьЛогToolStripMenuItem";
            this.очиститьЛогToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.очиститьЛогToolStripMenuItem.Text = "Clear log";
            this.очиститьЛогToolStripMenuItem.Click += new System.EventHandler(this.очиститьЛогToolStripMenuItem_Click);
            // 
            // скопироватьВБуферToolStripMenuItem
            // 
            this.скопироватьВБуферToolStripMenuItem.Name = "скопироватьВБуферToolStripMenuItem";
            this.скопироватьВБуферToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.скопироватьВБуферToolStripMenuItem.Text = "Copy to buffer";
            this.скопироватьВБуферToolStripMenuItem.Click += new System.EventHandler(this.скопироватьВБуферToolStripMenuItem_Click);
            // 
            // печататьВыделенныеСтрокиToolStripMenuItem
            // 
            this.печататьВыделенныеСтрокиToolStripMenuItem.Name = "печататьВыделенныеСтрокиToolStripMenuItem";
            this.печататьВыделенныеСтрокиToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.печататьВыделенныеСтрокиToolStripMenuItem.Text = "Print selected strings";
            this.печататьВыделенныеСтрокиToolStripMenuItem.Click += new System.EventHandler(this.печататьВыделенныеСтрокиToolStripMenuItem_Click);
            // 
            // frmBPPP_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 289);
            this.Controls.Add(this.lstTest);
            this.Name = "frmBPPP_Report";
            this.Text = "frmBPPP_Report";
            this.Activated += new System.EventHandler(this.frmBPPP_Report_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBPPP_Report_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTest;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem очиститьЛогToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скопироватьВБуферToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печататьВыделенныеСтрокиToolStripMenuItem;
    }
}