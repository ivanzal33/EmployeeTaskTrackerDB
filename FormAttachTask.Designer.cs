namespace EmployeeTaskTrackerDB
{
    partial class FormAttachTask
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
            this.butAttach = new System.Windows.Forms.Button();
            this.cProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cTask = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butAddTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butAttach
            // 
            this.butAttach.Location = new System.Drawing.Point(363, 171);
            this.butAttach.Name = "butAttach";
            this.butAttach.Size = new System.Drawing.Size(144, 31);
            this.butAttach.TabIndex = 0;
            this.butAttach.Text = "Прикрепить";
            this.butAttach.UseVisualStyleBackColor = true;
            this.butAttach.Click += new System.EventHandler(this.butAttach_Click);
            // 
            // cProject
            // 
            this.cProject.FormattingEnabled = true;
            this.cProject.Location = new System.Drawing.Point(12, 50);
            this.cProject.Margin = new System.Windows.Forms.Padding(2);
            this.cProject.Name = "cProject";
            this.cProject.Size = new System.Drawing.Size(495, 24);
            this.cProject.TabIndex = 7;
            this.cProject.SelectionChangeCommitted += new System.EventHandler(this.cProject_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите проект:";
            // 
            // cTask
            // 
            this.cTask.FormattingEnabled = true;
            this.cTask.Location = new System.Drawing.Point(12, 119);
            this.cTask.Margin = new System.Windows.Forms.Padding(2);
            this.cTask.Name = "cTask";
            this.cTask.Size = new System.Drawing.Size(495, 24);
            this.cTask.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите задачу:";
            // 
            // butAddTask
            // 
            this.butAddTask.Location = new System.Drawing.Point(13, 171);
            this.butAddTask.Name = "butAddTask";
            this.butAddTask.Size = new System.Drawing.Size(202, 31);
            this.butAddTask.TabIndex = 10;
            this.butAddTask.Text = "Добавить задачу";
            this.butAddTask.UseVisualStyleBackColor = true;
            this.butAddTask.Click += new System.EventHandler(this.butAddTask_Click);
            // 
            // FormAttachTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 214);
            this.Controls.Add(this.butAddTask);
            this.Controls.Add(this.cTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butAttach);
            this.Name = "FormAttachTask";
            this.Text = "Прикрипить сотрудника к задаче";
            this.Load += new System.EventHandler(this.FormAttachTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAttach;
        private System.Windows.Forms.ComboBox cProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butAddTask;
    }
}