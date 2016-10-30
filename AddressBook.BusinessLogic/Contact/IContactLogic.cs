using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BusinessLogic.Contact
{
    public interface IContactLogic
    {
        Contact GetContactById(int number);
        IEnumerable<Contact> GetAllContacts();

        Contact AddNewContact(Contact newContact);
        Contact UpdateContact(Contact existingContact);
        void RemoveContact(Contact existingContact);
    }
}
