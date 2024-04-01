using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.DTO
{
    public class RouteDto
    {
        public string Source {get; set;}
        public string Destination {get; set;}
        public int Distance {get; set;}
        public string Duration {get; set;}

    }
}