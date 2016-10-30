using AddressBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContact = AddressBook.Data.Contact.Contact;

namespace AddressBook.BusinessLogic.Contact
{
    public class ContactLogic : IContactLogic
    {
        private IRepository<int, DataContact> _contactRepository;

        public ContactLogic()
        {
            this._contactRepository = RepositoryFactory.CreateContactRepository();
        }

        public Contact AddNewContact(Contact newContact)
        {
            var dataContact = AutoMapper.Mapper.Map<DataContact>(newContact);
            return AutoMapper.Mapper.Map<Contact>(this._contactRepository.Add(dataContact));
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return this._contactRepository.Get().Select(x => AutoMapper.Mapper.Map<Contact>(x));
        }

        public Contact GetContactById(int id)
        {
            var foundDataContact = this._contactRepository.GetById(id);
            return AutoMapper.Mapper.Map<Contact>(foundDataContact);
        }

        public void RemoveContact(Contact existingContact)
        {
            this._contactRepository.Delete(AutoMapper.Mapper.Map<DataContact>(existingContact));
        }

        public Contact UpdateContact(Contact existingContact)
        {
            var updatedContact = this._contactRepository.Update(AutoMapper.Mapper.Map<DataContact>(existingContact));
            return AutoMapper.Mapper.Map<Contact>(updatedContact);
        }
    }
}
