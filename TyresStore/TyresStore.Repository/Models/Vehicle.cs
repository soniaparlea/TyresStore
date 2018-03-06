using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TyresStore.Repository.Models
{
    public class Vehicle
    {

        [Key]
        public int ID { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }
                
        public virtual ICollection<Tyre> Tyres { get; set; }
    }
}
