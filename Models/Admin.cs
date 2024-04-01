using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId {get; set;}
        
        [Required(ErrorMessage = "mail required")]
        public string AdminEmail {get; set;}

        [Required(ErrorMessage = "password required")]
        public string AdminPassword {get; set;}
    }
}