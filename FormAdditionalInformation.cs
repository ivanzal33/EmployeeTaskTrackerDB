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
    public partial class FormAdditionalInformation : Form
    {
        private int ID;
        public FormAdditionalInformation(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            WriteAdditionalInfirmation();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WriteAdditionalInfirmation()
        {
            RequestSQL requestSQL = new RequestSQL();
            EmployeeDetails employeeDetails = requestSQL.GetEmployeeDetailsById(ID);
            lPassportNumber.Text = employeeDetails.PassportNumber;
            lPassportIssueCode.Text = employeeDetails.PassportIssueCode;
            lPassportIssueDate.Text = employeeDetails.PassportIssueDate;
            lDataJoined.Text = employeeDetails.DateJoined;
            lBaseSalary.Text = employeeDetails.BaseSalary.ToString();
            lOverSalaryAmount.Text = employeeDetails?.OverSalaryAmount.ToString();
            lOverSalaryPeriod.Text = employeeDetails?.OverSalaryPeriod.ToString();
            lAmountBonus.Text = employeeDetails?.AmountOfBonuses.ToString();
            lDateBonus.Text = employeeDetails?.DateOfBonuses.ToString();
        }
    }
}
