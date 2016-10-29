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

        void AddNewContact(Contact newContact);
        void UpdateContact(Contact existingContact);
        void RemoveContact(Contact existingContact);
    }
}
