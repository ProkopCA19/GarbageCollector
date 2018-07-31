using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class Pickup
    {
        [Key]
        public int PickupID { get; set; }
        public string DayOfWeek { get; set; }
        public bool PickUpCompleted { get; set; }

 

        


    }
}