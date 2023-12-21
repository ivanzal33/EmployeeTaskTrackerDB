using EmployeeTaskTrackerDB.ClassesWithTableFields;
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
    public partial class FormAddTask : Form
    {
        RequestSQL requestSQL;
        private int Id;
        public FormAddTask(int Id)
        {
            this.Id = Id;
            requestSQL = new RequestSQL();
            InitializeComponent();
            FillComboBoxValue();
        }

        private void butAddProject_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("project");
            formValue.ShowDialog();
            FillComboBoxValue();
        }

        private void FillComboBoxValue()
        {
            List<Value> values = requestSQL.SelectProjects();
            cProject.DataSource = values;
            cProject.DisplayMember = "Name"; // Название свойства, которое будет отображаться
            cProject.ValueMember = "Id"; // Название свойства, которое будет использоваться как значение
            cProject.SelectedIndex = -1;
        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tasks task = new Tasks();
            task.ProjectId = (int)cProject.SelectedValue;
            task.TaskName = tTaskName.Text;
            task.Description = tDescription.Text;
            task.EmployeeId = Id;

            requestSQL.AddTask(task);
            this.Close();
        }
    }
}
