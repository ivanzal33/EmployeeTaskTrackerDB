namespace EmployeeTaskTrackerDB
{
    partial class FormAddTask
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
            this.label1 = new System.Windows.Forms.Label();
            this.tTaskName = new System.Windows.Forms.TextBox();
            this.tDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cProject = new System.Windows.Forms.ComboBox();
            this.butAddProject = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите название задачи:";
            // 
            // tTaskName
            // 
            this.tTaskName.Location = new System.Drawing.Point(9, 33);
            this.tTaskName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tTaskName.Name = "tTaskName";
            this.tTaskName.Size = new System.Drawing.Size(565, 22);
            this.tTaskName.TabIndex = 1;
            // 
            // tDescription
            // 
            this.tDescription.Location = new System.Drawing.Point(9, 89);
            this.tDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tDescription.Multiline = true;
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(565, 81);
            this.tDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите описание задачи:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите проект для которого хотите поставить задачу:";
            // 
            // cProject
            // 
            this.cProject.FormattingEnabled = true;
            this.cProject.Location = new System.Drawing.Point(9, 211);
            this.cProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cProject.Name = "cProject";
            this.cProject.Size = new System.Drawing.Size(520, 24);
            this.cProject.TabIndex = 5;
            // 
            // butAddProject
            // 
            this.butAddProject.Location = new System.Drawing.Point(543, 210);
            this.butAddProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butAddProject.Name = "butAddProject";
            this.butAddProject.Size = new System.Drawing.Size(30, 25);
            this.butAddProject.TabIndex = 31;
            this.butAddProject.Text = "⚙";
            this.butAddProject.UseVisualStyleBackColor = true;
            this.butAddProject.Click += new System.EventHandler(this.butAddProject_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 248);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 25);
            this.button1.TabIndex = 32;
            this.button1.Text = "Добавить задачу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butAddProject);
            this.Controls.Add(this.cProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tTaskName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAddTask";
            this.Text = "FormAddTask";
            this.Load += new System.EventHandler(this.FormAddTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tTaskName;
        private System.Windows.Forms.TextBox tDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cProject;
        private System.Windows.Forms.Button butAddProject;
        private System.Windows.Forms.Button button1;
    }
}