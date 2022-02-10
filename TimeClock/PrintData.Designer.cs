
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintData));
            this.btnPrintTotals = new System.Windows.Forms.Button();
            this.btnPrintTimes = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // btnPrintTotals
            // 
            this.btnPrintTotals.Location = new System.Drawing.Point(324, 177);
            this.btnPrintTotals.Name = "btnPrintTotals";
            this.btnPrintTotals.Size = new System.Drawing.Size(168, 96);
            this.btnPrintTotals.TabIndex = 0;
            this.btnPrintTotals.Text = "Print Out Totals";
            this.btnPrintTotals.UseVisualStyleBackColor = true;
            this.btnPrintTotals.Click += new System.EventHandler(this.btnPrintTotals_Click);
            // 
            // btnPrintTimes
            // 
            this.btnPrintTimes.Location = new System.Drawing.Point(67, 177);
            this.btnPrintTimes.Name = "btnPrintTimes";
            this.btnPrintTimes.Size = new System.Drawing.Size(168, 96);
            this.btnPrintTimes.TabIndex = 1;
            this.btnPrintTimes.Text = "Print Out Times";
            this.btnPrintTimes.UseVisualStyleBackColor = true;
            this.btnPrintTimes.Click += new System.EventHandler(this.btnPrintTimes_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(187, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(427, 54);
            this.lblHeader.TabIndex = 20;
            this.lblHeader.Text = "Print Out Student Data";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(345, 386);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(128, 52);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "Back";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Location = new System.Drawing.Point(579, 177);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(168, 96);
            this.btnPrintSelected.TabIndex = 22;
            this.btnPrintSelected.Text = "Print Selected Students";
            this.btnPrintSelected.UseVisualStyleBackColor = true;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // PrintData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrintSelected);
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
        private System.Windows.Forms.Button btnPrintSelected;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}