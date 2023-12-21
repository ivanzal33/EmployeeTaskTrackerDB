namespace EmployeeTaskTrackerDB
{
    partial class FormValue
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
            this.lName = new System.Windows.Forms.Label();
            this.tValue = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lName.AutoSize = true;
            this.lName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lName.Location = new System.Drawing.Point(13, 21);
            this.lName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(186, 25);
            this.lName.TabIndex = 0;
            this.lName.Text = "Введите название ";
            this.lName.Click += new System.EventHandler(this.lName_Click);
            // 
            // tValue
            // 
            this.tValue.Location = new System.Drawing.Point(18, 62);
            this.tValue.Name = "tValue";
            this.tValue.Size = new System.Drawing.Size(587, 29);
            this.tValue.TabIndex = 18;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(416, 361);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(189, 39);
            this.butAdd.TabIndex = 21;
            this.butAdd.Text = "Добавить";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(587, 223);
            this.dataGridView1.TabIndex = 22;
            // 
            // FormValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 412);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tValue);
            this.Controls.Add(this.butAdd);
            this.Name = "FormValue";
            this.Text = "Добавить ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tValue;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}