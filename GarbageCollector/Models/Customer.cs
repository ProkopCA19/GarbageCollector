using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Trashbalance { get; set; }
        [Display(Name = "Bonus Pickup Day")]
        [DataType(DataType.Date)]
        public DateTime? BonusPickup { get; set; }
        



        [ForeignKey("Zipcode")]
        public int ZipId { get; set; }
        public Zipcode Zipcode { get; set; }


        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Pickup")]
        public int PickupId { get; set; }
        public Pickup Pickup { get; set; }

    }
}