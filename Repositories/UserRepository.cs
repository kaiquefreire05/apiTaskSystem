using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Injecting database dependency
        private readonly TaskSystemDBContext _context;

        public UserRepository(TaskSystemDBContext context)
        {
            _context = context;
        }

        // Methods 
        public async Task<UserModel> FindById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userFind = await FindById(id);
            // Checking if the found user is null
            if (userFind == null)
            {
                throw new Exception($"The id user {id} is not found in the database.");
            }

            userFind.Name = user.Name;
            userFind.Email = user.Email;
            _context.Users.Update(userFind);
            await _context.SaveChangesAsync();

            return userFind;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel userFind = await FindById(id);
            // Checking if the found user is null 
            if (userFind == null)
            {
                throw new Exception($"The user {id} is not found in the database");
            }
            _context.Users.Remove(userFind);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
