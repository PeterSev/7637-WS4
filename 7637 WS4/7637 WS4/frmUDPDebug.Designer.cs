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
            this.lstLogService = new System.Windows.Forms.ListBox();
            this.lstLogDebug = new System.Windows.Forms.ListBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.numDescr = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDescr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
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
            // lstLogService
            // 
            this.lstLogService.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLogService.ItemHeight = 14;
            this.lstLogService.Location = new System.Drawing.Point(12, 41);
            this.lstLogService.Name = "lstLogService";
            this.lstLogService.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLogService.Size = new System.Drawing.Size(1386, 256);
            this.lstLogService.TabIndex = 1;
            // 
            // lstLogDebug
            // 
            this.lstLogDebug.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLogDebug.ItemHeight = 14;
            this.lstLogDebug.Location = new System.Drawing.Point(12, 303);
            this.lstLogDebug.Name = "lstLogDebug";
            this.lstLogDebug.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLogDebug.Size = new System.Drawing.Size(1386, 256);
            this.lstLogDebug.TabIndex = 2;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(342, 12);
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
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1072, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Запуск программы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descriptor";
            // 
            // numStep
            // 
            this.numStep.Location = new System.Drawing.Point(875, 15);
            this.numStep.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(70, 20);
            this.numStep.TabIndex = 4;
            this.numStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(840, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Step";
            // 
            // frmUDPDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numStep);
            this.Controls.Add(this.numDescr);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.lstLogDebug);
            this.Controls.Add(this.lstLogService);
            this.Controls.Add(this.btnCloseUDP);
            this.Controls.Add(this.btnCreateUDP);
            this.Name = "frmUDPDebug";
            this.Text = "frmUDPDebug";
            this.Activated += new System.EventHandler(this.frmUDPDebug_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUDPDebug_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numDescr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUDP;
        private System.Windows.Forms.Button btnCloseUDP;
        private System.Windows.Forms.ListBox lstLogService;
        private System.Windows.Forms.ListBox lstLogDebug;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.NumericUpDown numDescr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.Label label2;
    }
}