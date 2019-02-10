using EcKoncept.Interfaces.Repositories;
using EcKoncept.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            var entity = await _context.Set<User>().FindAsync(user.UserId);
            _context.Set<User>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string normalizedUserName)
        {
            var query = from users in _context.Set<User>()
                        where users.Email == normalizedUserName
                        select users;

            var user = await query.FirstOrDefaultAsync();
            return user;
        }

        public Task<User> GetUserById(string userId)
        {
            return _context.Set<User>().FindAsync(userId);
        }

        public async Task UpdatePasswordHash(string userId, string passwordHash)
        {
            var user = await _context.Set<User>().FindAsync(userId);
            if (user == null) throw new Exception("Invalid User");
            user.PasswordHash = passwordHash;
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var entity = await _context.Set<User>().FindAsync(user.UserId);
            if (entity == null) throw new Exception("Invalid User");
            user.Email = user.Email;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
