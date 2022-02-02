
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
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMove.Location = new System.Drawing.Point(541, 233);
            this.btnMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(61, 70);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = ">";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lvSelectedStudents
            // 
            this.lvSelectedStudents.HideSelection = false;
            this.lvSelectedStudents.Location = new System.Drawing.Point(723, 185);
            this.lvSelectedStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvSelectedStudents.Name = "lvSelectedStudents";
            this.lvSelectedStudents.Size = new System.Drawing.Size(325, 379);
            this.lvSelectedStudents.TabIndex = 3;
            this.lvSelectedStudents.UseCompatibleStateImageBehavior = false;
            // 
            // lvStudentNames
            // 
            this.lvStudentNames.HideSelection = false;
            this.lvStudentNames.Location = new System.Drawing.Point(106, 185);
            this.lvStudentNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvStudentNames.Name = "lvStudentNames";
            this.lvStudentNames.Size = new System.Drawing.Size(325, 379);
            this.lvStudentNames.TabIndex = 4;
            this.lvStudentNames.UseCompatibleStateImageBehavior = false;
            this.lvStudentNames.SelectedIndexChanged += new System.EventHandler(this.lvStudentNames_SelectedIndexChanged);
            // 
            // btnMoveBack
            // 
            this.btnMoveBack.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveBack.Location = new System.Drawing.Point(541, 375);
            this.btnMoveBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveBack.Name = "btnMoveBack";
            this.btnMoveBack.Size = new System.Drawing.Size(61, 70);
            this.btnMoveBack.TabIndex = 5;
            this.btnMoveBack.Text = "<";
            this.btnMoveBack.UseVisualStyleBackColor = true;
            this.btnMoveBack.Click += new System.EventHandler(this.btnMoveBack_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(494, 602);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(164, 68);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print Selected Students";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // SelectStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnMoveBack);
            this.Controls.Add(this.lvStudentNames);
            this.Controls.Add(this.lvSelectedStudents);
            this.Controls.Add(this.btnMove);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}