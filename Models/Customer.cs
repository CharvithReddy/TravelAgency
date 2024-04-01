using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId {get; set;}

        [Required(ErrorMessage = "full name required")]
        public string CustomerFullName {get; set;}

        [Required(ErrorMessage = "date of birth required")]
        public DateTime DOB {get; set;}

        [Required(ErrorMessage = "gender selection required")]
        public string Gender {get; set;}

        [Required(ErrorMessage = "address required")]
        public string Address {get; set;}

        [Required(ErrorMessage = "mail required")]
        public string CustomerMail {get; set;}

        [Required(ErrorMessage = "mobile number required")]
        public long CustomerMobile {get; set;}

        [Required(ErrorMessage = "password required")]
        public string CustomerPassword {get; set;}
    }   
}