using System.Threading.Tasks;
using api_bank.Models;

namespace api_bank.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsyncUser();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetByLoginAsync(string login);
    }
}
