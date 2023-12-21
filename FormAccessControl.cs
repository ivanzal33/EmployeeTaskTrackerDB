using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTaskTrackerDB
{
    public partial class FormAccessControl : Form
    {
        public FormAccessControl()
        {
            InitializeComponent();
        }

        private void butSignIn_Click(object sender, EventArgs e)
        {
            string passport = tPassport.Text;
            string login = tLogin.Text;
            RequestSQL requestSQL = new RequestSQL();
            try
            {
                bool access = requestSQL.AuthenticateUser(login, passport, out bool userFound);
                if (!userFound)
                {
                    MessageBox.Show("Такого пользователдя не существует, попробуйте еще раз", "Авторизация пользователя");
                }
                else
                {
                    this.Close();
                    FormTracker formTracker = new FormTracker(access);
                    formTracker.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Пользователя с таким логином или паролем не существует, попробуйте еще раз", "Авторизация пользователя");
            }
        }
    }
}
