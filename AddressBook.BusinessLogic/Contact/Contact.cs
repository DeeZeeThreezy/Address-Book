using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BusinessLogic.Contact
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
}
