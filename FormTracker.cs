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
    public partial class FormTracker : Form
    {
        private List<FullNameEmployee> Employee;
        private RequestSQL requestSQL = new RequestSQL();
        private bool access = false;
        public FormTracker(bool access)
        {
            InitializeComponent();
            this.access = access;   
            Employee = requestSQL.SelectEmployees();
            SizeColsDGW(dgvEmployee);
            FillTabelFullName();
            if (access)
                butAdd.Enabled = true;
            else
                butAdd.Enabled = false;
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что нажатие произошло внутри ячейки и не в заголовке столбца
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получаем объект Employee, соответствующий нажатой строке
                FullNameEmployee selectedEmployee = Employee[e.RowIndex];


                FormEmployeeСard formEmployeeСard = new FormEmployeeСard(selectedEmployee.Id, access);
                formEmployeeСard.ShowDialog();
                FillTabelFullName();
            }
        }

        /// <summary>
        /// Заполнить таблицу ФИО
        /// </summary>
        public void FillTabelFullName()
        {
            Employee = requestSQL.SelectEmployees();
            Image image = Image.FromFile("D:\\Visual Studio Program\\EmployeeTaskTrackerDB\\user.png");
            int cellWidth = dgvEmployee.Columns[0].Width;
            int cellHeight = dgvEmployee.RowTemplate.Height;

            dgvEmployee.Rows.Clear();

            foreach(FullNameEmployee employee in Employee)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Создаем ячейку для первого столбца (изображения)
                DataGridViewImageCell imageCell = new DataGridViewImageCell();
                imageCell.Value = ResizeImageForDataGridView(image, cellWidth, cellHeight);
                row.Cells.Add(imageCell);

                // Создаем ячейку для второго столбца и устанавливаем в ней значение из списка
                DataGridViewTextBoxCell fullName = new DataGridViewTextBoxCell();
                fullName.Value = employee.FullName;
                row.Cells.Add(fullName);

                // Создаем ячейку для второго столбца и устанавливаем в ней значение из списка
                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell();
                id.Value = employee.Id;
                row.Cells.Add(id);

                dgvEmployee.Rows.Add(row);
            }
        }

        /// <summary>
        /// Задает ширину столбцов из таблицы в зависимости от ширины экрана
        /// </summary>
        public void SizeColsDGW(DataGridView dataGridView)
        {
            int columnCount = dataGridView.ColumnCount;
            int totalWidth = dataGridView.ClientSize.Width; // Ширина клиентской области DataGridView

            if (columnCount == 3)
            {
                int imageWidth = (int)(totalWidth * 0.08);
                int longWidth = (int)((totalWidth - imageWidth));
                int categoryWidth = (int)(longWidth * 0.94);

                dataGridView.Columns[0].Width = imageWidth;
                dataGridView.Columns[1].Width = categoryWidth;
                dataGridView.Columns[2].Width = 1;
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

        private void butAdd_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee();
            formAddEmployee.ShowDialog();
            FillTabelFullName();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Поиск:")
            {
                textBox1.Clear();
            }
        }

        private Image ResizeImageForDataGridView(Image originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);

            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                // Задаем параметры масштабирования для лучшего качества изображения
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // Рисуем изображение в новых размерах
                gfx.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedImage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Employee.Clear();
            requestSQL.SelectEmployees(textBox1.Text, ref Employee);
            FillTabelFullName();
        }
    }
}
