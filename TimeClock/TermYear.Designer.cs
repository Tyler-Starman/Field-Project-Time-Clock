
namespace TimeClock
{
    partial class TermYear
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
            this.cmboTerm = new System.Windows.Forms.ComboBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblTerm = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmboTerm
            // 
            this.cmboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboTerm.FormattingEnabled = true;
            this.cmboTerm.Items.AddRange(new object[] {
            "Winter",
            "Spring",
            "Summer",
            "Fall"});
            this.cmboTerm.Location = new System.Drawing.Point(125, 69);
            this.cmboTerm.Name = "cmboTerm";
            this.cmboTerm.Size = new System.Drawing.Size(94, 23);
            this.cmboTerm.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(200, 141);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(72, 72);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(36, 15);
            this.lblTerm.TabIndex = 2;
            this.lblTerm.Text = "Term:";
            // 
            // dtpYear
            // 
            this.dtpYear.Location = new System.Drawing.Point(321, 69);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(104, 23);
            this.dtpYear.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(269, 75);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 15);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year:";
            // 
            // TermYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 205);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.cmboTerm);
            this.Name = "TermYear";
            this.Text = "Change Term/Year";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboTerm;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblYear;
    }
}