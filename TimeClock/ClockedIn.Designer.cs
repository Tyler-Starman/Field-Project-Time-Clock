
namespace TimeClock
{
    partial class ClockedIn
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
            this.dgvClockedIn = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClockedIn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClockedIn
            // 
            this.dgvClockedIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClockedIn.Location = new System.Drawing.Point(13, 13);
            this.dgvClockedIn.Name = "dgvClockedIn";
            this.dgvClockedIn.RowTemplate.Height = 25;
            this.dgvClockedIn.Size = new System.Drawing.Size(382, 302);
            this.dgvClockedIn.TabIndex = 0;
            // 
            // ClockedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 327);
            this.Controls.Add(this.dgvClockedIn);
            this.Name = "ClockedIn";
            this.Text = "ClockedIn";
            this.Load += new System.EventHandler(this.ClockedIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClockedIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClockedIn;
    }
}