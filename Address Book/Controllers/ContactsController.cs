using Address_Book.Models;
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
        private List<Contact> _testContacts = new List<Contact>()
        {
            new Contact()
            {
                Id = 0,
                Name = "Domingo",
                NickName = "Dom",
                Birthday = new DateTime(1991, 4, 28),
                JobTitle = "DevDude",
                Company = "Willis Towers Watson",
                PhoneNumber = "602 366 0066",
                EmailAddress = "dperez3iii@gmail.com",
                Address = "1991 N. Streety Street Phx, Az 85032"
            },
            new Contact()
            {
                Id = 1,
                Name = "Jay",
                NickName = "Dom",
                Birthday = new DateTime(1991, 4, 28),
                JobTitle = "DevDude",
                Company = "Willis Towers Watson",
                PhoneNumber = "602 366 0066",
                EmailAddress = "dperez3iii@gmail.com",
                Address = "1991 N. Streety Street Phx, Az 85032"
            },
            new Contact()
            {
                Id = 2,
                Name = "Bob",
                NickName = "Dom",
                Birthday = new DateTime(1991, 4, 28),
                JobTitle = "DevDude",
                Company = "Willis Towers Watson",
                PhoneNumber = "602 366 0066",
                EmailAddress = "dperez3iii@gmail.com",
                Address = "1991 N. Streety Street Phx, Az 85032"
            }
        };

        // GET: api/Contacts
        public IEnumerable<Contact> Get()
        {
            return this._testContacts;
        }

        // GET: api/Contacts/5
        public IHttpActionResult Get(int id)
        {
            var foundContact = this._testContacts.Find(x => x.Id == id);
            if (foundContact != null)
            {
                return Ok(foundContact);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Contacts
        public void Post([FromBody]Contact newContact)
        {
            lock (this._testContacts)
            {
                var newId = this._testContacts.Max(x => x.Id) + 1;
                newContact.Id = newId;
                this._testContacts.Add(newContact);
            }
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]Contact updatedContact)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
            this._testContacts.RemoveAt(this._testContacts.FindIndex(x => x.Id == id));
        }
    }
}
