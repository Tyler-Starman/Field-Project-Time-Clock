
namespace TimeClock
{
    partial class Admin
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
            this.btnClockedIn = new System.Windows.Forms.Button();
            this.btnClockedTimes = new System.Windows.Forms.Button();
            this.btnTermYear = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnClockOutAll = new System.Windows.Forms.Button();
            this.btnClockedOut = new System.Windows.Forms.Button();
            this.btnPrintOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClockedIn
            // 
            this.btnClockedIn.Location = new System.Drawing.Point(50, 131);
            this.btnClockedIn.Name = "btnClockedIn";
            this.btnClockedIn.Size = new System.Drawing.Size(119, 40);
            this.btnClockedIn.TabIndex = 0;
            this.btnClockedIn.Text = "View Students Clocked In";
            this.btnClockedIn.UseVisualStyleBackColor = true;
            this.btnClockedIn.Click += new System.EventHandler(this.btnClockedIn_Click);
            // 
            // btnClockedTimes
            // 
            this.btnClockedTimes.Location = new System.Drawing.Point(343, 131);
            this.btnClockedTimes.Name = "btnClockedTimes";
            this.btnClockedTimes.Size = new System.Drawing.Size(119, 40);
            this.btnClockedTimes.TabIndex = 1;
            this.btnClockedTimes.Text = "View Clock Out Times";
            this.btnClockedTimes.UseVisualStyleBackColor = true;
            this.btnClockedTimes.Click += new System.EventHandler(this.btnClockedTimes_Click);
            // 
            // btnTermYear
            // 
            this.btnTermYear.Location = new System.Drawing.Point(50, 74);
            this.btnTermYear.Name = "btnTermYear";
            this.btnTermYear.Size = new System.Drawing.Size(119, 40);
            this.btnTermYear.TabIndex = 2;
            this.btnTermYear.Text = "Change Term/Year";
            this.btnTermYear.UseVisualStyleBackColor = true;
            this.btnTermYear.Click += new System.EventHandler(this.btnTermYear_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(193, 194);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(119, 40);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return To Menu";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClockOutAll
            // 
            this.btnClockOutAll.Location = new System.Drawing.Point(343, 74);
            this.btnClockOutAll.Name = "btnClockOutAll";
            this.btnClockOutAll.Size = new System.Drawing.Size(119, 40);
            this.btnClockOutAll.TabIndex = 4;
            this.btnClockOutAll.Text = "Clock Out All";
            this.btnClockOutAll.UseVisualStyleBackColor = true;
            this.btnClockOutAll.Click += new System.EventHandler(this.btnClockOutAll_Click);
            // 
            // btnClockedOut
            // 
            this.btnClockedOut.Location = new System.Drawing.Point(193, 131);
            this.btnClockedOut.Name = "btnClockedOut";
            this.btnClockedOut.Size = new System.Drawing.Size(119, 40);
            this.btnClockedOut.TabIndex = 5;
            this.btnClockedOut.Text = "View Students Clocked Out";
            this.btnClockedOut.UseVisualStyleBackColor = true;
            this.btnClockedOut.Click += new System.EventHandler(this.btnClockedOut_Click);
            // 
            // btnPrintOut
            // 
            this.btnPrintOut.Location = new System.Drawing.Point(193, 74);
            this.btnPrintOut.Name = "btnPrintOut";
            this.btnPrintOut.Size = new System.Drawing.Size(119, 40);
            this.btnPrintOut.TabIndex = 8;
            this.btnPrintOut.Text = "Print Out Data";
            this.btnPrintOut.UseVisualStyleBackColor = true;
            this.btnPrintOut.Click += new System.EventHandler(this.btnPrintOut_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 264);
            this.Controls.Add(this.btnPrintOut);
            this.Controls.Add(this.btnClockedOut);
            this.Controls.Add(this.btnClockOutAll);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnTermYear);
            this.Controls.Add(this.btnClockedTimes);
            this.Controls.Add(this.btnClockedIn);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClockedIn;
        private System.Windows.Forms.Button btnClockedTimes;
        private System.Windows.Forms.Button btnTermYear;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClockOutAll;
        private System.Windows.Forms.Button btnClockedOut;
        private System.Windows.Forms.Button btnPrintOut;
    }
}