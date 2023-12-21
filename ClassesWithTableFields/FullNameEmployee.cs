using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskTrackerDB
{

    public class FullNameEmployee
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string MiddleName { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }

        public FullNameEmployee(int id, string firstName, string lastName, string middleName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            FillFullName();
        }

        private void FillFullName()
        {
            FullName  = string.Join(" ", new[] { LastName, FirstName, MiddleName }.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
