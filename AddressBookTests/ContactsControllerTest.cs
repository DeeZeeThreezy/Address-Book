using System;
using NUnit.Framework;
using AddressBook.BusinessLogic.Contact;
using Moq;
using LogicContact = AddressBook.BusinessLogic.Contact.Contact;
using Contact = Address_Book.Models.Contact;
using System.Collections.Generic;
using System.Linq;
using Address_Book.Controllers;
using System.Web.Http.Results;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactsControllerTest
    {
        private List<LogicContact> _logicContactsList;

        private ContactsController _contactsController;


        #region Set UP
        [SetUp]
        protected void SetUp()
        {
            AutoMapper.Mapper.Initialize(Address_Book.AutoMapperConfig.Configure);


            InitContactsList();


            var mock = new Mock<IContactLogic>();

            mock.Setup(x => x.GetAllContacts()).Returns(this._logicContactsList);

            mock.Setup(x => x.GetContactById(It.IsAny<int>())).Returns<int>(id =>
            {
                return this._logicContactsList.SingleOrDefault(x => x.Id == id);
            });

            mock.Setup(x => x.AddNewContact(It.IsAny<LogicContact>())).Returns<LogicContact>(x =>
            {
                lock (this._logicContactsList)
                {
                    x.Id = this._logicContactsList.Max(y => y.Id) + 1;
                    this._logicContactsList.Add(x);
                }
                return x;
            });

            mock.Setup(x => x.UpdateContact(It.IsAny<LogicContact>())).Callback<LogicContact>(x =>
            {
                lock (this._logicContactsList)
                {
                    var foundContact = this._logicContactsList.Find(y => y.Id == x.Id);

                    if (foundContact != null)
                    {
                        var contactIndex = this._logicContactsList.IndexOf(foundContact);
                        _logicContactsList.RemoveAt(contactIndex);
                        _logicContactsList.Insert(contactIndex, x);
                    }
                    else
                    {
                        // throw or return failure
                    }
                }
            });

            mock.Setup(x => x.RemoveContact(It.IsAny<LogicContact>())).Callback<LogicContact>(x =>
            {
                this._logicContactsList.Remove(x);
            });

            this._contactsController = new ContactsController(mock.Object);
        }

        protected void InitContactsList()
        {
            this._logicContactsList = new List<LogicContact>()
            {
                new LogicContact()
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
                new LogicContact()
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
                new LogicContact()
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
        }
        #endregion


        #region GET Tests
        [Test]
        public void GetContactsTest()
        {
            var controllerContacts = this._contactsController.Get();
            var expectedCount = this._logicContactsList.Count;

            Assert.That(controllerContacts.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetContactTest()
        {
            var contactId = 1;

            var actionResult = this._contactsController.Get(contactId);
            var contentResult = actionResult as OkNegotiatedContentResult<Contact>;

            var controllerContact = contentResult.Content;

            Assert.That(controllerContact, Is.Not.Null);
            Assert.That(controllerContact.Id, Is.EqualTo(contactId));
        }
        #endregion


        #region POST Tests
        [Test]
        public void POSTValidContactTest()
        {
            var newContact = new Contact()
            {
                Id = -5,
                Name = "New Newman",
                NickName = "New Guy",
                EmailAddress = "newman@newnet.com",
                Address = "1991 N. Streety Street Phx, Az 85032",
                Birthday = DateTime.Now
            };
            var expecetedId = this._logicContactsList.Max(x => x.Id) + 1;


            var actionResult = this._contactsController.Post(newContact);
            var contentResult = actionResult as CreatedNegotiatedContentResult<Contact>;

            var newControllerContact = contentResult.Content;

            Assert.That(newControllerContact, Is.Not.Null);
            Assert.That(newControllerContact.Id, Is.EqualTo(expecetedId));
        }
        #endregion

    }
}
