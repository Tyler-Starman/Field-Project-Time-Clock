
namespace TimeClock
{
    partial class SelectStudents
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
            this.btnMove = new System.Windows.Forms.Button();
            this.lvSelectedStudents = new System.Windows.Forms.ListView();
            this.lvStudentNames = new System.Windows.Forms.ListView();
            this.btnMoveBack = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintTotals = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMove.Location = new System.Drawing.Point(379, 121);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(43, 42);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = ">";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lvSelectedStudents
            // 
            this.lvSelectedStudents.HideSelection = false;
            this.lvSelectedStudents.Location = new System.Drawing.Point(508, 82);
            this.lvSelectedStudents.Name = "lvSelectedStudents";
            this.lvSelectedStudents.Size = new System.Drawing.Size(229, 229);
            this.lvSelectedStudents.TabIndex = 3;
            this.lvSelectedStudents.UseCompatibleStateImageBehavior = false;
            // 
            // lvStudentNames
            // 
            this.lvStudentNames.HideSelection = false;
            this.lvStudentNames.Location = new System.Drawing.Point(74, 82);
            this.lvStudentNames.Name = "lvStudentNames";
            this.lvStudentNames.Size = new System.Drawing.Size(229, 229);
            this.lvStudentNames.TabIndex = 4;
            this.lvStudentNames.UseCompatibleStateImageBehavior = false;
            // 
            // btnMoveBack
            // 
            this.btnMoveBack.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveBack.Location = new System.Drawing.Point(379, 208);
            this.btnMoveBack.Name = "btnMoveBack";
            this.btnMoveBack.Size = new System.Drawing.Size(43, 42);
            this.btnMoveBack.TabIndex = 5;
            this.btnMoveBack.Text = "<";
            this.btnMoveBack.UseVisualStyleBackColor = true;
            this.btnMoveBack.Click += new System.EventHandler(this.btnMoveBack_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(298, 332);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 46);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print Out Times";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintTotals
            // 
            this.btnPrintTotals.Location = new System.Drawing.Point(416, 332);
            this.btnPrintTotals.Name = "btnPrintTotals";
            this.btnPrintTotals.Size = new System.Drawing.Size(109, 46);
            this.btnPrintTotals.TabIndex = 7;
            this.btnPrintTotals.Text = "Print Out Totals";
            this.btnPrintTotals.UseVisualStyleBackColor = true;
            this.btnPrintTotals.Click += new System.EventHandler(this.btnPrintTotals_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(354, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 46);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(12, 392);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(90, 46);
            this.btnDeleteStudent.TabIndex = 9;
            this.btnDeleteStudent.Text = "Delete Students";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // SelectStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrintTotals);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnMoveBack);
            this.Controls.Add(this.lvStudentNames);
            this.Controls.Add(this.lvSelectedStudents);
            this.Controls.Add(this.btnMove);
            this.Name = "SelectStudents";
            this.Text = "SelectStudents";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.ListView lvSelectedStudents;
        private System.Windows.Forms.ListView lvStudentNames;
        private System.Windows.Forms.Button btnMoveBack;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintTotals;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDeleteStudent;
    }
}