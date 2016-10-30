using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Address_Book.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime? Birthday { get; set; }

        public string JobTitle { get; set; }
        public string Company { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        //[StreetAddressAttribute]
        public string Address { get; set; }
    }

    public class StreetAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}