using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Rented_Car
    {
        [Key]
        public int Rented_Id { get; set; }

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
        public string Car_ID { get; set; }


        [ForeignKey("Car_ID")]
        public virtual Car Car { get; set; }

        [Required]
        public string Driver_License { get; set; }

        [ForeignKey("Driver_License")]
        public virtual Customer Customer { get; set; }

    }
}
