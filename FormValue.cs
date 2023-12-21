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
    public partial class FormValue : Form
    {
        private string Name;
        private int IdPerent;
        public FormValue(string Name)
        {
            InitializeComponent();
            this.Name = Name;
        }

        public FormValue(string Name, int IdPerent)
        {
            InitializeComponent();
            this.Name = Name;
            this.IdPerent = IdPerent;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Value value = new Value();
            value.Name = tValue.Text;
            RequestSQL requestSQL = new RequestSQL();

            switch (Name)
            {
                case "project":
                    lName.Text = "Введите имя проекта";
                    requestSQL.AddProject(value);
                    break;
                case "department":
                    lName.Text = "Введите название отдела";
                    requestSQL.AddDepartment(value);                  
                    break;
                case "position":
                    lName.Text = "Введите название должности";
                    requestSQL.AddPosition(value);
                    break;
                case "country":
                    lName.Text = "Введите название страны";
                    requestSQL.AddCountry(value);
                    break;
                case "region":
                    lName.Text = "Введите название области";
                    requestSQL.AddRegion(value, IdPerent);
                    break;
                case "city":
                    lName.Text = "Введите название огорода";
                    requestSQL.AddCity(value, IdPerent);
                    break;
            }
            this.Close();
        }

        private void lName_Click(object sender, EventArgs e)
        {

        }
    }
}
