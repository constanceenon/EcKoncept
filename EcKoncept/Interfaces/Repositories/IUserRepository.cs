using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcKoncept.Models.Domain;

namespace EcKoncept.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(User user);
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmail(string normalizedUserName);
        Task UpdatePasswordHash(string userId, string passwordHash);
        Task<User> UpdateUser(User user);
    }
}
