using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.DTO
{
    public class BookingDto
    {
        public DateTime BookingDate { get; set; }
        public int NoofPassengers { get; set; }
        public string BookingStatus { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int RouteId {get; set;}
    }
}