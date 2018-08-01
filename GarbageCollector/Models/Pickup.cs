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
        [Display(Name ="Pickup Day")]
        public string DayOfWeek { get; set; }
        public bool PickUpCompleted { get; set; }

 

        


    }
}