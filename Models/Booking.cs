using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId {get; set;}

        public DateTime BookingDate {get; set;} = DateTime.Now;
        public int NoofPassengers {get; set;} = 1;
        public bool BookingStatus {get; set;} = true;

        [ForeignKey("Customer")]
        public int CustomerId {get; set;}   
        [ForeignKey("Vehicle")]
        public int VehicleId {get; set;}
        [ForeignKey("Route")]
        public int RouteId {get; set;}
    }
}