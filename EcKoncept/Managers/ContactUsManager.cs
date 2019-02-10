using EcKoncept.Models;
using EcKoncept.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Managers
{
    public class ContactUsManager : IContactManager
    {
        private DbContext _context;

        public ContactUsManager(DbContext Context)
        {
            _context = Context;
        }
        public Contact AddContact(Contact contact)
        {
            var entity = new Contact
            {
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email,
                Website = contact.Website,
                Msg = contact.Msg

            };
            _context.Set<Contact>().Add(entity);
            _context.SaveChanges();
            contact.ContactId = entity.ContactId;
            return entity;
        }
    }
}
