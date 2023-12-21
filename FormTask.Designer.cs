namespace EmployeeTaskTrackerDB
{
    partial class FormTask
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
            this.butAddTask = new System.Windows.Forms.Button();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.butAttach = new System.Windows.Forms.Button();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.SuspendLayout();
            // 
            // butAddTask
            // 
            this.butAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddTask.Location = new System.Drawing.Point(1, 7);
            this.butAddTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butAddTask.Name = "butAddTask";
            this.butAddTask.Size = new System.Drawing.Size(207, 31);
            this.butAddTask.TabIndex = 1;
            this.butAddTask.Text = "Добавить задачу";
            this.butAddTask.UseVisualStyleBackColor = true;
            this.butAddTask.Click += new System.EventHandler(this.butAddTask_Click);
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskDescription,
            this.TaskProject});
            this.dgvTask.Location = new System.Drawing.Point(1, 52);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.RowHeadersVisible = false;
            this.dgvTask.RowHeadersWidth = 51;
            this.dgvTask.RowTemplate.Height = 24;
            this.dgvTask.Size = new System.Drawing.Size(1280, 423);
            this.dgvTask.TabIndex = 2;
            this.dgvTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTask_CellContentClick);
            // 
            // butAttach
            // 
            this.butAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAttach.Location = new System.Drawing.Point(238, 7);
            this.butAttach.Name = "butAttach";
            this.butAttach.Size = new System.Drawing.Size(195, 31);
            this.butAttach.TabIndex = 3;
            this.butAttach.Text = "Прикрепить к задаче";
            this.butAttach.UseVisualStyleBackColor = true;
            this.butAttach.Click += new System.EventHandler(this.butAttach_Click);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Задача";
            this.TaskName.MinimumWidth = 6;
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            this.TaskName.Width = 125;
            // 
            // TaskDescription
            // 
            this.TaskDescription.HeaderText = "Описание";
            this.TaskDescription.MinimumWidth = 6;
            this.TaskDescription.Name = "TaskDescription";
            this.TaskDescription.ReadOnly = true;
            this.TaskDescription.Width = 125;
            // 
            // TaskProject
            // 
            this.TaskProject.HeaderText = "Проект";
            this.TaskProject.MinimumWidth = 6;
            this.TaskProject.Name = "TaskProject";
            this.TaskProject.ReadOnly = true;
            this.TaskProject.Width = 125;
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 475);
            this.Controls.Add(this.butAttach);
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.butAddTask);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTask";
            this.Text = "Задачи";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butAddTask;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Button butAttach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskProject;
    }
}