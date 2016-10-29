using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace AddressBook.Data.Contact
{
    internal class InMemoryContactRepository : IRepository<int, Contact>
    {
        // TODO: Delete and move to Unit Test
        private List<Contact> _initialContacts = new List<Contact>()
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

    private const string _cacheKey = "InMemoryContactRepository";


        public InMemoryContactRepository()
        {
            if (_Cache.Get(_cacheKey) == null)
            {
                _Cache.Add(_cacheKey, this._initialContacts, null);
            }
        }

        private MemoryCache _Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        private List<Contact> _CachedContacts
        {
            get
            {
                return _Cache.Get(_cacheKey) as List<Contact>;
            }
        }


        public Contact GetById(int id)
        {
            return _CachedContacts.Find(x => x.Id == id);
        }

        public IEnumerable<Contact> Get()
        {
            return _CachedContacts;
        }

        public void Update(Contact updatedEntity)
        {
            var foundContact = _CachedContacts.Find(x => x.Id == updatedEntity.Id);

            if (foundContact != null)
            {
                var contactIndex = _CachedContacts.IndexOf(foundContact);
                _CachedContacts.RemoveAt(contactIndex);
                _CachedContacts.Insert(contactIndex, updatedEntity);
            }
            else
            {
                // throw or return failure
            }
        }

        public void Add(Contact newEntity)
        {
            _CachedContacts.Add(newEntity);
        }

        public void Delete(Contact entity)
        {
            _CachedContacts.Remove(entity);
        }
    }
}
