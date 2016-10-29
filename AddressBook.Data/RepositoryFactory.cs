using AddressBook.Data.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactEntity = AddressBook.Data.Contact.Contact;

namespace AddressBook.Data
{
    public static class RepositoryFactory
    {
        public static IRepository<int, ContactEntity> CreateContactRepository()
        {
            return new InMemoryContactRepository();
        }
    }
}
