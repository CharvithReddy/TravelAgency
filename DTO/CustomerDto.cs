using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATA.DTO
{
    public class CustomerDto
    {
        public string CustomerFullName {get; set;}
        public DateTime DOB {get; set;}
        public string Gender {get; set;}
        public string Address {get; set;}
        public string CustomerMail {get; set;}
        public long CustomerMobile {get; set;}
        public string CustomerPassword {get; set;}
    }
}