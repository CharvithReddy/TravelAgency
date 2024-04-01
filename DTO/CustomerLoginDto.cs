using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 
namespace ATA.DTO
{
    public class CustomerLoginDto
    {
        [Required]
        public string CustomerMail {get; set;}
        [Required]
        public string CustomerPassword {get; set;}
    }
}