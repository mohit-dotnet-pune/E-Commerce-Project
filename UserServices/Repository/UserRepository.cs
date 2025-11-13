using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserServices.Data;
using UserServices.Models;

namespace UserServices.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user1 = await _dbContext.users.FindAsync(id);
            if (user1 != null)
            {
                _dbContext.users.Remove(user1);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return _dbContext.users.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.users.FindAsync(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            var user1 = await GetUserById(user.UserId);
            if (user1 != null)
            {
                user1.UserName = user.UserName;
                user1.Phone = user.Phone;

                 _dbContext.SaveChanges();
                return user1;
            }
            return null;
        }
    }
}
