using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskTrackerDB.ClassesWithTableFields
{
    internal class EmployeeDetails
    {
        public string PassportNumber { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportIssueCode { get; set; }
        public int BaseSalary { get; set; }
        public int OverSalaryAmount { get; set; }
        public string OverSalaryPeriod { get; set; }
        public int AmountOfBonuses { get; set; }
        public string DateOfBonuses { get; set; }
        public string DateJoined { get; set; }
    }
}
