using EmployeeTaskTrackerDB.ClassesWithTableFields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTaskTrackerDB
{
    public partial class FormAttachTask : Form
    {
        private int Id;
        private RequestSQL requestSQL;
        public FormAttachTask(int Id)
        {
            requestSQL = new RequestSQL();
            this.Id = Id;
            InitializeComponent();
            cTask.Enabled = false;
            WithdrawProjectComboBox();
        }

        private void FormAttachTask_Load(object sender, EventArgs e)
        {

        }

        private void butAddTask_Click(object sender, EventArgs e)
        {
            FormAddTask formAddTask = new FormAddTask(Id);
            formAddTask.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Вывести проеты в comboBox
        /// </summary>
        public void WithdrawProjectComboBox()
        {
            List<Value> values = requestSQL.SelectProjects();
            FillComboBoxValue(cProject, values);
        }
        private void FillComboBoxValue(System.Windows.Forms.ComboBox comboBox, List<Value> values)
        {
            comboBox.DataSource = values;
            comboBox.DisplayMember = "Name"; // Название свойства, которое будет отображаться
            comboBox.ValueMember = "Id"; // Название свойства, которое будет использоваться как значение
            comboBox.SelectedIndex = -1;
        }

        private void butAttach_Click(object sender, EventArgs e)
        {
            requestSQL.AssignTaskToEmployee((int)cTask.SelectedValue, Id);
            this.Close();
        }

        private void cProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cProject.SelectedIndex >= 0)
            {
                cTask.Enabled = true; // Разрешаем выбирать элементы во втором ComboBox
                cTask.DataSource = null; // Очистите DataSource
                cTask.Items.Clear();     // Очистите Items
                FillComboBoxValue(cTask, requestSQL.GetTasksByProjectId((int)cProject.SelectedValue));
            }
            else
            {
                cTask.Enabled = false;
            }
        }
    }
}
