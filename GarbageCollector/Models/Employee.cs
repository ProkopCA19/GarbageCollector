using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class Employee
    {
        [Key]

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [ForeignKey("Zipcode")]
        public int ZipId { get; set; }
        public Zipcode Zipcode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}