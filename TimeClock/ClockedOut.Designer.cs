
namespace TimeClock
{
    partial class ClockedOut
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
            this.dgvClockedOut = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClockedOut)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClockedOut
            // 
            this.dgvClockedOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClockedOut.Location = new System.Drawing.Point(13, 22);
            this.dgvClockedOut.Name = "dgvClockedOut";
            this.dgvClockedOut.RowTemplate.Height = 25;
            this.dgvClockedOut.Size = new System.Drawing.Size(290, 288);
            this.dgvClockedOut.TabIndex = 0;
            // 
            // ClockedOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 335);
            this.Controls.Add(this.dgvClockedOut);
            this.Name = "ClockedOut";
            this.Text = "ClockedOut";
            this.Load += new System.EventHandler(this.ClockedOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClockedOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClockedOut;
    }
}