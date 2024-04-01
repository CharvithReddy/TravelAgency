using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId {get; set;}

        [Required(ErrorMessage = "vehicle name required")]
        public string VehicleName {get; set;}

        public int FarePerKm {get; set;} = 20;

        [Required(ErrorMessage = "vehicle type required")]
        public string VehicleType {get; set;}
        
        public int SeatingCapacity {get; set;} = 25;

        [Required(ErrorMessage = "vehicle number required")]
        public string VehicleNumber {get; set;}

        [ForeignKey("Driver")]
        public int DriverId {get; set;}
    }
}