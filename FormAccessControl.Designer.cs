namespace EmployeeTaskTrackerDB
{
    partial class FormAccessControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.tLogin = new System.Windows.Forms.TextBox();
            this.tPassport = new System.Windows.Forms.TextBox();
            this.butSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // tLogin
            // 
            this.tLogin.Location = new System.Drawing.Point(146, 33);
            this.tLogin.Name = "tLogin";
            this.tLogin.Size = new System.Drawing.Size(485, 29);
            this.tLogin.TabIndex = 2;
            // 
            // tPassport
            // 
            this.tPassport.Location = new System.Drawing.Point(146, 81);
            this.tPassport.Name = "tPassport";
            this.tPassport.Size = new System.Drawing.Size(485, 29);
            this.tPassport.TabIndex = 3;
            // 
            // butSignIn
            // 
            this.butSignIn.Location = new System.Drawing.Point(38, 134);
            this.butSignIn.Name = "butSignIn";
            this.butSignIn.Size = new System.Drawing.Size(193, 45);
            this.butSignIn.TabIndex = 4;
            this.butSignIn.Text = "Войти";
            this.butSignIn.UseVisualStyleBackColor = true;
            this.butSignIn.Click += new System.EventHandler(this.butSignIn_Click);
            // 
            // FormAccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 191);
            this.Controls.Add(this.butSignIn);
            this.Controls.Add(this.tPassport);
            this.Controls.Add(this.tLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAccessControl";
            this.Text = "Авторизация пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tLogin;
        private System.Windows.Forms.TextBox tPassport;
        private System.Windows.Forms.Button butSignIn;
    }
}