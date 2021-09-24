using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Customer
    {
        [Key]
        public string Driver_License { get; set; }

        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Postal_Code { get; set; }

        [Required]
        public string Phone_No { get; set; }
    }
}
