
namespace TimeClock
{
    partial class PrintData
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
            this.btnPrintTotals = new System.Windows.Forms.Button();
            this.btnPrintTimes = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintTotals
            // 
            this.btnPrintTotals.Location = new System.Drawing.Point(461, 181);
            this.btnPrintTotals.Name = "btnPrintTotals";
            this.btnPrintTotals.Size = new System.Drawing.Size(164, 88);
            this.btnPrintTotals.TabIndex = 0;
            this.btnPrintTotals.Text = "Print Out Totals";
            this.btnPrintTotals.UseVisualStyleBackColor = true;
            this.btnPrintTotals.Click += new System.EventHandler(this.btnPrintTotals_Click);
            // 
            // btnPrintTimes
            // 
            this.btnPrintTimes.Location = new System.Drawing.Point(175, 181);
            this.btnPrintTimes.Name = "btnPrintTimes";
            this.btnPrintTimes.Size = new System.Drawing.Size(164, 88);
            this.btnPrintTimes.TabIndex = 1;
            this.btnPrintTimes.Text = "Print Out Times";
            this.btnPrintTimes.UseVisualStyleBackColor = true;
            this.btnPrintTimes.Click += new System.EventHandler(this.btnPrintTimes_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(187, 26);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(427, 54);
            this.lblHeader.TabIndex = 20;
            this.lblHeader.Text = "Print Out Student Data";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(336, 330);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(128, 52);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "Back";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // PrintData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnPrintTimes);
            this.Controls.Add(this.btnPrintTotals);
            this.Name = "PrintData";
            this.Text = "PrintData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintTotals;
        private System.Windows.Forms.Button btnPrintTimes;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnReturn;
    }
}