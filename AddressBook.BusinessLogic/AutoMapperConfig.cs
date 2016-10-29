using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicContact = AddressBook.BusinessLogic.Contact.Contact;
using DataContact = AddressBook.Data.Contact.Contact;

namespace AddressBook.BusinessLogic
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<LogicContact, DataContact>();
            config.CreateMap<DataContact, LogicContact>();
        }
    }
}
