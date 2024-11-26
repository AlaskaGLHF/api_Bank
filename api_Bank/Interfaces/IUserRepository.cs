using System.Threading.Tasks;
using api_bank.Models;

namespace api_bank.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsyncUser();
        Task<User> GetUserByIdAsyncUser(int id);
        Task<User> CreateUserAsyncUser(User user);
        Task<User> UpdateUserAsyncUser(User user);
        Task<bool> DeleteUserAsyncUser(int id);
    }
}
