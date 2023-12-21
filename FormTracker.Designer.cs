namespace EmployeeTaskTrackerDB
{
    partial class FormTracker
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
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.EmploeeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.EmploeeFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.ColumnHeadersVisible = false;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmploeeImage,
            this.EmploeeFullName,
            this.Id});
            this.dgvEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEmployee.Location = new System.Drawing.Point(9, 41);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersVisible = false;
            this.dgvEmployee.RowHeadersWidth = 72;
            this.dgvEmployee.RowTemplate.Height = 31;
            this.dgvEmployee.Size = new System.Drawing.Size(516, 381);
            this.dgvEmployee.TabIndex = 1;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // EmploeeImage
            // 
            this.EmploeeImage.HeaderText = "";
            this.EmploeeImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EmploeeImage.MinimumWidth = 9;
            this.EmploeeImage.Name = "EmploeeImage";
            this.EmploeeImage.ReadOnly = true;
            this.EmploeeImage.Width = 50;
            // 
            // EmploeeFullName
            // 
            this.EmploeeFullName.HeaderText = "";
            this.EmploeeFullName.MinimumWidth = 9;
            this.EmploeeFullName.Name = "EmploeeFullName";
            this.EmploeeFullName.ReadOnly = true;
            this.EmploeeFullName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmploeeFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmploeeFullName.Width = 400;
            // 
            // Id
            // 
            this.Id.HeaderText = "Column1";
            this.Id.MinimumWidth = 9;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 175;
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAdd.Location = new System.Drawing.Point(412, 8);
            this.butAdd.Margin = new System.Windows.Forms.Padding(2);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(113, 26);
            this.butAdd.TabIndex = 2;
            this.butAdd.Text = "Добавить";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(13, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Поиск:";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 430);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.dgvEmployee);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTracker";
            this.Text = "Выберете сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridViewImageColumn EmploeeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmploeeFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.TextBox textBox1;
    }
}