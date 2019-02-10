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
        public ContactUs AddContact(ContactUs contact)
        {
            var entity = new ContactUs
            {
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email,
                Website = contact.Website,
                Msg = contact.Msg

            };
            _context.Set<ContactUs>().Add(entity);
            _context.SaveChanges();
            contact.ID = entity.ID;
            return entity;
        }
    }
}
