using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.RentedCarVM
{
    public class Rented_CarVM
    {
        [Required]
        public DateTime From_Date { get; set; }

        [Required]
        public DateTime To_Date { get; set; }

        [Required]
        public string From_Location { get; set; }

        [Required]
        public string To_Location { get; set; }

        [Required]
        public int Odometer_Before { get; set; }

        [Required]
        public int Odometer_After { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Car_UIN { get; set; }



        [Required]
        public string Driver_License { get; set; }

    }
}
