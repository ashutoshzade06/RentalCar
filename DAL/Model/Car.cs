using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Car
    {
        [Key]
        public string UIN { get; set; }

        [Required]
        public string License { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Fuel_Type { get; set; }

        [Required]
        public string Model { get; set; }

    }
}
