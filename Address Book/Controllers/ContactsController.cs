using Contact = Address_Book.Models.Contact;
using LogicContact = AddressBook.BusinessLogic.Contact.Contact;
using AddressBook.BusinessLogic.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Address_Book.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactLogic _contactLogic;

        public ContactsController()
        {
            this._contactLogic = new ContactLogic();
        }
        public ContactsController(IContactLogic contactLogic)
        {
            this._contactLogic = contactLogic;
        }

        // GET: api/Contacts
        public IEnumerable<Contact> Get()
        {
            var logicContacts = this._contactLogic.GetAllContacts();

            var contacts = logicContacts.Select(x => AutoMapper.Mapper.Map<Contact>(x)).ToList();

            return AutoMapper.Mapper.Map<IEnumerable<Contact>>(logicContacts);
        }

        // GET: api/Contacts/5
        public IHttpActionResult Get(int id)
        {
            var foundLogicContact = this._contactLogic.GetContactById(id);
            if (foundLogicContact != null)
            {
                var contact = AutoMapper.Mapper.Map<Contact>(foundLogicContact);
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Contacts
        public void Post([FromBody]Contact newContact)
        {
            var newLogicContact = AutoMapper.Mapper.Map<LogicContact>(newContact);
            this._contactLogic.AddNewContact(newLogicContact);
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]Contact updatedContact)
        {
            var updatedLogicContact = AutoMapper.Mapper.Map<LogicContact>(updatedContact);
            this._contactLogic.UpdateContact(updatedLogicContact);
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
            var foundLogicContact = this._contactLogic.GetContactById(id);

            if (foundLogicContact != null)
            {
                this._contactLogic.RemoveContact(foundLogicContact);
            }
            else
            {
                // return NotCreated or something like that
            }
        }
    }
}
