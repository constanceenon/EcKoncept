using EcKoncept.Models;
using EcKoncept.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Repository.Interfaces
{
    public interface IContactManager
    {
        Task<Contact> AddContact(Contact contact);
    }
}

