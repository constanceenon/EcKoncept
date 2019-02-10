using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Models.Domain
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
