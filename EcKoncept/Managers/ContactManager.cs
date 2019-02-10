using EcKoncept.Models;
using EcKoncept.Models.Domain;
using EcKoncept.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Managers
{
    public class ContactManager : IContactManager
    {
        private DbContext _context;

        public ContactManager(DbContext Context)
        {
            _context = Context;
        }
        public async Task<Contact> AddContact(Contact contact)
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
            await _context.SaveChangesAsync();
            contact.ContactId = entity.ContactId;
            return entity;
        }
    }
}
