using EmployeeTaskTrackerDB.ClassesWithTableFields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeTaskTrackerDB
{
    public partial class FormAddEmployee : Form
    {
        RequestSQL requestSQL;
        public FormAddEmployee()
        {
            requestSQL = new RequestSQL();
            InitializeComponent();
            PopulateDepartmentComboBox();
        }

        /// <summary>
        /// Добавить адресс
        /// </summary>
        private void AddAdresse(out Addresses address)
        {
            address = new Addresses();
            address.CityId = Convert.ToInt32(cCity.SelectedValue);
            address.Street = tStreet.Text;
            address.HouseNumber = tHouseNumber.Text;
            address.ApartmentNumber = tApartmentNumber.Text;
            address.PostalCode = Convert.ToInt32(tPostalCode.Text);
            requestSQL.AddAddress(ref address);
        }

        /// <summary>
        /// Добавить паспорт
        /// </summary>
        /// <param name="passports"></param>
        private void AddPassport(out Passports passports, int employeeId)
        {
            passports = new Passports();
            passports.PassportNumber = Convert.ToInt32(tPassportNumberSeria.Text + tPassportNumber.Text);
            passports.PassportIssueCode = Convert.ToInt32(tPassportIsueCode.Text);
            passports.PassportIssueDate = dtpPassporIsueDate.Value;
            requestSQL.AddPassport(ref passports, employeeId);
        }

        /// <summary>
        /// Добавить зарплату
        /// </summary>
        /// <param name="salarys"></param>
        /// <param name="emploeeId"></param>
        private void AddSalary(out Salarys salarys, int emploeeId)
        {
            salarys = new Salarys();
            salarys.EmployeeId = emploeeId;
            salarys.BaseSalary = Convert.ToInt32(tBaseSalary.Text);
            salarys.OverSalaryAmount = Convert.ToInt32(tOverSalaryAmount.Text);
            salarys.OverSalaryPeriod = dtpOverSalaryPeriodStart.Value.ToString() + " - " + dtpOverSalaryPeriodEnd.Value.ToString();
            requestSQL.AddSalary(ref salarys, emploeeId);
        }

        /// <summary>
        /// Добавить бонусы
        /// </summary>
        /// <param name="bonuses"></param>
        /// <param name="emploeeId"></param>
        private void AddBonuses(out Bonuses bonuses, int emploeeId)
        {
            bonuses = new Bonuses();
            bonuses.EmployeeId = emploeeId;
            bonuses.Amount = Convert.ToInt32(tAmountBonuses.Text);
            bonuses.Date = dtpDateBonuses.Value;
            requestSQL.AddBonuses(ref bonuses, emploeeId);
        }

        private void bAddEmployee_Click(object sender, EventArgs e)
        {
            AddAdresse(out Addresses address);

            Employees employee = new Employees();
            employee.LastName = tLastName.Text;
            employee.FirstName = tFirstName.Text;
            employee.MiddleName = tMiddleName.Text;
            employee.Email = tEmail.Text;
            employee.PhoneNumber = tPhoneNumber.Text;
            employee.DataJoined = dtpDataJoined.Value;
            employee.DepartmentId = (int)cDepartment.SelectedValue;
            employee.PositionId = (int)cPosition.SelectedValue;
            employee.AddressId = address.AddressId;
            employee.DateOfBirth = dtpDataOfBirth.Value;

            requestSQL.AddEmployee(ref employee);
            AddPassport(out Passports passports, employee.EmployeeID);
            AddSalary(out Salarys salarys, employee.EmployeeID);
            AddBonuses(out Bonuses bonuses, employee.EmployeeID);
            this.Close();
        }

        /// <summary>
        /// заполнить comboBox названиями
        /// </summary>
        private void PopulateDepartmentComboBox()
        {
            cRegion.Enabled = false;
            cCity.Enabled = false;
            butChangedRegion.Enabled = false;
            butChangedCity.Enabled = false;

            List<Value> departments;
            List<Value> positions;
            List<Value> countrys;

            departments = requestSQL.SelectDepartment();
            positions = requestSQL.SelectPosition();
            countrys = requestSQL.SelectCountry();

            FillComboBoxValue(cDepartment, departments);
            FillComboBoxValue(cPosition, positions);
            FillComboBoxValue(cCountries, countrys);
        }

        private void FillComboBoxValue(System.Windows.Forms.ComboBox comboBox, List<Value> values)
        {
            comboBox.DataSource = values;
            comboBox.DisplayMember = "Name"; // Название свойства, которое будет отображаться
            comboBox.ValueMember = "Id"; // Название свойства, которое будет использоваться как значение
            comboBox.SelectedIndex = -1;
        }

        private void butChangeDepartment_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("department");
            formValue.ShowDialog();
            PopulateDepartmentComboBox();
        }

        private void butChangePosition_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("position");
            formValue.ShowDialog();
            PopulateDepartmentComboBox();
        }

        private void butChangeCoutry_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("country");
            formValue.ShowDialog();
            PopulateDepartmentComboBox();
        }

        private void butChangedRegion_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("region", (int)cCountries.SelectedValue);
            formValue.ShowDialog();
            PopulateDepartmentComboBox();
        }

        private void butChangedCity_Click(object sender, EventArgs e)
        {
            FormValue formValue = new FormValue("city", (int)cRegion.SelectedValue);
            formValue.ShowDialog();
            PopulateDepartmentComboBox();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bFurtherAdress_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
        }

        private void bFurtherAdditional_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        private void bFurtherSalary_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 3;
        }

        private void bBackAdress_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
        }

        private void bBackPersonalData_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void bBackAdditional_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        private void cDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cCountries.SelectedIndex >= 0)
            {
                butChangedRegion.Enabled = true;
                cRegion.Enabled = true; // Разрешаем выбирать элементы во втором ComboBox
                cRegion.DataSource = null; // Очистите DataSource
                cRegion.Items.Clear();     // Очистите Items
                cCity.DataSource = null; // Очистите DataSource
                cCity.Items.Clear();     // Очистите Items
                FillComboBoxValue(cRegion, requestSQL.SelectRegionsByCountryId((int)cCountries.SelectedValue));
                cRegion.SelectedIndex = -1;
            }
            else
            {
                butChangedRegion.Enabled = false;
                cRegion.Enabled = false;
                cRegion.SelectedIndex = -1;
            }
        }

        private void cRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cRegion.SelectedIndex >= 0)
            {
                butChangedCity.Enabled = true;
                cCity.Enabled = true; // Разрешаем выбирать элементы во втором ComboBox
                cCity.DataSource = null; // Очистите DataSource
                cCity.Items.Clear();     // Очистите Items
                FillComboBoxValue(cCity, requestSQL.SelectCitiesByRegionId((int)cRegion.SelectedValue));
                cCity.SelectedIndex = -1;
            }
            else
            {
                butChangedCity.Enabled = false;
                cCity.Enabled = false;
                cCity.SelectedIndex = -1;
            }
        }


        private void tPassportNumberSeria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tPassportNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tPassportIsueCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tHouseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tApartmentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tBaseSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tOverSalaryAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }

        private void tAmountBonuses_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Если символ не цифра и не Backspace, отменяем ввод
                e.Handled = true;
            }
        }
    }
}
