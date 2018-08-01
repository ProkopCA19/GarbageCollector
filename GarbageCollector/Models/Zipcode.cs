using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class Zipcode
    {

        [Key]

        public int ZipId{ get; set; }
        [Display(Name = "Zipcode")]
        public int Areacode { get; set; }

    }
}