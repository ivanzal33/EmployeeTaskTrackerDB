using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTaskTrackerDB
{
    public partial class FormEmployeeСard : Form
    {
        public int Id;
        private RequestSQL requestSQL;
        public FormEmployeeСard(int Id, bool access)
        {
            InitializeComponent();
            this.Id = Id;
            requestSQL = new RequestSQL();
            FillCardEmployee();
            VivodImage();
            if (access)
            {
                butAdditionalInformation.Enabled = true;
                butDelete.Enabled = true;
                butRender.Enabled = true;
            }
            else
            {
                butAdditionalInformation.Enabled = false;
                butDelete.Enabled = false;
                butRender.Enabled = false;
            }
        }

        private void butTask_Click(object sender, EventArgs e)
        {
            FormTask formTask = new FormTask(Id);
            formTask.ShowDialog();
        }

        private void butRender_Click(object sender, EventArgs e)
        {
            
        }

        private void FillCardEmployee()
        {
            
            EmployeeInfo employee = new EmployeeInfo();
            employee = requestSQL.GetEmployee(Id);

            if (employee == null)
                return;


            lFirstName.Text = employee.FirstName;
            lLastName.Text = employee.LastName;
            lMiddleName.Text = employee.MiddleName;
            lEmail.Text = employee.Email;
            lPosition.Text = employee.Position;
            lDataOfBirth.Text = employee.DateOfBirth;
            lPhoneNumber.Text = employee.PhoneNumber;
            lDepartment.Text = employee.Department;

            var addressParts = new List<string>
            {
                employee.City,
                employee.Region,
                employee.Country,
                employee.Street,
                employee.HouseNumber,
                employee.ApartmentNumber,
            };
            lAddress.Text = string.Join(", ", addressParts.Where(part => !string.IsNullOrEmpty(part)));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void VivodImage()
        {
            Image image = Image.FromFile("D:\\Visual Studio Program\\EmployeeTaskTrackerDB\\user.png");
            pictureBox1.Image = ResizeImageToPictureBox(image, pictureBox1);
        }

        private Image ResizeImageToPictureBox(Image originalImage, PictureBox pictureBox)
        {
            // Получаем размеры PictureBox
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            // Создаем новый пустой Bitmap с размерами PictureBox
            Bitmap resizedImage = new Bitmap(width, height);

            // Используем объект Graphics для рисования исходного изображения на Bitmap
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                // Устанавливаем параметры для высококачественного масштабирования изображения
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // Рисуем исходное изображение в размерах PictureBox
                gfx.DrawImage(originalImage, 0, 0, width, height);
            }

            // Возвращаем измененное изображение
            return resizedImage;
        }

        private void butAdditionalInformation_Click(object sender, EventArgs e)
        {
            FormAdditionalInformation formAdditionalInformation = new FormAdditionalInformation(Id);
            formAdditionalInformation.ShowDialog();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Если пользователь выбрал "Да", выполняем удаление
                requestSQL.DeactivateEmployee(Id);
                this.Close();
            }
            else
            {
                // Если пользователь выбрал "Отмена" или закрыл диалог, ничего не делаем
            }    
        }

        private void FormEmployeeСard_Load(object sender, EventArgs e)
        {

        }
    }
}
