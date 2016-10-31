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
        //[Route("contacts/{id}", Name = "GetContact")] // TODO: figure out why this route always goes to `api/contacts` instead
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
        public IHttpActionResult Post([FromBody]Contact newContact)
        {
            if (ModelState.IsValid)
            {
                var newLogicContact = AutoMapper.Mapper.Map<LogicContact>(newContact);
                newContact = AutoMapper.Mapper.Map<Contact>(this._contactLogic.AddNewContact(newLogicContact));

                return CreatedAtRoute("DefaultApi", new { id=newContact.Id }, newContact);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Contacts/5
        public IHttpActionResult Put(int id, [FromBody]Contact updatedContact)
        {
            if (ModelState.IsValid)
            {
                var existingContact = this._contactLogic.GetContactById(id);
                if (existingContact == null)
                {
                    return NotFound();
                }

                var updatedLogicContact = AutoMapper.Mapper.Map<LogicContact>(updatedContact);
                updatedContact = AutoMapper.Mapper.Map<Contact>(this._contactLogic.UpdateContact(updatedLogicContact));

                return Ok(updatedContact);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Contacts/5
        public IHttpActionResult Delete(int id)
        {
            var foundLogicContact = this._contactLogic.GetContactById(id);

            if (foundLogicContact != null)
            {
                this._contactLogic.RemoveContact(foundLogicContact);
                
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
