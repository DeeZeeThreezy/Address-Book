using System;
using System.Collections.Generic;
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

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
    }

    //public class Address
    //{
    //    public string LineOne { get; set; }
    //    public string LineTwo { get; set; }
    //    public string City { get; set; }
    //    public StateEnum State { get; set; }
    //    public string ZipCode { get; set; }
    //}
}