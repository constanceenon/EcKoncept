using EcKoncept.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Interfaces.Managers
{
    public interface IContactManager
    {
        Contact AddContact(Contact contact);
    }
}
