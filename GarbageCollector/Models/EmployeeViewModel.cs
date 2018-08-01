using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }

    }
}