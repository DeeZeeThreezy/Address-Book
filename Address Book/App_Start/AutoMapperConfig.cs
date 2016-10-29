using Address_Book.Models;
using LogicContact = AddressBook.BusinessLogic.Contact.Contact;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Address_Book
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Contact, LogicContact>();
            config.CreateMap<LogicContact, Contact>();

            AddressBook.BusinessLogic.AutoMapperConfig.Configure(config);
        }
    }
}