using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTaskTrackerDB
{
    public static class Program
    {
        private static void Main()
        {    
            FormAccessControl formAccessControl = new FormAccessControl();
            formAccessControl.ShowDialog();
        }
    }
}
