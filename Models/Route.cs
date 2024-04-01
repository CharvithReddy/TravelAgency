using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId {get; set;}

        [Required(ErrorMessage = "starting point required")]
        public string Source {get; set;}

        [Required(ErrorMessage = "destination required")]
        public string Destination {get; set;}

        [Required(ErrorMessage = "distance required")]
        public int Distance {get; set;}

        [Required(ErrorMessage = "duration required")]
        public string Duration {get; set;}
    }
}