using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeTaskTrackerDB.ClassesWithTableFields;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeTaskTrackerDB
{
    public partial class FormTask : Form
    {
        private RequestSQL requestSQL;
        private int Id;
        public FormTask(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            requestSQL = new RequestSQL();
            SizeColsDGW(dgvTask);
            ConclusionTask();
        }

        private void butAddTask_Click(object sender, EventArgs e)
        {
            FormAddTask formAddTask = new FormAddTask(Id);
            formAddTask.ShowDialog();
            ConclusionTask();
        }

        private void ConclusionTask()
        {
            List<Tasks> tasks = requestSQL.GetTasksByEmployeeId(Id);
            dgvTask.Rows.Clear();

            foreach (Tasks task in tasks)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell taskName = new DataGridViewTextBoxCell();
                taskName.Value = task.TaskName;
                row.Cells.Add(taskName);

                DataGridViewTextBoxCell description = new DataGridViewTextBoxCell();
                description.Value = task.Description;
                row.Cells.Add(description);

                DataGridViewTextBoxCell taskProject = new DataGridViewTextBoxCell();
                taskProject.Value = requestSQL.GetProjectNameById(task.ProjectId);
                row.Cells.Add(taskProject);

                dgvTask.Rows.Add(row);
            }
        }


        private void dgvTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Задает ширину столбцов из таблицы в зависимости от ширины экрана
        /// </summary>
        public void SizeColsDGW(DataGridView dataGridView)
        {
            int columnCount = dataGridView.ColumnCount;
            int totalWidth = dataGridView.ClientSize.Width; // Ширина клиентской области DataGridView
            if(columnCount == 3)
            {
                dataGridView.Columns[0].Width = Convert.ToInt32(totalWidth * 0.25);
                dataGridView.Columns[1].Width = Convert.ToInt32(totalWidth * 0.45);
                dataGridView.Columns[2].Width = Convert.ToInt32(totalWidth * 0.3);
            }
            else
            {
                int columnWidth = (int)(totalWidth / columnCount);
                for (int i = 0; i < columnCount; i++)
                {
                    dataGridView.Columns[i].Width = columnWidth;
                }
            }
        }

        private void butAttach_Click(object sender, EventArgs e)
        {
            FormAttachTask formAttachTask = new FormAttachTask(Id);
            formAttachTask.ShowDialog();
            ConclusionTask();
        }
    }
}
