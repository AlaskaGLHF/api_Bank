using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using api_bank.Models;
using api_bank.Repositories;
using System;
using api_Bank.BankContext;

namespace api_bank.Repositories;
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _context;

        public UserRepository(BankContext context)
        {
            _context = context;
        }

    public async Task<User> GetUserByIdAsyncUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            throw new KeyNotFoundException($"User with id {id} not found.");
        }

        return user;
    }

    public async Task<User> CreateUserAsyncUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsyncUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsyncUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    public async Task<List<User>> GetAllAsyncUser()
    {
        return await _context.Users.ToListAsync();
    }
}
