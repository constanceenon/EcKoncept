using EcKoncept.Interfaces.Repositories;
using EcKoncept.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EcKoncept.Infrastructure.Security
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private IUserRepository _repo;

        public UserStore(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            
            try
            {
                var newUser = await _repo.CreateUser(user);
                return IdentityResult.Success;
            }
            catch(Exception ex)
            {
                var error = new IdentityError
                {
                    Code = "",
                    Description = $"Identity Error: {ex.Message}"
                };
                return IdentityResult.Failed(error);
            }
            
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeleteUser(user);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                var error = new IdentityError
                {
                    Code = "",
                    Description = $"Identity Error: {ex.Message}"
                };
                return IdentityResult.Failed(error);
            }
        }

        public void Dispose()
        {
            
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return _repo.GetUserById(userId);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return _repo.GetUserByEmail(normalizedUserName);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email.ToLower());
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId);
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email.ToLower());
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash == null);
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;
            await Task.Yield();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            return _repo.UpdatePasswordHash(user.UserId, passwordHash);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Email = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = await _repo.UpdateUser(user);
                return IdentityResult.Success;
            }
            catch(Exception ex)
            {
                var error = new IdentityError
                {
                    Code = "",
                    Description = $"Identity Error: {ex.Message}"
                };
                return IdentityResult.Failed(error);
            }
        }
    }
}
