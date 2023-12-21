using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskTrackerDB
{
    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Value()
        {

        }

        public Value(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
