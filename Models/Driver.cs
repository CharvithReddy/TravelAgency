using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId {get; set;}

        [Required(ErrorMessage = "full name required")]
        public string DriverFullName {get; set;}

        [Required(ErrorMessage = "license number required")]
        public string LicenseNo {get; set;}

        [Required(ErrorMessage = "mobile number required")]
        public long DriverMobileNo {get; set;}

    }
}