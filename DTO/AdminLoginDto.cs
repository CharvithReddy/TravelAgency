using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 
namespace ATA.DTO
{
    public class AdminLoginDto
    {
        [Required]
        public string AdminEmail {get; set;}
        [Required]
        public string AdminPassword {get; set;}
    }
}