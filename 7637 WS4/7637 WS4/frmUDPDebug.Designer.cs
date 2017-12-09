namespace _7637_WS4
{
    partial class frmUDPDebug
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
            this.btnCreateUDP = new System.Windows.Forms.Button();
            this.btnCloseUDP = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lstLogExc = new System.Windows.Forms.ListBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.numDescr = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDescr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateUDP
            // 
            this.btnCreateUDP.Location = new System.Drawing.Point(12, 12);
            this.btnCreateUDP.Name = "btnCreateUDP";
            this.btnCreateUDP.Size = new System.Drawing.Size(124, 23);
            this.btnCreateUDP.TabIndex = 0;
            this.btnCreateUDP.Text = "Создать UDP";
            this.btnCreateUDP.UseVisualStyleBackColor = true;
            this.btnCreateUDP.Click += new System.EventHandler(this.btnCreateUDP_Click);
            // 
            // btnCloseUDP
            // 
            this.btnCloseUDP.Location = new System.Drawing.Point(142, 12);
            this.btnCloseUDP.Name = "btnCloseUDP";
            this.btnCloseUDP.Size = new System.Drawing.Size(75, 23);
            this.btnCloseUDP.TabIndex = 0;
            this.btnCloseUDP.Text = "Закрыть";
            this.btnCloseUDP.UseVisualStyleBackColor = true;
            this.btnCloseUDP.Click += new System.EventHandler(this.btnCloseUDP_Click);
            // 
            // lstLog
            // 
            this.lstLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLog.ItemHeight = 14;
            this.lstLog.Location = new System.Drawing.Point(12, 41);
            this.lstLog.Name = "lstLog";
            this.lstLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLog.Size = new System.Drawing.Size(1386, 256);
            this.lstLog.TabIndex = 1;
            // 
            // lstLogExc
            // 
            this.lstLogExc.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLogExc.ItemHeight = 14;
            this.lstLogExc.Location = new System.Drawing.Point(12, 303);
            this.lstLogExc.Name = "lstLogExc";
            this.lstLogExc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLogExc.Size = new System.Drawing.Size(1386, 256);
            this.lstLogExc.TabIndex = 2;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(515, 12);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(161, 23);
            this.btnSendCommand.TabIndex = 3;
            this.btnSendCommand.Text = "Послать команду";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // numDescr
            // 
            this.numDescr.Location = new System.Drawing.Point(704, 15);
            this.numDescr.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numDescr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDescr.Name = "numDescr";
            this.numDescr.Size = new System.Drawing.Size(70, 20);
            this.numDescr.TabIndex = 4;
            this.numDescr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDescr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmUDPDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 570);
            this.Controls.Add(this.numDescr);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.lstLogExc);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnCloseUDP);
            this.Controls.Add(this.btnCreateUDP);
            this.Name = "frmUDPDebug";
            this.Text = "frmUDPDebug";
            this.Activated += new System.EventHandler(this.frmUDPDebug_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUDPDebug_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numDescr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUDP;
        private System.Windows.Forms.Button btnCloseUDP;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ListBox lstLogExc;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.NumericUpDown numDescr;
    }
}