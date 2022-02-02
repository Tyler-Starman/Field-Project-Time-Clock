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
            this.btnReturn = new System.Windows.Forms.Button();
            this.dtpStartTerm = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTerm = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveDates = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnWinter = new System.Windows.Forms.RadioButton();
            this.rbtnFall = new System.Windows.Forms.RadioButton();
            this.rbtnSummer = new System.Windows.Forms.RadioButton();
            this.rbtnSpring = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(376, 288);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(107, 38);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dtpStartTerm
            // 
            this.dtpStartTerm.Location = new System.Drawing.Point(184, 64);
            this.dtpStartTerm.Name = "dtpStartTerm";
            this.dtpStartTerm.Size = new System.Drawing.Size(304, 31);
            this.dtpStartTerm.TabIndex = 5;
            // 
            // dtpEndTerm
            // 
            this.dtpEndTerm.Location = new System.Drawing.Point(184, 120);
            this.dtpEndTerm.Name = "dtpEndTerm";
            this.dtpEndTerm.Size = new System.Drawing.Size(304, 31);
            this.dtpEndTerm.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "End term";
            // 
            // btnSaveDates
            // 
            this.btnSaveDates.Location = new System.Drawing.Point(256, 288);
            this.btnSaveDates.Name = "btnSaveDates";
            this.btnSaveDates.Size = new System.Drawing.Size(112, 34);
            this.btnSaveDates.TabIndex = 9;
            this.btnSaveDates.Text = "Save";
            this.btnSaveDates.UseVisualStyleBackColor = true;
            this.btnSaveDates.Click += new System.EventHandler(this.btnSaveDates_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnWinter);
            this.groupBox1.Controls.Add(this.rbtnFall);
            this.groupBox1.Controls.Add(this.rbtnSummer);
            this.groupBox1.Controls.Add(this.rbtnSpring);
            this.groupBox1.Location = new System.Drawing.Point(80, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 160);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Term";
            // 
            // rbtnWinter
            // 
            this.rbtnWinter.AutoSize = true;
            this.rbtnWinter.Location = new System.Drawing.Point(8, 128);
            this.rbtnWinter.Name = "rbtnWinter";
            this.rbtnWinter.Size = new System.Drawing.Size(89, 29);
            this.rbtnWinter.TabIndex = 3;
            this.rbtnWinter.TabStop = true;
            this.rbtnWinter.Text = "Winter";
            this.rbtnWinter.UseVisualStyleBackColor = true;
            // 
            // rbtnFall
            // 
            this.rbtnFall.AutoSize = true;
            this.rbtnFall.Location = new System.Drawing.Point(8, 96);
            this.rbtnFall.Name = "rbtnFall";
            this.rbtnFall.Size = new System.Drawing.Size(62, 29);
            this.rbtnFall.TabIndex = 2;
            this.rbtnFall.TabStop = true;
            this.rbtnFall.Text = "Fall";
            this.rbtnFall.UseVisualStyleBackColor = true;
            // 
            // rbtnSummer
            // 
            this.rbtnSummer.AutoSize = true;
            this.rbtnSummer.Location = new System.Drawing.Point(8, 64);
            this.rbtnSummer.Name = "rbtnSummer";
            this.rbtnSummer.Size = new System.Drawing.Size(104, 29);
            this.rbtnSummer.TabIndex = 1;
            this.rbtnSummer.TabStop = true;
            this.rbtnSummer.Text = "Summer";
            this.rbtnSummer.UseVisualStyleBackColor = true;
            // 
            // rbtnSpring
            // 
            this.rbtnSpring.AutoSize = true;
            this.rbtnSpring.Location = new System.Drawing.Point(8, 32);
            this.rbtnSpring.Name = "rbtnSpring";
            this.rbtnSpring.Size = new System.Drawing.Size(89, 29);
            this.rbtnSpring.TabIndex = 0;
            this.rbtnSpring.TabStop = true;
            this.rbtnSpring.Text = "Spring";
            this.rbtnSpring.UseVisualStyleBackColor = true;
            // 
            // TermYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveDates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndTerm);
            this.Controls.Add(this.dtpStartTerm);
            this.Controls.Add(this.btnReturn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TermYear";
            this.Text = "Change Term/Year";
            this.Load += new System.EventHandler(this.TermYear_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DateTimePicker dtpStartTerm;
        private System.Windows.Forms.DateTimePicker dtpEndTerm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnWinter;
        private System.Windows.Forms.RadioButton rbtnFall;
        private System.Windows.Forms.RadioButton rbtnSummer;
        private System.Windows.Forms.RadioButton rbtnSpring;
    }
}