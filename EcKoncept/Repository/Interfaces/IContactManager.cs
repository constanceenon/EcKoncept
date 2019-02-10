using EcKoncept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Repository.Interfaces
{
    public interface IContactManager
    {
        Contact AddContact(Contact contact);
    }
}

