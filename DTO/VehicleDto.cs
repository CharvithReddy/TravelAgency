using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.DTO
{
    public class VehicleDto
    {
        public string VehicleName {get; set;}
        public int FarePerKm {get; set;}
        public string VehicleType {get; set;}
        public int SeatingCapacity {get; set;}
        public string VehicleNumber {get; set;}
        public int DriverId {get; set;}
    }
}