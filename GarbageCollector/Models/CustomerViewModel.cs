using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Trashbalance { get; set; }
        public int Zipcode { get; set; }
        public string PickupDay { get; set; }
        public bool PickupCompleted { get; set; }

        public DateTime? BonusPickup { get; set; }
       
    }
}